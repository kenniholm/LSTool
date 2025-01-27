﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSTool
{
    public class SalesRepo
    {
        DBconnector db = new DBconnector();
        public List<Sale> ShowAllSales()
        {
            return db.ShowAllSales();
        }
        public void AddSale(string ItemName, string Country, string Currency, string DateOfSale, float NetPrice, float VAT)
        {
            Sale sale = new Sale(ItemName, Country, Currency, DateOfSale, NetPrice, VAT);
            db.InsertSaleData(sale);
        }
        public Sale GetSpecificSale(string salesNo)
        {
            foreach (Sale item in ShowAllSales())
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
