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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewSale_Click(object sender, RoutedEventArgs e)
        {
            InsertSalesWindow insertWindow = new InsertSalesWindow();
            insertWindow.Show();
            this.Close();
        }

        private void CalcVAT_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowSales_Click(object sender, RoutedEventArgs e)
        {
            ShowSalesWindow showWin = new ShowSalesWindow();
            showWin.Show();
            this.Close();
        }
    }
}
