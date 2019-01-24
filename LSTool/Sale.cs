using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSTool
{
    public class Sale
    {
        string ItemName { get; set; }
        string SaleNo { get; set; }
        string Country { get; set; }
        string Currency { get; set; }
        string DateOfSale { get; set; }
        float SalePrice { get; set; }

        public Sale (string saleNo)
        {
            SaleNo = saleNo;
        }
    }

}
