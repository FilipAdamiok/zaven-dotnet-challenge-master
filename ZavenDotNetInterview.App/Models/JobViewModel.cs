using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZavenDotNetInterview.App.Models
{
    public class JobViewModel
    {
        public string Name { get; set; }

        public string ErrorMessageName { get; set; }

        public string ErrorMessageDate { get; set; }
        public DateTime? StartDateOfJobProcess { get; set; }


    }
}