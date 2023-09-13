using Employee.Entities.Clients;
using Employee.Entities.Workers;
using Employee.Helpers;
using Employee.Repositories.Clients;
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

namespace Employee.Windows.ClientsWindow
{
    /// <summary>
    /// Interaction logic for ClientsWindow.xaml
    /// </summary>
    public partial class ClientsWindow : Window
    {
        public ClientsWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (name.Text == string.Empty || number.Text == string.Empty || lastname.Text == string.Empty || email.Text == string.Empty)
                {
                    MessageBox.Show("Please enter complete information");
                }
                else
                {
                    var read = new TextRange(desription.Document.ContentStart, desription.Document.ContentEnd);
                    Client client = new Client();
                    client.first_name = name.Text;
                    client.last_name = lastname.Text;
                    client.number = "+998" + ((int)Convert.ToInt64(number.Text)).ToString();
                    client.description = read.Text;
                    client.email = email.Text + "@gmail.com";
                    client.create_date = TimeHelper.GetDateTime().ToString();
                    client.update_date = TimeHelper.GetDateTime().ToString();
                    ClientsRepository clientsRepository = new ClientsRepository();
                    await clientsRepository.CreateAsync(client);
                    this.Close();
                }

            }
            catch 
            {
                MessageBox.Show("Please enter complete information");
            }


        }
    }
}
