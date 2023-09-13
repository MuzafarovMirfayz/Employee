using Employee.Components.ClientsView;
using Employee.Components.WorkersView;
using Employee.FileJson;
using Employee.Repositories.Clients;
using Employee.Repositories.Workers;
using  Employee.Windows.ClientsWindow;
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
    /// Interaction logic for Clients.xaml
    /// </summary>
    public partial class Clients : Page
    {

        ClientsRepository clientsRepository = new ClientsRepository();
        public Clients()
        {
            InitializeComponent();
        }


        public async  Task RefreshAsync()
        {
            wrpClient.Children.Clear();
            MethodJson.Clear();

            var workers = await clientsRepository.GetAllAsync();

            foreach (var worker in workers)
            {
                ClientsUserControl workerUserControl = new ClientsUserControl();
                workerUserControl.SetDate(worker);
                wrpClient.Children.Add(workerUserControl);
            }
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await RefreshAsync();
        }

        private async void btncreate_Click(object sender, RoutedEventArgs e)
        {
            ClientsWindow clientsWindow = new ClientsWindow();
            clientsWindow.ShowDialog();
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
                var clients = await clientsRepository.SearchAsync(tbSearch.Text);
                wrpClient.Children.Clear();
                foreach (var client in clients)
                {
                    ClientsUserControl clientsUserControl = new ClientsUserControl();
                    clientsUserControl.SetDate(client);
                    wrpClient.Children.Add(clientsUserControl);
                }
            }
        }

        

    }
}
