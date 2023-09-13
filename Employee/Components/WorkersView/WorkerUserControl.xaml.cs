using Employee.Entities.Workers;
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

namespace Employee.Components.WorkersView
{
    /// <summary>
    /// Interaction logic for WorkerUserControl.xaml
    /// </summary>
    public partial class WorkerUserControl : UserControl
    {
        public WorkerUserControl()
        {
            InitializeComponent();
        }


        public void SetDate(Worker worker)
        {
            id.Content = worker.id;
            lblname.Content = worker.first_name;
            lbllastname.Content = worker.last_name;
            lblpasport.Content = worker.passport_seria;
            lblnumber.Content = worker.number;
            lbltime.Content = worker.create_date;
            lbldes.Content = worker.description;
            image.ImageSource = new BitmapImage(new System.Uri(worker.image, UriKind.Relative));
        }



        private void showdes_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(lbldes.Content.ToString());
        }

        private async void deletebtn_Click(object sender, RoutedEventArgs e)
        {
            WorkersRepository workersRepository = new WorkersRepository();
            await workersRepository.DeleteAsync((int)Convert.ToInt64(id.Content));
            ((MainWindow)System.Windows.Application.Current.MainWindow).btnWorker_Click(sender, e);
        }



    }
}
