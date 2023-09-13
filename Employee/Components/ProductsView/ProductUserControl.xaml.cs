using Employee.Entities.Products;
using Employee.FileJson.SalaryJson;
using Employee.Repositories.Products;
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

namespace Employee.Components.ProductsView
{
    /// <summary>
    /// Interaction logic for ProductUserControl.xaml
    /// </summary>
    public partial class ProductUserControl : UserControl
    {
        public ProductUserControl()
        {
            InitializeComponent();
        }


        public void SetDate(Product product)
        {
            id.Content = product.id;
            lblname.Content = product.name;
            lblsalary.Content = product.price.ToString();
            image.ImageSource = new BitmapImage(new System.Uri(product.image, UriKind.Relative));
            string v = product.description.ToString();
            txtdes.Document.Blocks.Add(new Paragraph(new Run(v)));

        }






        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            ProductShopWindow productShopWindow = new ProductShopWindow();
            SalaryJsonMethod.Clear();
            SalaryJsonMethod.ForAdd((int)Convert.ToInt64(id.Content), (int)Convert.ToInt64(lblsalary.Content));
            productShopWindow.ShowDialog();
        }

        private async void deletebtn_Click(object sender, RoutedEventArgs e)
        {
            ProductsRepository productsRepository = new ProductsRepository();
            await productsRepository.DeleteAsync((int)Convert.ToInt64(id.Content));
            ((MainWindow)System.Windows.Application.Current.MainWindow).btnProduct_Click(sender, e);

        }

    }
}
