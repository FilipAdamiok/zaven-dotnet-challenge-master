using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZavenDotNetInterview.Database.Entities
{
    public class Log
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid JobId { get; set; }
        public virtual Job Job { get; set; }
    }
}