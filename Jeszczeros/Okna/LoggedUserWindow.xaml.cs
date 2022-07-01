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


namespace ProjektSemestralnyWPF_Workflow
{
   
    public partial class LoggedUserWindow : Window
    {
        public LoggedUserWindow() 
        {
            InitializeComponent();
            WorkflowEntities db = new WorkflowEntities();

          

            var docs = from d in db.Documents
                       
                       select new {
                           ID = d.Doc_ID,
                           NumerDokumentu = d.Doc_Name,
                           IDKontrahenta = d.Doc_CstID,
                           DataDokumentu = d.Doc_DocumentDate
            };
           

            gridDocuments.ItemsSource = docs.ToList();

        }
        
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void Addbtn_click(object sender, RoutedEventArgs e)
        {

            

            AddDocumentPage oknododawania = new AddDocumentPage();
            oknododawania.Show();

        

           

        }
        private void Loadbtn_click(object sender, RoutedEventArgs e)
        {
            WorkflowEntities db = new WorkflowEntities();
            var querry2 = from d in db.Documents
                          
                          select new { 
                          ID = d.Doc_ID,
                          NumerDokumentu = d.Doc_Name,
                          IDKontrahenta = d.Doc_CstID,
                          DataSprzedazy = d.Doc_SellDate,
                          DataDokumentu = d.Doc_DocumentDate,
                          DataPlatnosci = d.Doc_PaymentDate};
            
            gridDocuments.ItemsSource = querry2.ToList();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("Wylogowano");
            Application.Current.Shutdown();
        }

        private void Close_button(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

     
    }
}
