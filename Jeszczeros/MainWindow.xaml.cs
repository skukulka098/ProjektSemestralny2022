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

namespace Jeszczeros
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void UserCheck()
        {
            WorkflowEntities db = new WorkflowEntities();

            var querry1 = from u in db.Users
                          where u.Usr_Login == Login.Text && u.Usr_PWD == txt_pass.Password
                          select u;

            if (querry1.Count() == 1)
            {
                MessageBox.Show("Zalogowano");
                WPF_1_coś objokno = new WPF_1_coś();
                this.Visibility = Visibility.Hidden;
                objokno.Show();
            }
            else
            {
                MessageBox.Show("Nie prawidłowy login lub hasło");
            }
            
        }

        private void Zaloguj_click(object sender, RoutedEventArgs e)
        {

            UserCheck();


        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                UserCheck();
               

            }
        }
    }
}
