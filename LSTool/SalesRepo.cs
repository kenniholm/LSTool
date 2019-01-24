using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSTool
{
    public class SalesRepo
    {
        List<Sale> sales = new List<Sale>();

        public void AddSale(Sale Sale)
        {
            sales.Add(Sale);
        }
        public List<Sale> GetSales()
        {
            return sales;
        }
        public Sale SetSaleAttributes(Sale sale, string itemName, string  )
        {

        }
    }
}
