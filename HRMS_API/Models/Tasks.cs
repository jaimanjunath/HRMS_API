using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS_API.Models
{
    public class Tasks
    {
        public Tasks()
        {
            this.Taskslist = new HashSet<Tasks>();
        }

        public int ID { get; set; }
        public string TASK_ID { get; set; }
        public string TASK_SUMMARY { get; set; }
        public string TASK_DESC { get; set; }
        public string TASK_TYPE { get; set; }
        public string PRIORITY { get; set; }
        public int PROJECT_ID { get; set; }
        public string PROJECT { get; set; }
        public int ESTIMATED_HOURS { get; set; }
        public System.DateTime START_DATE { get; set; }
        public Nullable<System.DateTime> END_DATE { get; set; }
        public Nullable<System.DateTime> DUE_DATE { get; set; }
        public int ASSIGNED_EMP { get; set; }
        public string  ASSIGNED { get; set; }
        public Nullable<int> CREATEDBY { get; set; }
        public Nullable<System.DateTime> CREATEDON { get; set; }
        public Nullable<int> UPDATEDBY { get; set; }
        public Nullable<System.DateTime> UPDATEDON { get; set; }
        public string STATUS { get; set; }


        public virtual ICollection<Tasks> Taskslist { get; set; }
    }
}