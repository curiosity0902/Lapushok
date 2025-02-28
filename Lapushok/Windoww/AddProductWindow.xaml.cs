using Lapushok.DB;
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
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public static List<Product> products { get; set; }
        public static List<Material> materials { get; set; }
        public AddProductWindow()
        {
            InitializeComponent();

            products = new List<Product>(DBConnection.lapushokEntities.Product.ToList());
            materials = new List<Material>(DBConnection.lapushokEntities.Material.ToList());

            MaterialsLv.ItemsSource = materials;
        }

        private void MaterialCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
