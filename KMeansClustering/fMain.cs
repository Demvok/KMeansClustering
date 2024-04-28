using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KMeansClustering
{
    public partial class fMain : Form
    {
        DataTable data;
        int C;
        string[] columnLabels;
        List<string> numericalColumns = new List<string>();

        public fMain()
        {
            InitializeComponent();
            cbMethod.SelectedIndex = 0;
            C = int.Parse(tbC.Text);
        }

        private void btnSetData_Click(object sender, EventArgs e)
        {
            fData fData = new fData(data);
            Hide();            
            fData.Show();
            fData.FormClosed += (_sender, _e) => { Show(); data = fData.data; dataLoaded(); };                      
        }

        private void dataLoaded()
        {
            bool isNumerical(string inp)
            {
                bool isNum = false;
                try
                {
                    Convert.ToDouble(inp, System.Globalization.CultureInfo.InvariantCulture);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            columnLabels = new string[data.Columns.Count];
            for (int i = 0; i < data.Columns.Count; i++)
            {
                columnLabels[i] = data.Columns[i].ColumnName;
                string value = data.Rows[0][i].ToString();
                if (isNumerical(value)) numericalColumns.Add(data.Columns[i].ColumnName);
            }

            foreach (string label in numericalColumns)
            {
                cbXAxis.Items.Add(label);                
                cbYAxis.Items.Add(label);
            }

            if (numericalColumns.Count == 0) return;
            cbXAxis.SelectedIndex = 0;
            if (numericalColumns.Count > 1)
            {
                cbYAxis.SelectedIndex = 1;
                refreshChart();
            }            
        }

        private void cbXAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbXAxis.SelectedIndex == cbYAxis.SelectedIndex) return;
            else refreshChart();
        }
        private void cbYAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbXAxis.SelectedIndex == cbYAxis.SelectedIndex) return;
            else refreshChart();
        }

        private void refreshChart()
        {
            if (data == null) return;
            chart.Series[0].Points.Clear();
            try
            {
                chart.ChartAreas[0].Axes[0].Title = cbXAxis.Text;
                chart.ChartAreas[0].Axes[1].Title = cbYAxis.Text;
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    double x = Convert.ToDouble(data.Rows[i].Field<string>(cbXAxis.Text), System.Globalization.CultureInfo.InvariantCulture);
                    double y = Convert.ToDouble(data.Rows[i].Field<string>(cbYAxis.Text), System.Globalization.CultureInfo.InvariantCulture);
                    chart.Series[0].Points.AddXY(x, y);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "Column '' does not belong to table .") return;
                tbOut.Text = ex.Message;
            }            
        }


        private void tbC_TextChanged(object sender, EventArgs e)
        {
            if (tbC.Text.Length == 0) return;
            try
            {
                int value = int.Parse(tbC.Text);
                if (value < 1)
                {
                    C = 1;
                    tbC.Text = "1";
                }
                else C = value;
            }
            catch (Exception ex)
            {
                tbOut.Text = ex.Message;
                C = 2;
            }
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            if (data == null) return;

            DataTable cleanedData = data.Clone();
            foreach (DataRow row in data.Rows)
            {
                cleanedData.ImportRow(row);
            }

            List<string> toDelete = new List<string>();
            foreach (DataColumn column in cleanedData.Columns)
            {
                bool isNum = false;
                foreach (string label in numericalColumns)
                {
                    if (label == column.ColumnName) isNum = true;
                }

                if (!isNum) toDelete.Add(column.ColumnName);
            }

            foreach (string item in toDelete)
            {
                cleanedData.Columns.Remove(item);
            }

            switch (cbMethod.SelectedIndex)
            {
                case 0:
                    KMeansCluster cluster;
                    try
                    {
                        cluster = new KMeansCluster(cleanedData, C);
                    }
                    catch (Exception ex)
                    {
                        tbOut.Text = ex.Message;
                        return;
                    }
                    

                    tbOut.Text = "";
                    foreach (DataRow dot in cluster.centroids.Rows)
                    {
                        string res = "";
                        foreach (var cell in dot.ItemArray)
                        {
                            res += cell.ToString() + " | ";
                        }
                        tbOut.Text += res + "\r\n";
                    }
                    break;
                case 1:
                    break;
            }
        }

    }
}
