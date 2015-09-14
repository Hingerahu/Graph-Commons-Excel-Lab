using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphCommonsExcelBusiness.Models.GraphCommons
{
    public class Graph
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string subtitle { get; set; }
        public short status { get; set; }
        public DateTime created_at { get; set; }
    }
}
