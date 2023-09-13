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

namespace Employee.Components.SalaryWorkerView
{
    /// <summary>
    /// Interaction logic for SalaryWorkerViewUserControl.xaml
    /// </summary>
    public partial class SalaryWorkerViewUserControl : UserControl
    {
        public SalaryWorkerViewUserControl()
        {
            InitializeComponent();
        }


        public void SetDate(WorkerSalaryViewModel workerSalaryViewModel)
        {
            lblname.Content = workerSalaryViewModel.name;
            total.Content = workerSalaryViewModel.sum;
            salary.Content = workerSalaryViewModel.sum * 0.20;
            image.ImageSource = new BitmapImage(new System.Uri(workerSalaryViewModel.image, UriKind.Relative));

        }



    }
}
