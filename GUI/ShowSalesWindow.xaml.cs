using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for ShowSalesWindow.xaml
    /// </summary>
    public partial class ShowSalesWindow : Window
    {
        LSTool.Application.Controller con = new LSTool.Application.Controller();
        public ShowSalesWindow()
        {
            InitializeComponent();
            BreakListDownAndInsertToListview();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }
        private void BreakListDownAndInsertToListview()
        {
            List<LSTool.Sale> list = con.ShowAllSales();
            foreach (LSTool.Sale sale in list)
            {
                string[] lvistring = {sale.SalesNo, sale.ItemName, sale.DateOfSale, sale.Country, sale.Currency };
                float[] lvifloat = {sale.NetPrice, sale.VAT };
                SalesView.Items.Add(new ListItems
                {
                    Id = lvistring[0],
                    Item = lvistring[1],
                    Date = lvistring[2],
                    Country = lvistring[3],
                    Currency = lvistring[4],
                    NetPrice = lvifloat[0],
                    VAT = lvifloat[1]
                });
            }
        }
    }
}
