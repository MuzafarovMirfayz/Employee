using Employee.Repositories.RankWorker;
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
    /// Interaction logic for RankWorker.xaml
    /// </summary>
    public partial class RankWorker : Page
    {
        public RankWorker()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RankWorkerRepasitory rankWorkerRepasitory = new RankWorkerRepasitory();
            var rank = await rankWorkerRepasitory.GetAllAsync();
            try
            {
                if (rank.Count > 0)
                {
                    one.Visibility = Visibility.Visible;
                    lblnameone.Content = rank[0].name;
                    amountone.Content = rank[0].total;
                    totalone.Content = rank[0].sum;
                    imageone.ImageSource = new BitmapImage(new Uri(rank[0].image, UriKind.Relative));
                }
                
                if (rank.Count > 1)
                {
                    two.Visibility = Visibility.Visible;
                    lblname.Content = rank[1].name;
                    amount.Content = rank[1].total;
                    total.Content = rank[1].sum;
                    image.ImageSource = new BitmapImage(new Uri(rank[1].image, UriKind.Relative));
                }
                
                if(rank.Count > 2)
                {
                    three.Visibility = Visibility.Visible;
                    lblnamethird.Content = rank[2].name;
                    amounthree.Content = rank[2].total;
                    totalthree.Content = rank[2].sum;
                    imagethird.ImageSource = new BitmapImage(new Uri(rank[2].image, UriKind.Relative));
                }

                

            }
            catch 
            {

            }
            
        }


        

    }
}
