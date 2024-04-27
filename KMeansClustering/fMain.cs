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

        public fMain()
        {
            InitializeComponent();
            cbMethod.SelectedIndex = 0;
        }

        private void btnSetData_Click(object _sender, EventArgs _e)
        {
            fData fData = new fData(data);
            Hide();            
            fData.Show();
            fData.FormClosed += (sender, e) => { Show(); refreshChart(); };                      
        }

        private void refreshChart()
        {
            if (data == null) return;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                double x = (double)data.Rows[i][3];
                double y = (double)data.Rows[i][4];
                chart.Series[0].Points.AddXY(x, y);
            }
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            refreshChart();
        }
    }
}
