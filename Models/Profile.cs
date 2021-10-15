using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace MIS4200Team5.Models
{
    public class Profile
    {
        
        public int ProfileID { get; set; }
        [DisplayName("First Name")]
        public string ProfileFirst { get; set; }
        [DisplayName("Last Name")]
        public string ProfileLast { get; set; }
        [DisplayName("Birthday")]
        public DateTime ProfileBday { get; set; }
        [DisplayName("Email")]
        public string ProfileEmail { get; set; }
        [DisplayName("Job Title")]
        public string ProfileJobTitle { get; set; }
        public ICollection<EmployeeQuestions> EmployeeQuestions { get; set; }

    }
}