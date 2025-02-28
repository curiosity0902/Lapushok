using Lapushok.DB;
using Lapushok.Pages;
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

namespace Lapushok.Windoww
{
    /// <summary>
    /// Логика взаимодействия для ChangeCostWindow.xaml
    /// </summary>
    public partial class ChangeCostWindow : Window
    {
        public static List<Product> products { get; set; }
        public ChangeCostWindow()
        {
            InitializeComponent();
            products = new List<Product>(DBConnection.lapushokEntities.Product.ToList());
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(SearchTbx.Text, out int newPrice))
            {
                var selectedProducts = DBConnection.lapushokEntities.Product.Where(p => p.).ToList(); 

                foreach (var product in selectedProducts)
                {
                    product.MinCostForAgent = newPrice; 
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Введите корректную цену.");
            }
        }

        private void SearchTbl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SearchTbl.Visibility = Visibility.Collapsed;
            SearchTbx.Focus();
        }
    }
}
