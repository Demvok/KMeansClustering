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
        public fMain()
        {
            InitializeComponent();
            cbMethod.SelectedIndex = 0;
        }

        private void btnSetData_Click(object sender, EventArgs e)
        {
            fData fData = new fData();
            fData.Show();
        }
    }
}
