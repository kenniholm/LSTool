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
            using (SQLiteConnection connect = new SQLiteConnection(ConnectionString()))
            {
                //connect.Execute("insert into SALES (ItemName, DateOfSale, Country, Currency, NetPrice, VAT) values (@ItemName, @DateOfSale, @Country, @Currency, @NetPrice, @VAT", sale);
                connect.Open();
                SQLiteCommand cmd = new SQLiteCommand(connect);
                cmd.CommandText = @"INSERT INTO SALES (ItemName, DateOfSale, Country, Currency, NetPrice, VAT) VALUES(@ItemName, @DateOfSale, @Country, @Currency, @NetPrice, @VAT)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SQLiteParameter("@ItemName", sale.ItemName));
                cmd.Parameters.Add(new SQLiteParameter("@DateOfSale", sale.DateOfSale));
                cmd.Parameters.Add(new SQLiteParameter("@Country", sale.Country));
                cmd.Parameters.Add(new SQLiteParameter("@Currency", sale.Currency));
                cmd.Parameters.Add(new SQLiteParameter("@NetPrice", sale.NetPrice));
                cmd.Parameters.Add(new SQLiteParameter("@VAT", sale.VAT));
                cmd.ExecuteNonQuery();
                connect.Close();
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
