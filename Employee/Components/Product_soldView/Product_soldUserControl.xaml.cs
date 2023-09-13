using Employee.Entities.Purchased_products;
using Employee.Repositories.Clients;
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

namespace Employee.Components.Product_soldView
{
    /// <summary>
    /// Interaction logic for Product_soldUserControl.xaml
    /// </summary>
    public partial class Product_soldUserControl : UserControl
    {
        public Product_soldUserControl()
        {
            InitializeComponent();
        }


        public async void SetDate(Purchased_product purchased_Product)
        {
            id.Content = purchased_Product.id;
            totalcost.Content = purchased_Product.total_price;
            amount.Content = purchased_Product.product_amount;
            WorkersRepository workersRepository = new WorkersRepository();
            ClientsRepository clientsRepository = new ClientsRepository();
            ProductsRepository productsRepository = new ProductsRepository();


            lblworkername.Content = await workersRepository.Get(purchased_Product.worker_id);
            lblclientname.Content = await clientsRepository.Get(purchased_Product.client_id);
            productname.Content = await productsRepository.Get(purchased_Product.product_id);
            lbldes.Content = purchased_Product.description;
            lbltime.Content = purchased_Product.create_date;


        }




        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Purchased_productsRepository purchased_ProductsRepository = new Purchased_productsRepository();
            await purchased_ProductsRepository.DeleteAsync((int)Convert.ToInt64(id.Content));
            ((MainWindow)System.Windows.Application.Current.MainWindow).btnProductSold_Click(sender, e);

        }


    }
}
