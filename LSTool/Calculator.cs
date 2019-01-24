using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSTool
{
    public class Calculator
    {
        public float MomsCalc(float SaleTotal, float MomsInput)
        {
            float helper = MomsInput + 1;
            return SaleTotal / helper;
        }
        public float TotalMomsFromAllSales(Sale sale, string saleNo)
        {
            Sale _sale = new Sale(saleNo);

        }
    }
}
