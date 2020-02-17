using System.Collections.Generic;
using System.Threading.Tasks;
using ZavenDotNetInterview.App.Repositories;
using ZavenDotNetInterview.Database.Entities;

namespace ZavenDotNetInterview.App.Services
{
    public interface IJobProcessorService
    {
        Task ProcessJobs(IEnumerable<Job> jobsToProcess, IUnitOfWork unitPrimary);
    }
}