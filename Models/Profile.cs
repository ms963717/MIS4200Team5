using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MIS4200Team5.Models
{
    public class Profile
    {
        
        public Guid ProfileID { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string ProfileFirst { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string ProfileLast { get; set; }
        [Required]
        [DisplayName("Birthday")]
        public DateTime ProfileBday { get; set; }
        [Required]
        [DisplayName("Email")]
        public string ProfileEmail { get; set; }
        [Required]
        [DisplayName("Job Title")]
        public string ProfileJobTitle { get; set; }
        public roles role { get; set; }
        public enum roles
        {
            admin = 0,
                corporate= 1,
                employee= 2,
                nonEmployee = 3


        }
            
        public ICollection<EmployeeQuestions> EmployeeQuestions { get; set; }

    }
}