using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSTool
{
    public class SalesRepo
    {
        DBconnector db = new DBconnector();
        public List<Sale> SalesFromDB()
        {
            List<Sale> sales = new List<Sale>();
            sales = db.ShowSales();
            return sales;
        }
        public Sale GetSpecificSale(string salesNo)
        {
            foreach (Sale item in SalesFromDB())
            {
                if (item.SalesNo.Equals(salesNo))
                {
                    return item;
                }
            }
            throw new SystemException("A sale with that sales number doesn't exist.");
        }
    }
}
