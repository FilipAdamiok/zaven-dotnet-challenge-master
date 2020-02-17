using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZavenDotNetInterview.Database.Entities
{
    public class Job
    {
        [Key]
        public Guid Id { get; set; }

         [Required]
        public string Name { get; set; }
        public JobStatus Status { get; set; }
        public DateTime? StartDateOfJobProcess { get; set; }

        public DateTime? LastUpdatedDate { get; set; }

        public DateTime CreationDate { get; set; }

        public int FailureCount { get; set; }
        public virtual List<Log> Logs { get; set; }
    }

    public enum JobStatus
    {
        Closed = -2,
        Failed = -1,
        New = 0,
        InProgress = 1,
        Done = 2
    }
}