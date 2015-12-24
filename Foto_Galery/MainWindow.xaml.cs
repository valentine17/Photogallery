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
//Сonnected library
using System.IO;

namespace Foto_Galery
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string _puth = @"C:\MyGalery";
        static string _Katalog_Users = @"\Users";
        static string _Katalog_Galery = @"\Galery";
        static string _File_users = @"\User_configurations.waccess";

        private static DirectoryInfo dir_1 = new DirectoryInfo(_puth);
        private static FileInfo _file1 = new FileInfo(_puth + _Katalog_Users + _File_users);

        public MainWindow()
        {
            //Initialization programm
            InitializeComponent();
                        
            if (!dir_1.Exists)
            {
                dir_1.Create();
                (dir_1 = new DirectoryInfo(_puth + _Katalog_Users)).Create();

                file1();

                (dir_1 = new DirectoryInfo(_puth + _Katalog_Galery)).Create();
            }
            else
            {
                if (!(dir_1 = new DirectoryInfo(_puth + _Katalog_Users)).Exists)
                {
                    (dir_1 = new DirectoryInfo(_puth + _Katalog_Users)).Create();

                    file1();
                }
                else if (!_file1.Exists) file1();

                if (!(dir_1 = new DirectoryInfo(_puth + _Katalog_Galery)).Exists)
                {
                    (dir_1 = new DirectoryInfo(_puth + _Katalog_Galery)).Create();
                }
            }
        }

        private void file1()
        {
            //Method create "file.waccess"
            string ad = "Admin admin";
            StreamWriter _s_file1 = _file1.CreateText();
            _s_file1.WriteLine(ad);
            _s_file1.Close();
        }

        private void TextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Text_Box "Login"
            login_tb1.Clear();
        }

        private void Close_But2_Click(object sender, RoutedEventArgs e)
        {
            //Button "Close"
            this.Close();
        }

        private void Reg_But3_Click(object sender, RoutedEventArgs e)
        {
            //Button "Reg"
            this.Content = new Page1();
        }

        private void Enter_But1_Click(object sender, RoutedEventArgs e)
        {
            if (_4Box.IsChecked == true)
            {
                StreamReader s = File.OpenText(_puth + _Katalog_Users + _File_users);

                string read = null;
                string[] arr;
                bool b = false;

                while ((read = s.ReadLine()) != null)
                {
                    arr = read.Split(' ');
                    if (arr[0] == login_tb1.Text && arr[1] == PB_1.Password)
                    {
                        this.Content = new Page3();
                        b = true;
                        break;
                    }
                }

                s.Close();

                if (b == false)
                {
                    MessageBox.Show("You registration?", "Error!!!");
                    login_tb1.Clear();
                    PB_1.Clear();
                    _4Box.IsChecked = false;
                }
            }
            else
            {
                MessageBox.Show("You registration?", "Error!!!");
            }
        }
    }
}
