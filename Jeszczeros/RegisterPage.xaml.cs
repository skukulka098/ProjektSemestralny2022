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
using System.Windows.Shapes;

namespace Jeszczeros
{
    /// <summary>
    /// Logika interakcji dla klasy RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Window
    {
      
        public RegisterPage()
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
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Escape)
            {
                this.Visibility = Visibility.Hidden;
            }
        }

        private void Close_button(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WorkflowEntities db = new WorkflowEntities();

            User userObject = new User()
            {
                Usr_Name = nametxt.Text,
                Usr_Surname = surnametxt.Text,
                Usr_Email = emailtxt.Text,
                Usr_isAdmin = (bool)isadminbit.IsChecked,
                Usr_Login = loginreg.Text,
                Usr_PWD = passwdreg.Password,
                Usr_InsertDate = DateTime.Now
            };
            db.Users.Add(userObject);
            db.SaveChanges();

            MessageBox.Show("Zarejestrowano, " + loginreg.Text + " Zaloguj się");

            this.Visibility = Visibility.Hidden;
        }


    }
}
