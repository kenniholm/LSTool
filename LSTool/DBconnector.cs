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
            try
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
            catch(SQLiteException e)
            {
                throw new SQLiteException("An error occured: " + e.Message);
            }
        }
        public List<Sale> ShowAllSales()
        {
            using (IDbConnection connect = new SQLiteConnection(ConnectionString()))
            {
                var output = connect.Query<Sale>("select * from SALES", new DynamicParameters());
                return output.ToList();
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
