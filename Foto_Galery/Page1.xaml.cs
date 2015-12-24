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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        static string puth = @"C:\MyGalery\Users\User_configurations.waccess";

        public Page1()
        {
            InitializeComponent();

            shtrihkod();
        }

        private void shtrihkod()
        {
            //Method random code
            Code_LB.Content = "";
            string[] abc = new string[62] { "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", 
                "a", "s", "d", "f", "g", "h", "j", "k", "l", "z", "x", "c", "v", 
                "b", "n", "m", "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", 
                "A", "S", "D", "F", "G", "H", "J", "K", "L", "Z", "X", "C", "V", 
                "B", "N", "M", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};

            Random r1 = new Random();

            for (int i = 0; i < 6; i++)
            {
                Code_LB.Content += abc[r1.Next(0, 62)];
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Reset code
            shtrihkod();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Button "Exit"
            Application app = Application.Current;
            app.Shutdown();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Button "Registred"
            
                if (Code_LB.Content.ToString() == Code_TB.Text && !String.IsNullOrEmpty(Log_TB.Text) && !String.IsNullOrEmpty(Pass_TB.Text))
                {
                    bool _1 = false;
                    bool _2 = false;

                    for (int i = 0; i < Log_TB.Text.Length; i++)
                    {
                        if (Log_TB.Text[i] == ' ')
                        {
                            not();
                            _1 = !_1;
                            break;
                        }
                    }

                    if (_1 != !_1)
                    {
                        for (int i = 0; i < Pass_TB.Text.Length; i++)
                        {
                            if (Pass_TB.Text[i] == ' ')
                            {
                                not();
                                _2 = !_2;
                                break;
                            }
                        }

                        if (_1 == _2 && _1 != true)
                        {
                            FileInfo _Plus_User = new FileInfo(puth);
                            StreamWriter stream = _Plus_User.AppendText();
                            stream.WriteLine(Log_TB.Text + " " + Pass_TB.Text);
                            stream.Close();

                            Log_TB.Clear();
                            Pass_TB.Clear();
                            Code_TB.Clear();
                            Code_LB.Content = "------";

                            Enebl();

                            MessageBox.Show("Registration comleted!", "Supper!!!");
                        }
                    }
                }
                else
                {
                    not();
                }            
        }

        private void not()
        {
            MessageBox.Show("You have entered the wrong data, " +
                    "username or password, or the barcode", "Error!");

            Log_TB.Clear();
            Pass_TB.Clear();
            Code_TB.Clear();

            shtrihkod();
        }

        private void Enebl()
        {
            Log_LB.IsEnabled = false;
            Log_TB.IsEnabled = false;
            Pass_LB.IsEnabled = false;
            Pass_TB.IsEnabled = false;
            Code_LB.IsEnabled = false;
            Code_TB.IsEnabled = false;
            Obnov.IsEnabled = false;
            Reg_But.IsEnabled = false;
        }
    }
}
