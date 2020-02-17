using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZavenDotNetInterview.App.Models;
using ZavenDotNetInterview.Database.Entities;

namespace ZavenDotNetInterview.App.Services
{
    public interface IJobTools
    {
        Task<bool> ValidateModel(JobViewModel jobViewModel);
        Task<List<Job>> GetAllJobs();
        Task AddJobAndLogsToDatabase(Job job);

        Task<Job> GetJobDetails(Guid jobId);

        Task ProcessJobs();

    }
}
