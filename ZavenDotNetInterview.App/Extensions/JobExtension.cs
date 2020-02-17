using System;
using ZavenDotNetInterview.Database.Entities;

namespace ZavenDotNetInterview.App.Extensions
{
    internal static class JobExtension
    {
        public static void ChangeStatus(this Job job, JobStatus newStatus)
        {
            job.Status = newStatus;
        }

        public static void ChangeLastUpdatedDate(this Job job)
        {
            job.LastUpdatedDate = DateTime.Now;
        }
    }
}