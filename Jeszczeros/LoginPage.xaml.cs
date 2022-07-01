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
    /// Logika interakcji dla klasy LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
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
                LoggedUserWindow zalogowanyokno = new LoggedUserWindow();
                this.Visibility = Visibility.Hidden;
                zalogowanyokno.Show();
              

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
        private void Reje_click(object sender,RoutedEventArgs e)
        {
            RegisterPage rejestracjaokno = new RegisterPage();
            //this.Visibility = Visibility.Hidden;
            rejestracjaokno.Show();
        }
       
        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                UserCheck();

            }
            if (e.Key == Key.Escape)
            {
                Application.Current.Shutdown();
            }
        }

        private void Close_button(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
