using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.SampleMyWebApi.Models
{
    public class ClientProductModel
    {
        public int? ProdID { get; set; }
        public string ProdName { get; set; }
        public int? Qty { get; set; }
        public double? Rate { get; set; }

    }

}