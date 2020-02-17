using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZavenDotNetInterview.Database.Entities;

namespace ZavenDotNetInterview.App.Repositories
{
    public interface IJobsRepository
    {
        Task<List<Job>> GetAllJobs();

        void AddJob(Job newJob);

        Job GetJob(Guid jobId);

        void AttachJob(Job job);

        void UpdateJob(Job newJob);

        Task<List<Job>> GetNewAndFailedAvailableJobs();

    }
}