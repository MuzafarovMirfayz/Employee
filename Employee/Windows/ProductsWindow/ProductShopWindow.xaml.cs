using Employee.Entities.Clients;
using Employee.Entities.Purchased_products;
using Employee.Entities.Workers;
using Employee.FileJson.SalaryJson;
using Employee.Helpers;
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
using System.Windows.Shapes;

namespace Employee.Windows.ProductsWindow
{
    /// <summary>
    /// Interaction logic for ProductShopWindow.xaml
    /// </summary>
    public partial class ProductShopWindow : Window
    {
        public IList<Client> clients { get; set; }
        public IList<Worker> workers { get; set; }

        public ProductShopWindow()
        {
            
            InitializeComponent();

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            WorkersRepository workersRepository = new WorkersRepository();
            ClientsRepository clientsRepository = new ClientsRepository();

            workers = await workersRepository.GetAllAsync();
            clients = await clientsRepository.GetAllAsync();

            foreach (var item in workers)
            {
                cmworker.Items.Add(item.first_name + item.last_name);

            }
            foreach (var item in clients)
            {
                cmclient.Items.Add(item.first_name + item.last_name);
               
            }

        }

        private async void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmclient.SelectedValue.ToString() == string.Empty || cmworker.SelectedValue.ToString() == string.Empty || product_amount.Text == string.Empty)
                {
                    MessageBox.Show("The data was entered incorrectly");
                }
                else
                {
                    Purchased_productsRepository purchased_ProductsRepository = new Purchased_productsRepository();
                    Purchased_product purchased_Product = new Purchased_product();
                    purchased_Product.worker_id = (int)workers[(int)Convert.ToInt64(cmworker.SelectedIndex)].id;
                    purchased_Product.client_id = (int)clients[(int)Convert.ToInt64(cmclient.SelectedIndex)].id;
                    purchased_Product.product_amount = (int)Convert.ToInt64(product_amount.Text);
                    var a = SalaryJsonMethod.AnlyRead();
                    purchased_Product.product_id = a[0].Id;
                    purchased_Product.total_price = (a[0].Salary * (int)Convert.ToInt64(product_amount.Text)).ToString();
                    purchased_Product.description = " ";
                    purchased_Product.create_date = TimeHelper.GetDateTime().ToString();
                    purchased_Product.update_date = TimeHelper.GetDateTime().ToString();
                    await purchased_ProductsRepository.CreateAsync(purchased_Product);
                    MessageBox.Show("Successfully implemented");
                    this.Close();
                }
            }
            catch 
            {
                    MessageBox.Show("The data was entered incorrectly");
            }


        }
    }
}
