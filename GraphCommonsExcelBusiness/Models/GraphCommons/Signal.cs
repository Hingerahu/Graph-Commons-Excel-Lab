using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphCommonsExcelBusiness.Models.GraphCommons
{
    public class Signal
    {
          public string action {get; set;}
          public string from_name {get; set;}
          public string from_type {get; set;}
          public string to_name {get; set;}
          public string to_type {get; set;} 
          public string name {get; set;}
          public int weight {get; set;}
    }
}
