//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HMSWpfApplication
{
    using System;
    using System.Collections.ObjectModel;
    
    public partial class Bill
    {
        public int BillID { get; set; }
        public string Description { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateDue { get; set; }
        public decimal Amount { get; set; }
        public decimal Amt_Paid { get; set; }
        public decimal Balance { get; set; }
        public int PatientID { get; set; }
        public string Remark { get; set; }
    
        public virtual Patient Patient { get; set; }
    }
}
