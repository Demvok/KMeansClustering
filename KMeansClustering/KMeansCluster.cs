using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace KMeansClustering
{
    internal class KMeansCluster
    {
        /// <summary>
        /// Method 0 - Mean of all points
        /// Method 1 - Median of all points
        /// </summary>
        public static int method = 0;

        public Point[] centroids;
        public List<Point>[] clusters;
        private List<Point> data;

        public KMeansCluster(DataTable _data, int C=2)
        {
            if (_data == null) throw new ArgumentNullException("Data missing");
            centroids = new Point[C];
            data = new List<Point>();
            clusters = new List<Point>[C];            

            foreach (DataRow row in _data.Rows)
            {
                List<double> entryPoint = new List<double>();  
                
                foreach (var cell in row.ItemArray)
                {
                    entryPoint.Add(Convert.ToDouble(cell, System.Globalization.CultureInfo.InvariantCulture));
                }
                data.Add(new Point(entryPoint));
            }

            Random rnd = new Random();
            for (int i = 0; i < C; i++)
            {                
                int index = rnd.Next(0, data.Count + 1);
                List<double> newPoint = data[index].coords;
                centroids[i] = new Point(newPoint);
            }
        }

        public void Clusterize()
        {
            bool isConverged = false;

            while (!isConverged)
            {
                // Clear previous clusters
                clusters = new List<Point>[centroids.Length];
                for (int i = 0; i < centroids.Length; i++)
                {
                    clusters[i] = new List<Point>();
                }

                // Assign each point to the closest centroid
                for (int i = 0; i < data.Count; i++)
                {
                    double[] distances_to_each_centroid = new double[centroids.Length];
                    for (int j = 0; j < centroids.Length; j++)
                    {
                        distances_to_each_centroid[j] = data[i].GetDistance(centroids[j]);
                    }

                    double minValue = double.MaxValue;                    
                    for (int j = 0; j < distances_to_each_centroid.Length; j++)
                    {
                        if (distances_to_each_centroid[j] < minValue) minValue = distances_to_each_centroid[j];
                    }

                    int minIndex = Array.IndexOf(distances_to_each_centroid, minValue);
                    if (minIndex < 0) minIndex = 0;
                    
                    clusters[minIndex].Add(data[i]);
                }

                // Calculate new centroids
                Point[] new_centroids = new Point[centroids.Length];
                for (int i = 0; i < clusters.Length; i++)
                {
                    new_centroids[i] = CalculateCentroid(clusters[i]);
                }

                bool dataUpdated = true;
                for (int i = 0; i < new_centroids.Length; i++)
                {
                    if (areListsEqual(new_centroids[i].coords, centroids[i].coords))
                    {
                        dataUpdated = false;
                        break;
                    }
                }
                isConverged = !dataUpdated;

                centroids = new_centroids;

                if (isConverged) return;
            }
        }

        private Point CalculateCentroid(List<Point> points)
        {
            double[] centroid = new double[centroids[0].coords.Count];

            switch (method)
            {
                case 0:
                    // Method 1 - Mean of all points
                    foreach (Point point in points)
                    {
                        for (int i = 0; i < point.coords.Count; i++)
                        {
                            centroid[i] += point.coords[i];
                        }
                    }

                    for (int i = 0; i < centroid.Length; i++)
                    {
                        centroid[i] /= points.Count;
                    }
                    break;
                case 1:
                    // Method 2 - Median of all points
                    for (int i = 0; i < centroid.Length; i++)
                    {
                        double[] values = new double[points.Count];
                        for (int j = 0; j < points.Count; j++)
                        {
                            values[j] = points[j].coords[i];
                        }
                        Array.Sort(values);
                        
                        if (points.Count % 2 == 0)
                        {
                            centroid[i] = (values[points.Count / 2] + values[points.Count / 2 + 1]) / 2;
                        }
                        else
                        {
                            centroid[i] = values[points.Count / 2 + 1];
                        }
                    }
                    break;
                default:
                    throw new Exception("Unknown method exception");
            }             

            return new Point(new List<double>(centroid));            
        }

        private bool areListsEqual(List<double> list1, List<double> list2)
        {
            if (list1.Count != list2.Count) return false;
            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i] != list2[i]) return false;
            }
            return true;
        }     
    }
}
