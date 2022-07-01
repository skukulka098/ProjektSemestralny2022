﻿using System;
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
    /// <summary>
    /// Logika interakcji dla klasy AddDocumentPage.xaml
    /// </summary>
    public partial class AddDocumentPage : Window
    {
        public AddDocumentPage()
        {
            InitializeComponent();
            KontrahenciCombo();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }

        }

        private void Close_button(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
       public List<Customer> cst { get; set; }

        private void KontrahenciCombo()
        {
            WorkflowEntities iwf = new WorkflowEntities();
            var item = iwf.Customers.ToList();
            cst = item;
            DataContext = cst;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = ComboCST.SelectedItem as Customer;
            MessageBox.Show(item.Cst_ID.ToString());
        }

  

        private void AddDoc_Button(object sender, RoutedEventArgs e)
        {
            WorkflowEntities db = new WorkflowEntities();
            var item = ComboCST.SelectedItem as Customer;

            Document documentObject = new Document()
            {
                Doc_Name = NrDok.Text,
                Doc_NetValue = 32,
                Doc_GrossValue = 53,
                Doc_VatValue = 21,
                Doc_SellDate = DataSprzed.SelectedDate,
                Doc_PaymentDate = DataPlat.SelectedDate,
                Doc_InsertedBy = 1,
                Doc_InsertDate = DateTime.Now,
                Doc_CstID = Convert.ToInt32(item),
                Doc_DocumentDate = (DateTime)DataDok.SelectedDate
            };

            db.Documents.Add(documentObject);
            db.SaveChanges();
        }
    }
}
