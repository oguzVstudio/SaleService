using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace Generali.UI.Utils
{
    public class ExcelImporter
    {
        public static IEnumerable<Dictionary<string, object>> ParseExcel(Stream document)
        {
            using (var reader = ExcelReaderFactory.CreateReader(document))
            {
                var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    UseColumnDataType = true,
                    ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true,
                    }
                });
                return MapDatasetData(result.Tables.Cast<DataTable>().First());
            }
        }

        public static IEnumerable<Dictionary<string, object>> MapDatasetData(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                var row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                yield return row;
            }
        }

        public static byte[] ReadFully(Stream file)
        {
            var buffer = new byte[file.Length];
            using (var memstream = new MemoryStream())
            {
                using (var reader = new StreamReader(file))
                {
                    reader.BaseStream.CopyTo(memstream);
                    buffer = memstream.ToArray();
                }
            }
            return buffer;
        }
    }
}