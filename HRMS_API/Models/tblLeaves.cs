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
    
    public partial class tblLeaves
    {
        public int ID { get; set; }
        public int EMP_ID { get; set; }
        public string LEAVE_TYPE { get; set; }
        public string LEAVE_STATUS { get; set; }
        public System.DateTime START_DATE { get; set; }
        public System.DateTime END_DATE { get; set; }
        public string IS_HALFDAY { get; set; }
        public string REMARK { get; set; }
        public double NUMBER_DAYS { get; set; }
        public Nullable<int> CREATEDBY { get; set; }
        public Nullable<System.DateTime> CREATEDON { get; set; }
        public Nullable<int> UPDATEDBY { get; set; }
        public Nullable<System.DateTime> UPDATEDON { get; set; }
        public string STATUS { get; set; }
    }
}
