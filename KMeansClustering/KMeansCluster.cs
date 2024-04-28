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

        public DataTable data;
        public int C;
        public DataTable centroids = new DataTable();

        public KMeansCluster(DataTable _data, int _C=2)
        {
            if (data == null) throw new ArgumentNullException("Data missing");
            data = _data;
            C = _C;

            for (int i = 0; i < C; i++)
            {
                Random rnd = new Random();
                int index = rnd.Next(0, data.Rows.Count + 1);

                object[] values = data.Rows[index].ItemArray;
                centroids.Rows.Add(values);
            }
        }

    }
}
