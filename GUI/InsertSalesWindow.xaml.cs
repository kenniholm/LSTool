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
using LSTool;
namespace GUI
{
    /// <summary>
    /// Interaction logic for InsertSalesWindow.xaml
    /// </summary>
    public partial class InsertSalesWindow : Window
    {
        Controller con = new Controller();
        public InsertSalesWindow()
        {
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string ItemName, Date, Country, Currency, NetPricestring, VATstring;
            float NetPrice, VAT;

            ItemName = ItemBox.Text;
            Date = DateBox.Text;
            Country = CountryBox.Text;
            Currency = CurrencyBox.Text;
            NetPricestring = PriceBox.Text;
            VATstring = VATbox.Text;
            if (float.TryParse(NetPricestring, out NetPrice) & float.TryParse(VATstring, out VAT))
            {
            }
            else
            {
                MessageBox.Show("Net Price and VAT fields can only contain numbers!");
            }
            con.InsertSales(ItemName, Country, Currency, Date, NetPrice, VAT);
        }
    }
}
