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
    
    public partial class tblTask
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblTask()
        {
            this.tblTaskHistories = new HashSet<tblTaskHistory>();
        }
    
        public int ID { get; set; }
        public string TASK_ID { get; set; }
        public string TASK_SUMMARY { get; set; }
        public string TASK_DESC { get; set; }
        public string TASK_TYPE { get; set; }
        public string PRIORITY { get; set; }
        public int PROJECT_ID { get; set; }
        public int ESTIMATED_HOURS { get; set; }
        public System.DateTime START_DATE { get; set; }
        public System.DateTime END_DATE { get; set; }
        public System.DateTime DUE_DATE { get; set; }
        public int ASSIGNED_EMP { get; set; }
        public Nullable<int> CREATEDBY { get; set; }
        public Nullable<System.DateTime> CREATEDON { get; set; }
        public Nullable<int> UPDATEDBY { get; set; }
        public Nullable<System.DateTime> UPDATEDON { get; set; }
        public string STATUS { get; set; }
    
        public virtual tblProject tblProject { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblTaskHistory> tblTaskHistories { get; set; }
        public virtual tblEmployee tblEmployee { get; set; }
    }
}