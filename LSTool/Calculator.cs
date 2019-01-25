using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSTool
{
    public class Calculator
    {
        SalesRepo repo = new SalesRepo();
        public float MomsCalcForOneSale(string serialNo)
        {
            Sale sale = repo.GetSpecificSale(serialNo);
            float helper = sale.VAT + 1;
            return sale.NetPrice / helper;
        }
        public float TotalMomsFromAllSales(List<Sale> sales, string sortByCountry) // Per country or all sales?
        {
            List <Sale> momsCalcOnSales = repo.SalesFromDB();
            foreach (Sale item in momsCalcOnSales)
            {
                if (item.Country.Equals(sortByCountry))
                {
                    
                }
            }
        }
    }
}
