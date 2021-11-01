using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MIS4200Team5.Models
{
    public class CVRecognition
    {
        public int CVRecognitionID { get; set; }
        [DisplayName("Commitment to Delivering Excellence")]
        public int CV1 { get; set; }
        [DisplayName("Embrace Integrity and Openness")]
        public int CV2 { get; set; }
        [DisplayName("Practice Responsible Stewardship")]
        public int CV3 { get; set; }
        [DisplayName("Invest in an Exceptional Culture")]
        public int CV4 { get; set; }
        [DisplayName("Ignite Passion for the Greater Good")]
        public int CV5 { get; set; }
        [DisplayName("Strive to Innovate")]
        public int CV6 { get; set; }
        [DisplayName("Live a balanced life")]
        public int CV7 { get; set; }

        public virtual Profile Profile { get; set; }


    }
}