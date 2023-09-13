using Employee.Components.SalaryWorkerView;
using Employee.Components.WorkersView;
using Employee.FileJson;
using Employee.Repositories.Salary;
using Employee.Repositories.Workers;
using Employee.ViewModels.WorkerSalary;
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
    /// Interaction logic for WorkerSalary.xaml
    /// </summary>
    public partial class WorkerSalary : Page
    {
        WorkerSalaryRepasitory workerSalary = new WorkerSalaryRepasitory();
        public WorkerSalary()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await RefreshAsync();
        }

        public async Task RefreshAsync()
        {
            wrpsalary.Children.Clear();

            var salary = await workerSalary.GetAllAsync();

            foreach (var item in salary)
            {
                SalaryWorkerViewUserControl workerUserControl = new SalaryWorkerViewUserControl();
                workerUserControl.SetDate(item);
                wrpsalary.Children.Add(workerUserControl);
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
                var salary = await workerSalary.SearchAsync(tbSearch.Text);
                wrpsalary.Children.Clear();
                foreach (var item in salary)
                {
                    SalaryWorkerViewUserControl workerUserControl = new SalaryWorkerViewUserControl();
                    workerUserControl.SetDate(item);
                    wrpsalary.Children.Add(workerUserControl);
                }
            }
        }
    }
}
