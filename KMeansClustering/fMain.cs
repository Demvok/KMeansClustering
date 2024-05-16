using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace KMeansClustering
{
    public partial class fMain : Form
    {
        DataTable data;
        int C;
        string[] columnLabels;
        List<string> numericalColumns = new List<string>();

        Point[] centroids;
        Color[] palette;        

        public fMain()
        {
            InitializeComponent();
            cbMethod.SelectedIndex = 0;
            C = int.Parse(tbC.Text);
            centroids = new Point[C];
            palette = new Color[C];
            for (int i = 0; i < C; i++)
            {
                centroids[i] = new Point(new List<double>());
                Random rnd = new Random();
                palette[i] = Color.FromArgb(1, rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            }
                        
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
            chart.Series[1].Points.Clear();
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

                for (int i = 0; i < centroids.Length; i++)
                {
                    if (centroids[i].coords.Count == 0) continue;
                                       
                    double x = centroids[i].coords[numericalColumns.IndexOf(cbXAxis.Text)];
                    double y = centroids[i].coords[numericalColumns.IndexOf(cbYAxis.Text)];
                    chart.Series[1].Points.AddXY(x, y);                    
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
                    KMeansCluster classifier;
                    try
                    {
                        classifier = new KMeansCluster(cleanedData, C);                        
                    }
                    catch (Exception ex)
                    {
                        tbOut.Text = ex.Message;
                        return;
                    }
                    classifier.Clusterize();

                    tbOut.Text = "";
                    for (int i = 0; i < classifier.centroids.Length; i++)
                    {
                        centroids[i].coords = classifier.centroids[i].coords;
                        string res = "";
                        foreach (double value in classifier.centroids[i].coords)
                        {
                            res += value.ToString("N3") + " | ";
                        }
                        tbOut.Text += res + "\r\n";
                    }

                    for (int i = 0; i < chart.Series[0].Points.Count; i++)
                    {
                        DataPoint point = chart.Series[0].Points[i];

                        int pointClass = 0;
                        for (int j = 0; j < classifier.clusters.Count; j++)
                        {
                            var cluster = classifier.clusters[j];

                            bool isInCluster = false;
                            for (int n = 0; n < cluster.Count; n++)
                            {
                                if (cluster[n].coords[numericalColumns.IndexOf(cbXAxis.Text)] == point.XValue &&
                                    cluster[n].coords[numericalColumns.IndexOf(cbYAxis.Text)] == point.YValues[0])
                                {
                                    isInCluster = true;
                                    break;
                                }
                            }
                            if (isInCluster)
                            {
                                pointClass = j;
                                break;
                            }
                        }
                        chart.Series[0].Points[i].Color = palette[pointClass];                        
                    }

                    refreshChart();
                    break;
                case 1:
                    break;
            }
        }

    }
}
