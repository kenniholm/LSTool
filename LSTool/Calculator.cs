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
        public float MomsCalcForOneSale(Sale sale)
        {
            float helper = sale.VAT + 1;
            return sale.NetPrice / helper;
        }
        public float TotalMomsFromAllSales() // Per country or all sales?
        {
            List <Sale> momsCalcOnSales = repo.SalesFromDB();
            float totalVAT = 0;

            foreach (Sale item in momsCalcOnSales)
            {
                totalVAT += MomsCalcForOneSale(item);
            }
            return totalVAT;
        }
    }
}
