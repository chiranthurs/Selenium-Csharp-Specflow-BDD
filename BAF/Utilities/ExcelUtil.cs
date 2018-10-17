using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace BAF.Utilities
{
    class ExcelUtil
    {
        public static DataTable ExcelToDataTable(string fileName)
        {
            //Open file and returns as Stream
            FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);

            //Createopenxmlreader via ExcelReaderFactory
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            //Set the First Row as Column Name
            excelReader.IsFirstRowAsColumnNames = true;

            //Return as DataSet
            DataSet result = excelReader.AsDataSet();

            //Get all the Tables
            DataTableCollection table = result.Tables;

            //Store it in DataTable
            DataTable resultTable = table["Sheet1"];

            return resultTable;
        }

        public static List<Datacollection> dataCol = new List<Datacollection>();

        public static void PopulateInCollection(string fileName)
        {

            DataTable table = ExcelToDataTable(fileName);

            //Iterate through the rows and columns of the Table
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                    //Add all the details for each row
                    dataCol.Add(dtTable);
                }
            }
        }

        public static string getExcelValues(int rowNumber, string columnName)
        {
            try
            {
                //Retriving Data using LINQ to reduce much of iterations
                string data = (from colData in dataCol
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();
                //var datas = dataCol.Where(x=>x.colName == columnName && x.rowNumber ==rowNumber).SingleOrDefault().colValue
                return data.ToString().Trim();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excel_ReadData Exception ", ex.StackTrace);
                return null;
            }
        }
    }

    public class Datacollection
    {
        public int rowNumber { get; set; }
        public string colName { get; set; }
        public string colValue { get; set; }
    }
}
