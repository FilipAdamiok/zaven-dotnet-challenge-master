using System;
using ZavenDotNetInterview.App.Models;
using ZavenDotNetInterview.Database.Entities;

namespace ZavenDotNetInterview.App.Statics
{
    public static class JobCreator
    {
        public static Job CreateJob(JobViewModel jobViewModel)
        {
            Job newJob = new Job
            {
                Name = jobViewModel.Name,
                StartDateOfJobProcess = jobViewModel.StartDateOfJobProcess,
                Status = JobStatus.New,
                FailureCount = 0,
                LastUpdatedDate = DateTime.Now,
                CreationDate = DateTime.Now
            };
            return newJob;
        }
    }
}