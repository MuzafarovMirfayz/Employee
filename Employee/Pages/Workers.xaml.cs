using Employee.Components.WorkersView;
using Employee.Entities.Workers;
using Employee.FileJson;
using Employee.Repositories.Workers;
using Employee.Windows.WorkesWindow;
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
    /// Interaction logic for Workers.xaml
    /// </summary>
    public partial class Workers : Page
    {
        WorkersRepository _workersRepository = new WorkersRepository();
        public Workers()
        {
            InitializeComponent();
        }


        public async Task RefreshAsync()
        {
            wrpWorker.Children.Clear();
            MethodJson.Clear();

            var workers = await _workersRepository.GetAllAsync();

            foreach (var worker in workers)
            {
                WorkerUserControl workerUserControl = new WorkerUserControl();
                workerUserControl.SetDate(worker);
                wrpWorker.Children.Add(workerUserControl);
            }


        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await RefreshAsync();
        }

        private async void btncreate_Click(object sender, RoutedEventArgs e)
        {
            WorkerCreateWindow workerCreateWindow = new WorkerCreateWindow();
            workerCreateWindow.ShowDialog();
            await RefreshAsync();
        }

        

        private async void btnsearch_Click(object sender, RoutedEventArgs e)
        {
            if(tbSearch.Text == string.Empty)
            {
                await RefreshAsync();
            }
            else
            {
                MethodJson.Clear();
                WorkersRepository _workersRepository = new WorkersRepository();
                var workers = await _workersRepository.SearchAsync(tbSearch.Text);
                wrpWorker.Children.Clear();
                foreach (var worker in workers)
                {
                    WorkerUserControl workerUserControl = new WorkerUserControl();
                    workerUserControl.SetDate(worker);
                    wrpWorker.Children.Add(workerUserControl);
                }
            }
           
        }
    }
}
