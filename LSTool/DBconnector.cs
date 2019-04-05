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
    public class DBconnector : IPublisher, ISubscriber
    {
        List<ISubscriber> subscribers = new List<ISubscriber>();
        public string ConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        public void InsertSaleData(Sale sale)
        {
                using (SQLiteConnection connect = new SQLiteConnection(ConnectionString()))
                {
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
        public List<Sale> ShowAllSales(SQLiteCommand cmd) // Fix DB names
        {
            using (SQLiteConnection connect = new SQLiteConnection(ConnectionString()))
            {
                connect.Open();
                List<Sale> data = new List<Sale>();
                Sale saleObject = new Sale();
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        saleObject.ItemName = reader["ItemName"].ToString();
                        saleObject.DateOfSale = reader["Lokation"].ToString();
                        saleObject.Country = reader["ProblemBeskrivelse"].ToString();
                        saleObject.Currency = reader["Tidspunkt"].ToString();
                        saleObject.NetPrice = (float)reader["ExtraInfo"];
                        saleObject.VAT = (float)reader["Status"];

                        data.Add(saleObject);
                    }
                }
                return data;
            }
        }

        public void NotifySubscribers(string message)
        {
            foreach (ISubscriber sub in subscribers)
            {
                sub.Update(this, message);
            }
        }

        public void RegisterSubscriber(ISubscriber observer)
        {
            subscribers.Add(observer);
        }

        public void RemoveSubscriber(ISubscriber observer)
        {
            subscribers.Remove(observer);
        }

        public void Update(IPublisher publisher, string message)
        {
            NotifySubscribers(message);
        }
    }
}
