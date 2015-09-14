using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphCommonsExcelBusiness.Models
{
    public class ExcelMetaData
    {
        public Dictionary<int, string> IndexedColumnNames { get; set; }
        public int RowCount { get; set; }
        public string FileName { get; set; }
    }
}