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
using Lapushok.DB;
using Lapushok.Windoww;

namespace Lapushok.Pages
{
    /// <summary>
    /// Логика взаимодействия для AllProductsPage.xaml
    /// </summary>
    public partial class AllProductsPage : Page
    {
        private int pageNumber = 1;
        private int pageCount = 1;
        public static List<Product> products { get; set; }
        public static List<TypeProduct> typeProducts { get; set; }
        public AllProductsPage()
        {
            InitializeComponent();
           
            products = new List<Product>(DBConnection.lapushokEntities.Product.ToList());
            typeProducts = new List<TypeProduct>(DBConnection.lapushokEntities.TypeProduct.ToList());

            var allTypesProduct = new TypeProduct
            {
                IDTypeProduct = 0,
                Name = "Все типы" 
            };
            typeProducts.Add(allTypesProduct);

            ProductsLv.ItemsSource = products; 
            
            Refresh();
            this.DataContext = this;
            
        }
        private void SearchTbl_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            SearchTbl.Visibility = Visibility.Collapsed;
            SearchTbx.Focus();
        }

        private void ProductsLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductsLv.SelectedItems.Count > 0)
            {
                ChangeCostBtn.Visibility = Visibility.Visible;
            }
            else
            {
                ChangeCostBtn.Visibility = Visibility.Collapsed;
            }
        }

        private void TypeCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void Cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SearchTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        public void Refresh()
        {
            List <Product> products = new List<Product>(DBConnection.lapushokEntities.Product.ToList());

            if (SearchTbx.Text.Length > 0)
            {
                products = products.Where(i => i.Name.ToLower().StartsWith(SearchTbx.Text.Trim().ToLower())).ToList();
            }

            var name = TypeCbx.SelectedItem as TypeProduct;

            if (TypeCbx.SelectedIndex >= 0 && name.Name != "Все типы")
            {
                products = products.Where(x => x.IDTypeProduct == name.IDTypeProduct).ToList();
            }

            if (DownUpCbx.SelectedIndex == 0)
            {
                products = products.OrderBy(x => x.Name).ToList();
            }

            if (DownUpCbx.SelectedIndex == 1)
            {
                products = products.OrderByDescending(x => x.Name).ToList();
            }

            if (DownUpCbx.SelectedIndex == 2)
            {
                products = products.OrderBy(x => x.NumberShop).ToList();
            }

            if (DownUpCbx.SelectedIndex == 3)
            {
                products = products.OrderByDescending(x => x.NumberShop).ToList();
            }

            if (DownUpCbx.SelectedIndex == 4)
            {
                products = products.OrderBy(x => x.RealCost).ToList();
            }

            if (DownUpCbx.SelectedIndex == 5)
            {
                products = products.OrderByDescending(x => x.RealCost).ToList();
            }

            pageCount = products.Count % 20 > 0 ? products.Count / 20 + 1 : products.Count / 20;
            products = products.Skip((pageNumber - 1) * 20).Take(20).ToList();
            NavSp.Children.Clear();
            if (pageCount > 1)
            {
                Button button1 = new Button
                {
                    Content = "<",
                    IsHitTestVisible = pageNumber > 1,
                    Background = new SolidColorBrush(Colors.Transparent),
                    BorderBrush = new SolidColorBrush(Colors.Transparent),
                };
                button1.Click += PageBtn_Click;
                NavSp.Children.Add(button1);
                for (int i = 1; i <= pageCount; i++)
                {
                    TextBlock textBlock = new TextBlock()
                    {
                        Text = i.ToString(),
                    };
                    if (i == pageNumber)
                    {
                        textBlock.TextDecorations = TextDecorations.Underline;
                    }
                    Button button2 = new Button
                    {
                        Content = textBlock,
                        IsHitTestVisible = i != pageNumber,
                        Background = new SolidColorBrush(Colors.Transparent),
                        BorderBrush = new SolidColorBrush(Colors.Transparent)
                    };
                    button2.Click += PageBtn_Click;
                    NavSp.Children.Add(button2);
                }
                Button button3 = new Button
                {
                    Content = ">",
                    IsHitTestVisible = pageNumber < pageCount,
                    Background = new SolidColorBrush(Colors.Transparent),
                    BorderBrush = new SolidColorBrush(Colors.Transparent)
                };
                button3.Click += PageBtn_Click;
                NavSp.Children.Add(button3);
            }

            ProductsLv.ItemsSource = products;
        }

        private void ProductsLv_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ProductsLv.SelectedItem is Product product)
            {
                NavigationService.Navigate(new EditProductPage());
            }
        }

        private void ChangeCostBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedProducts = ProductsLv.SelectedItems.Cast<Product>().ToList();
            
            ChangeCostWindow changeCostWindow = new ChangeCostWindow();
            changeCostWindow.ShowDialog();
        }

        private void PageBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Content.ToString())
            {
                case "<":
                    pageNumber--;
                    break;
                case ">":
                    pageNumber++;
                    break;
                default:
                    pageNumber = int.Parse(((TextBlock)button.Content).Text);
                    break;
            }
            Refresh();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProductWindow = new AddProductWindow();
            addProductWindow.ShowDialog();
        }
    }
}
