using Employee.Components.ProductsView;
using Employee.Components.WorkersView;
using Employee.FileJson;
using Employee.Repositories.Products;
using Employee.Repositories.Workers;
using Employee.Windows.ProductsWindow;
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

namespace Employee.Pages
{
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    /// 

    public partial class Products : Page
    {
        ProductsRepository _productsRepository = new ProductsRepository();
        public Products()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await RefreshAsync();
        }



        public async Task RefreshAsync()
        {
            wrpProduct.Children.Clear();
            MethodJson.Clear();
            var products = await _productsRepository.GetAllAsync();


            foreach (var item in products)
            {
                ProductUserControl productUserControl = new ProductUserControl();
                productUserControl.SetDate(item);
                wrpProduct.Children.Add(productUserControl);
            }
        }

        private async void btncreate_Click(object sender, RoutedEventArgs e)
        {
            ProductCreateWindow productCreateWindow = new ProductCreateWindow();
            productCreateWindow.ShowDialog();
            await RefreshAsync();
        }

        
        private async void btnsearch_Click(object sender, RoutedEventArgs e)
        {
            if (tbSearch.Text == string.Empty)
            {
                await RefreshAsync();
            }
            else
            {
                MethodJson.Clear();
                ProductsRepository _productsRepository = new ProductsRepository();
                var products = await _productsRepository.SearchAsync(tbSearch.Text);
                wrpProduct.Children.Clear();
                foreach (var product in products)
                {
                    ProductUserControl productUserControl = new ProductUserControl();
                    productUserControl.SetDate(product);
                    wrpProduct.Children.Add(productUserControl);
                }
            }
        }
    }


}
