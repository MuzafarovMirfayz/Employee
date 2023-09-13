using Employee.Constants;
using Employee.Entities.Products;
using Employee.Helpers;
using Employee.Repositories.Products;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
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
    /// Interaction logic for ProductCreateWindow.xaml
    /// </summary>
    public partial class ProductCreateWindow : Window
    {
        public ProductCreateWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (name.Text == string.Empty || Convert.ToString(salary.Text) == string.Empty)
                {
                    MessageBox.Show("Please enter complete information");
                }
                else
                {
                    var read = new TextRange(desription.Document.ContentStart, desription.Document.ContentEnd);
                    Product product = new Product();
                    product.name = name.Text;
                    product.price = ((int)Convert.ToInt64(salary.Text)).ToString();
                    product.description = read.Text;
                    product.create_date = TimeHelper.GetDateTime().ToString();
                    product.update_date = TimeHelper.GetDateTime().ToString();

                    string imagepath = ImgBImage.ImageSource.ToString();
                    if (!String.IsNullOrEmpty(imagepath))
                        product.image = await CopyImageAsync(imagepath,
                            ContentConstants.IMAGE_CONTENTS_PATH);


                    ProductsRepository productsRepository = new ProductsRepository();
                    await productsRepository.CreateAsync(product);
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Please enter complete information");

            }
        }

        private void btnFile_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = GetImageDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string imgPath = openFileDialog.FileName;
                ImgBImage.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
            }
        }


        private OpenFileDialog GetImageDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif";
            return openFileDialog;
        }



        private async Task<string> CopyImageAsync(string imgPath, string destinationDirectory)
        {
            if (!Directory.Exists(destinationDirectory))
                Directory.CreateDirectory(destinationDirectory);

            var imageName = ContentNameMaker.GetImageName(imgPath);

            string path = System.IO.Path.Combine(destinationDirectory, imageName);

            byte[] image = await File.ReadAllBytesAsync(imgPath);

            await File.WriteAllBytesAsync(path, image);

            return path;
        }






    }
}
