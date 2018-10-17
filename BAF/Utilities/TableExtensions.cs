using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace BAF.Utilities
{
    public class TableExtensions
    {
        public static Dictionary<string, string> ToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }

        //public static DataTable ToDataTable(Table table)
        //{
        //    var dataTable = new DataTable();
        //    foreach (var header in table.Header)
        //    {
        //        dataTable.Columns.Add(header, typeof(string));
        //    }

        //    foreach (var row in table.Rows)
        //    {
        //        var newRow = dataTable.NewRow();
        //        foreach (var header in table.Header)
        //        {
        //            newRow.SetField(header, row[header]);
        //        }
        //        dataTable.Rows.Add(newRow);
        //    }
        //    return dataTable;
        //}
    }


}
