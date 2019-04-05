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
        LSTool.Application.Controller con = new LSTool.Application.Controller();
        public InsertSalesWindow()
        {
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string ItemName = ItemBox.Text;
            string DateOfSale = DateBox.Text;
            string Country = CountryBox.Text;
            string Currency = CurrencyBox.Text;
            if (!float.TryParse(PriceBox.Text, out float NetPrice) & float.TryParse(VATbox.Text, out float VAT))
            {
                MessageBox.Show("Net Price and VAT fields can only contain numbers!");
            }
            con.InsertSales(ItemName, Country, Currency, DateOfSale, NetPrice, VAT);
            MessageBox.Show("Sale has been added.");
            ItemBox.Clear();
            DateBox.Clear();
            CountryBox.Clear();
            CurrencyBox.Clear();
            PriceBox.Clear();
            VATbox.Clear();
        }
    }
}
