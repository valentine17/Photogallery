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
//
using System.IO;

namespace Foto_Galery
{
    /// <summary>
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        static string puth = @"C:\MyGalery\Galery\";
        string ras = ".jpg";
        int n = 0;

        int col = new DirectoryInfo(puth).GetFiles().Length;

        public Page3()
        {
            InitializeComponent();

            load_img(puth + n.ToString() + ras, 1);
        }

        private void load_img(string img, int znak)
        {
            try
            {
                n = n + znak;
                LB.Content = puth + n.ToString() + ras;

                BitmapImage bm1 = new BitmapImage();

                bm1.BeginInit();
                bm1.UriSource = new Uri(puth + n.ToString() + ras, UriKind.Relative);
                bm1.CacheOption = BitmapCacheOption.OnLoad;
                bm1.EndInit();

                IMG_1.Source = bm1;
            }
            catch
            {

            }

            if (n == col)
            {
                next_1.IsEnabled = false;
                next_all.IsEnabled = false;
            }
            else
            {
                next_1.IsEnabled = true;
                next_all.IsEnabled = true;
            }

            if (n == 1)
            {
                back_1.IsEnabled = false;
                back_all.IsEnabled = false;
            }
            else
            {
                back_1.IsEnabled = true;
                back_all.IsEnabled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //-->
            load_img(puth + n.ToString() + ras, 1);
        }

        private void back_1_Click(object sender, RoutedEventArgs e)
        {
            //<--
            load_img(puth + n.ToString() + ras, -1);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //|<-
            load_img(puth + n.ToString() + ras, -n + 1);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //->|
            load_img(puth + n.ToString() + ras, col - n);
        }


    }
}
