using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSTool
{
    public class Sale
    {
        public string ItemName { get; set; }
        public string SalesNo { get; }
        public string Country { get; set; }
        public string Currency { get; set; }
        public string DateOfSale { get; set; }
        public float NetPrice { get; set; }
        public float VAT { get; set; }

        //public Sale (string salesNo)
        //{
        //    SalesNo = salesNo;
        //}
    }

}
