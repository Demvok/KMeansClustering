using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeansClustering
{
    internal class KMeansCluster
    {        

        public Point[] centroids;
        public List<List<Point>> clusters;
        private List<Point> data;

        public KMeansCluster(DataTable _data, int C=2)
        {
            if (_data == null) throw new ArgumentNullException("Data missing");
            centroids = new Point[C];
            data = new List<Point>();
            clusters = new List<List<Point>>();            

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
                clusters = new List<List<Point>>();
                for (int i = 0; i < centroids.Length; i++)
                {
                    clusters.Add(new List<Point>());
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
                for (int i = 0; i < clusters.Count; i++)
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
            //

            return new Point(new List<double>(centroid));            
        }

        bool areListsEqual(List<double> list1, List<double> list2)
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
