using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KMeansClustering
{
    public partial class fData : Form
    {
        public DataTable data;

        string defaultFileLocation = System.Reflection.Assembly.GetEntryAssembly().Location;

        int N = 1;
        int M = 1;

        public fData(DataTable _data)
        {
            InitializeComponent();

            if (_data == null)
            {
                data = new DataTable();
            }
            else
            {
                data = _data;
                tbM.Text = data.Rows.Count.ToString();
                tbN.Text = data.Columns.Count.ToString();
            }

            dataGridView.DataSource = data;
            defaultFileLocation = defaultFileLocation.Substring(0, defaultFileLocation.Length - 48) + "\\Data\\Iris.csv";
            tbFileName.Text = defaultFileLocation;
        }

        private void tbN_TextChanged(object sender, EventArgs e)
        {
            if (tbN.Text.Length == 0) return;
            try
            {
                int value = int.Parse(tbN.Text);
                if (value < 1)
                {
                    N = 1;
                    tbN.Text = "1";
                }
                else N = value;
            }
            catch (Exception ex)
            {
                tbOut.Text = ex.Message;
                N = 1;
            }
        }
        private void tbM_TextChanged(object sender, EventArgs e)
        {
            if (tbM.Text.Length == 0) return;
            try
            {
                int value = int.Parse(tbM.Text);
                if (value < 1)
                {
                    M = 1;
                    tbM.Text = "1";
                }
                else M = value;
            }
            catch (Exception ex)
            {
                tbOut.Text = ex.Message;
                M = 5;
            }
        }

        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count != 0)
            {
                DialogResult res = MessageBox.Show("Таблиця не пуста, ця дія створить нову, а всі дані буде втрачено. Продовжити?", "Видалення вмісту", MessageBoxButtons.OKCancel);
                if (res == DialogResult.Cancel) return;
            }

            data.Clear();
            for (int i = 0; i < N; i++) data.Columns.Add($"Propety{i + 1}");
            for (int i = 0; i < M; i++) data.Rows.Add(data.NewRow());

            dataGridView.DataSource = data;
            for (var i = 0; i < dataGridView.Columns.Count; i++) dataGridView.Columns[i].Width = 80;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            var dialog = openFileDialog;
            dialog.InitialDirectory = "\\Data";

            dialog.ShowDialog();

            string fileName = dialog.FileName;
            tbFileName.Text = fileName;
        }
        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                CSVReader reader = new CSVReader(tbFileName.Text, ",", true);
                data = reader.data;
                tbN.Text = reader.nClasses.ToString();
                tbM.Text = reader.nRows.ToString();
            }
            catch (Exception ex)
            {
                tbOut.Text = ex.Message;
                return;
            }            

            dataGridView.DataSource = data;            
            for (var i = 0; i < dataGridView.Columns.Count; i++) dataGridView.Columns[i].Width = 80;
        }

        private void btnSubmit_Click(object sender, EventArgs e) => Close();

        private void fData_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (data.Rows.Count == 0) return;
            for (int row = 0; row < M; row++)
            {
                for (int column = 0; column < N; column++)
                {
                    data.Rows[row][column] = dataGridView.Rows[row].Cells[column].Value;
                }
            }
        }
    }
}
