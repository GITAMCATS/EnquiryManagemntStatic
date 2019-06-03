using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo1.Models
{
    public class Enquiry
    {
        public int Id { get; set; }
        public string EmailId { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Designation { get; set; }
        public string LeadCategory { get; set; }
        public string Comments { get; set; }

        public bool DoNotCall { get; set; }
        public bool Enabled { get; set; }

     
    }

   
}