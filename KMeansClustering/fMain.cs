using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
         readonly Color[] possibleColors = { Color.Blue, Color.Green, Color.Orange, Color.Purple, Color.Yellow, Color.Cyan,
            Color.Magenta, Color.Brown, Color.DarkBlue, Color.DarkGreen, Color.DarkOrange, Color.DarkCyan,
            Color.DarkMagenta};

        DataTable data;
        int C;

        Color[] palette;
        string[] columnLabels;
        List<string> numericalColumns = new List<string>();

        Point[] centroids;
        List<Point>[] clusters;        

        public fMain()
        {
            InitializeComponent();
            cbMethod.SelectedIndex = 0;
            C = int.Parse(tbC.Text);
            
            palette = new Color[possibleColors.Length - 1];
            for (int i = 0; i < C; i++)
            {                
                palette[i] = possibleColors[i];
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
                    DataPoint point = new DataPoint(x, y);

                    if (clusters != null)
                    {
                        int pointClass = findClass(x, y);
                        point.Color = palette[pointClass];
                    }
                    chart.Series[0].Points.Add(point);
                }

                if (centroids == null) return;
                for (int i = 0; i < centroids.Length; i++)
                {                                       
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

        private int findClass(double x, double y)
        {
            int pointClass = 0;
            for (int j = 0; j < clusters.Length; j++)
            {
                bool isInCluster = false;
                for (int n = 0; n < clusters[j].Count; n++)
                {
                    if (clusters[j][n].coords[numericalColumns.IndexOf(cbXAxis.Text)] == x &&
                        clusters[j][n].coords[numericalColumns.IndexOf(cbYAxis.Text)] == y)
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
            return pointClass;
        }

        private double GetExecutionTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            action();

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
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
            foreach (DataRow row in data.Rows) cleanedData.ImportRow(row);

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

            foreach (string item in toDelete) cleanedData.Columns.Remove(item);

            centroids = new Point[C];
            clusters = new List<Point>[C];
            for (int i = 0; i < C; i++)
            {
                centroids[i] = new Point(new List<double>());
                clusters[i] = new List<Point>();
            }

            KMeansCluster classifier;
            double time;
            switch (cbMethod.SelectedIndex)
            {
                case 0:
                    KMeansCluster.method = 0;
                    try
                    {
                        classifier = new KMeansCluster(cleanedData, C);
                        time = GetExecutionTime(() => classifier.Clusterize());
                    }
                    catch (Exception ex)
                    {
                        tbOut.Text = ex.Message;
                        return;
                    }                    

                    tbOut.Text = $"Метод виконано за {time}ms\r\n";
                    foreach (string label in numericalColumns)
                    {
                        tbOut.Text += label + " ";
                    }                    
                    tbOut.Text += "\r\n";
                    for (int i = 0; i < classifier.centroids.Length; i++)
                    {
                        centroids[i].coords = classifier.centroids[i].coords;
                        clusters[i] = classifier.clusters[i];
                        foreach (double value in classifier.centroids[i].coords)
                        {
                            tbOut.Text += value.ToString("N3") + " | ";
                        }
                        tbOut.Text += "\r\n";
                    }

                    refreshChart();                 
                    
                    break;
                case 1:
                    KMeansCluster.method = 1;
                    try
                    {
                        classifier = new KMeansCluster(cleanedData, C);
                        time = GetExecutionTime(() => classifier.Clusterize());
                    }
                    catch (Exception ex)
                    {
                        tbOut.Text = ex.Message;
                        return;
                    }

                    tbOut.Text = $"Метод виконано за {time}ms\r\n";
                    for (int i = 0; i < classifier.centroids.Length; i++)
                    {
                        centroids[i].coords = classifier.centroids[i].coords;
                        clusters[i] = classifier.clusters[i];
                        foreach (double value in classifier.centroids[i].coords)
                        {
                            tbOut.Text += value.ToString("N3") + " | ";
                        }
                        tbOut.Text += "\r\n";
                    }

                    refreshChart();
                    break;
            }
                        
        }

    }
}
