using GraphCommonsExcelBusiness.Models;
using SpreadsheetLight;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace GraphCommonsExcelBusiness
{
    public class ExcelUtility
    {
        public static ExcelMetaData GetExcelMetaData(Stream ms)
        {
            var doc = new SLDocument(ms);
            var worksheetStats = doc.GetWorksheetStatistics();

            var excelStats = new ExcelMetaData
            {
                RowCount = worksheetStats.NumberOfRows,
                IndexedColumnNames = GetIndexedColumnNames(doc)
            };

            return excelStats;
        }

        public static DataTable LoadExcelIntoDataTable(string filePath)
        {
            var doc = new SLDocument(filePath);
            var worksheetStats = doc.GetWorksheetStatistics();
            var dataTable = PrepareDataTableForExcel(doc);

            for (var row = 2; row < worksheetStats.EndRowIndex; row++)
            {
                var dataRow = dataTable.NewRow();
                for (var col = 0; col < worksheetStats.EndColumnIndex; col++)
                {
                    dataRow[col] = doc.GetCellValueAsString(row, col);
                }
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }

        private static DataTable PrepareDataTableForExcel(SLDocument doc)
        {
            var indexedColumnNames = GetIndexedColumnNames(doc);
            var table = new DataTable();
            foreach (var columnName in indexedColumnNames)
            {
                table.Columns.Add(columnName.Value);
            }
            return table;
        }

        public static Dictionary<int, string> GetIndexedColumnNames(SLDocument doc)
        {
            var indexedColumnNames = new Dictionary<int, string> { };
            var worksheetStats = doc.GetWorksheetStatistics();

            for (var i = 1; i <= worksheetStats.NumberOfColumns; i++)
            {
                indexedColumnNames.Add(i, doc.GetCellValueAsString(1, i));
            }
            return indexedColumnNames;
        }
    }
}
