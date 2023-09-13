using Employee.Components.Product_soldView;
using Employee.Components.ProductsView;
using Employee.Components.WorkersView;
using Employee.FileJson;
using Employee.Repositories.Products;
using Employee.Repositories.Purchased_products;
using Employee.Repositories.Workers;
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
    /// Interaction logic for Products_sold.xaml
    /// </summary>
    public partial class Products_sold : Page
    {
        Purchased_productsRepository purchased_ProductsRepository = new Purchased_productsRepository();
        public Products_sold()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await RefreshAsync();
        }


        public async Task RefreshAsync()
        {
            wrpsold.Children.Clear();
            MethodJson.Clear();
            var products = await purchased_ProductsRepository.GetAllAsync();
            foreach (var item in products)
            {
                Product_soldUserControl product_soldUserControl = new Product_soldUserControl();
                product_soldUserControl.SetDate(item);
                wrpsold.Children.Add(product_soldUserControl);
            }
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
                var prud  = await purchased_ProductsRepository.SearchAsync(tbSearch.Text);
                await RefreshAsync();
                wrpsold.Children.Clear();
                foreach (var item in prud)
                {
                    Product_soldUserControl product_SoldUserControl = new Product_soldUserControl();
                    product_SoldUserControl.SetDate(item);
                    wrpsold.Children.Add(product_SoldUserControl);
                }
            }


            

        }

        

       
    }
}
