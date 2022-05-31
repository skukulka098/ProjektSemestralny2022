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
   
    public partial class WPF_1_coś : Window
    {
        public WPF_1_coś()
        {
            InitializeComponent();

            WorkflowEntities db = new WorkflowEntities();
            var docs = from d in db.Documents
                       select d;

            foreach (var item in docs)
            {

                Console.WriteLine(item.Doc_ID);
                Console.WriteLine(item.Doc_Name);
                Console.WriteLine(item.Doc_CstID);
                Console.WriteLine(item.Doc_DocumentDate);
            }
            gridDocuments.ItemsSource = docs.ToList();

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
                Doc_InsertDate= Convert.ToDateTime(DataDok),
                Doc_SellDate= Convert.ToDateTime(DataSprzed),
                Doc_PaymentDate= Convert.ToDateTime(DataPlat),
                Doc_InsertedBy=1,
                Doc_CstID = Convert.ToInt32(CstText.Text),
                Doc_DocumentDate = Convert.ToDateTime(DataDok)
            };

            db.Documents.Add(documentObject);
            db.SaveChanges();

        }
        private void Loadbtn_click(object sender, RoutedEventArgs e)
        {
            WorkflowEntities db = new WorkflowEntities();

            gridDocuments.ItemsSource = db.Documents.ToList();
        }
    }
}
