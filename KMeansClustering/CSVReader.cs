using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeansClustering
{
    internal class CSVReader
    {
        public List<string> labels = new List<string>();
        public DataTable data = new DataTable();
        public int nClasses { get; private set; }
        public int nRows { get; private set; }

        string sep;

        public CSVReader(string filePath, string _sep = ",", bool hasLabels=true)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(fs);
            sep = _sep;
            string firstLine = reader.ReadLine();

            while (firstLine.Length > 0)
            {
                int i;
                for (i = 0; i < firstLine.Length; i++)
                {
                    if (firstLine[i] == sep[0]) break;
                }

                labels.Add(firstLine.Substring(0, i));
                if (i >= firstLine.Length) break;
                firstLine = firstLine.Substring(i + sep.Length);
            }

            nClasses = labels.Count;
            if (hasLabels) for (int i = 0; i < nClasses; i++) data.Columns.Add(labels[i]);
            else
            {
                data.Rows.Add(labels);
                for (int i = 0; i < nClasses; i++) data.Columns.Add($"property{i}");
            }
            
            string[] values = reader.ReadToEnd().Split("\n".ToCharArray());
            
            for (int id = 0; id < values.Length; id++)
            {
                string line = values[id];
                var row = valuesExtractor(line);
                if (row == null) continue;
                data.Rows.Add(row);
            }

            reader.Dispose();

            nRows = data.Rows.Count;
            if (!hasLabels) nRows++;
        }

        DataRow valuesExtractor(string line)
        {
            DataRow dataRow = data.NewRow();
            if (line == "" || line == null || line == " ") return null;

            for (int n = 0; n < nClasses; n++)
            {
                int i;
                for (i = 0; i < line.Length; i++)
                {
                    if (line[i] == sep[0]) break;
                }

                dataRow[n] = line.Substring(0, i);
                if (i >= line.Length) break;
                line = line.Substring(i + sep.Length);
            } 
            
            return dataRow;
        }

    }
}
