//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HRMS_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblTaskHistory
    {
        public int ID { get; set; }
        public string TASK_COMMENTS { get; set; }
        public int TASK_ID { get; set; }
        public Nullable<int> CREATEDBY { get; set; }
        public Nullable<System.DateTime> CREATEDON { get; set; }
        public Nullable<int> UPDATEDBY { get; set; }
        public Nullable<System.DateTime> UPDATEDON { get; set; }
        public string STATUS { get; set; }
    
        public virtual tblTask tblTask { get; set; }
    }
}
