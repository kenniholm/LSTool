using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Configuration;
using Dapper;
using System.IO;

namespace LSTool
{
    public class DBconnector
    {
        public string ConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        public void InsertSaleData(Sale sale)
        {
            using (IDbConnection connect = new SQLiteConnection(ConnectionString()))
            {
                connect.Execute("insert into SALES (ItemName, DateOfSale, Country, Currency, NetPrice, VAT) values (@ItemName, @DateOfSale, @Country, @Currency, @NetPrice, @VAT", sale);

            }
        }
        public List<Sale> ShowSales()
        {
            using (IDbConnection connect = new SQLiteConnection(ConnectionString()))
            {
                var output = connect.Query<Sale>("select * from SALES", new DynamicParameters());
                return output.ToList();
            }
        }
    }
}
