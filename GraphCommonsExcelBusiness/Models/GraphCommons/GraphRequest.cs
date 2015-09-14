using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphCommonsExcelBusiness.Models.GraphCommons
{
    public class GraphRequest
    {
        public string name { get; set; }
        public string description { get; set; }
        public short status { get; set; }
        public List<Signal> signals { get; set; }
    }
}
