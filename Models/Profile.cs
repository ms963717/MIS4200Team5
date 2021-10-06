using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS4200Team5.Models
{
    public class Profile
    {
        public int ProfileID { get; set; }
        public string ProfileFirst { get; set; }
        public string ProfileLast { get; set; }
        public DateTime ProfileBday { get; set; }
        public string ProfileEmail { get; set; }
        public string ProfileJobTitle { get; set; }
        
    }
}