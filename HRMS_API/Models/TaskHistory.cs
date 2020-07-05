using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS_API.Models
{
    public class TaskHistory
    {
        public TaskHistory()
        {
            this.TaskHistoryList = new HashSet<TaskHistory>();
        }

        public int ID { get; set; }
        public string TASK_COMMENTS { get; set; }
        public int TASK_ID { get; set; }
        public Nullable<int> CREATEDBY { get; set; }
        public string CREATEDBY_NAME { get; set; }
        public Nullable<System.DateTime> CREATEDON { get; set; }        
        public Nullable<int> UPDATEDBY { get; set; }
        public string UPDATEDBY_NAME { get; set; }
        public Nullable<System.DateTime> UPDATEDON { get; set; }
        public string STATUS { get; set; }

        public virtual ICollection<TaskHistory> TaskHistoryList { get; set; }
    }
    
}