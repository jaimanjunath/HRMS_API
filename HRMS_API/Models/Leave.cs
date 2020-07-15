using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS_API.Models
{
    public class Leave
    {
        public Leave()
        {
            this.Leavelist = new HashSet<Leave>();

        }

        public int ID { get; set; }
        public int EMP_ID { get; set; }
        public string EMP_Name{ get; set; }
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

        public virtual ICollection<Leave> Leavelist { get; set; }
    }
}