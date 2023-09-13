using Employee.Entities.Clients;
using Employee.FileJson;
using Employee.Pages;
using Employee.Repositories.Clients;
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

namespace Employee.Components.ClientsView
{
    /// <summary>
    /// Interaction logic for ClientsUserControl.xaml
    /// </summary>
    public partial class ClientsUserControl : UserControl
    {
        public ClientsUserControl()
        {
            InitializeComponent();
        }

        

        public void SetDate(Client client)
        {
            id.Content = client.id;
            lblname.Content = client.first_name;
            lbllastname.Content = client.last_name;
            lblpasport.Content = client.email;
            lblnumber.Content = client.number;
            lbltime.Content = client.create_date;
            lbldes.Content = client.description;
        }



        public void showdes_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(lbldes.Content.ToString());
        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            ClientsRepository clientsRepository = new ClientsRepository();
            await clientsRepository.DeleteAsync((int)Convert.ToInt64(id.Content));
            
           ((MainWindow)System.Windows.Application.Current.MainWindow).btnClient_Click(sender, e);
        }
       

    }
}
