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
        public DataTable centroids;

        public KMeansCluster(DataTable _data, int _C=2)
        {
            if (_data == null) throw new ArgumentNullException("Data missing");
            data = _data;
            C = _C;
            centroids = _data.Clone();

            Random rnd = new Random();
            for (int i = 0; i < C; i++)
            {                
                int index = rnd.Next(0, data.Rows.Count + 1);

                object[] values = data.Rows[index].ItemArray;

                DataRow newRow = centroids.NewRow();
                newRow.ItemArray = values;
                centroids.Rows.Add(newRow);
            }

        }

    }
}
