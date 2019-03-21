using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSTool.Application
{
    public class Controller
    {
        SalesRepo repo = new SalesRepo();

        public void InsertSales(string itemName, string country, string currency, string dateofsale, float netprice, float vat)
        {
            repo.AddSale(itemName, country, currency, dateofsale, netprice, vat);
        }
        public List<Sale> ShowAllSales()
        {
            return repo.ShowAllSales();
        }
    }
}
