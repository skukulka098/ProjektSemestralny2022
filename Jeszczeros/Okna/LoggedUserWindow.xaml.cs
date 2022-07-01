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
                       from t in db.Tasks
                       where d.Doc_ID == t.Tsk_DocID
                       select new { 
            t.Tsk_DocID,d.Doc_ID,d.Doc_Name,d.Doc_CstID,d.Doc_DocumentDate
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

            WorkflowEntities db = new WorkflowEntities();

            Document documentObject = new Document()
            {
                Doc_Name = NrDok.Text,
                Doc_NetValue = 32,
                Doc_GrossValue=53,
                Doc_VatValue=21,
                Doc_SellDate= DataSprzed.SelectedDate,
                Doc_PaymentDate= DataPlat.SelectedDate,
                Doc_InsertedBy=1,
                Doc_InsertDate= DateTime.Now,
                Doc_CstID = Convert.ToInt32(CstText.Text),
                Doc_DocumentDate = (DateTime)DataDok.SelectedDate
            };

            db.Documents.Add(documentObject);
            db.SaveChanges();

        }
        private void Loadbtn_click(object sender, RoutedEventArgs e)
        {
            WorkflowEntities db = new WorkflowEntities();

            
            gridDocuments.ItemsSource = db.Documents.ToList();
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

        private void gridDocuments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
