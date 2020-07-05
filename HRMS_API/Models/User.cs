using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS_API.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string USER_NAME { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
        public int EMP_ID { get; set; }
        public string PHONE_NUMBER { get; set; }      
        public string STATUS { get; set; }
        public string ROLE { get; set; }
    }
}