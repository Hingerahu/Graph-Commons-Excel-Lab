using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphCommonsExcelBusiness.Models
{
    public class Edge
    {
        public int From { get; set; }
        public int To { get; set; }
        public string Relation { get; set; }
    }
}