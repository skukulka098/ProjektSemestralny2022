//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Jeszczeros
{
    using System;
    using System.Collections.Generic;
    
    public partial class Document
    {
        public int Doc_ID { get; set; }
        public string Doc_Name { get; set; }
        public Nullable<int> Doc_CstID { get; set; }
        public Nullable<decimal> Doc_NetValue { get; set; }
        public Nullable<decimal> Doc_VatValue { get; set; }
        public Nullable<decimal> Doc_GrossValue { get; set; }
        public Nullable<System.DateTime> Doc_DocumentDate { get; set; }
        public Nullable<System.DateTime> Doc_SellDate { get; set; }
        public Nullable<System.DateTime> Doc_PaymentDate { get; set; }
        public Nullable<int> Doc_InsertedBy { get; set; }
        public Nullable<System.DateTime> Doc_InsertDate { get; set; }
    }
}