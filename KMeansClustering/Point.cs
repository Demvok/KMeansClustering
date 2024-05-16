using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeansClustering
{
    internal struct Point
    {
        public List<double> coords;

        public Point(List<double> _coords)
        {
            coords = new List<double>();
            foreach (double value in _coords)
            {
                coords.Add(value);
            }            
        }

        public double GetDistance(Point secondPoint)
        {
            // ?
            double sum = 0;
            for (int i = 0; i < coords.Count; i++)
            {
                sum += Math.Abs(Math.Pow(secondPoint.coords[i], 2) - Math.Pow(coords[i], 2));
            }
            return Math.Pow(sum, 1f / coords.Count);
        }

    }
}
