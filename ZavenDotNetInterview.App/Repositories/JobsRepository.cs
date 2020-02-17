using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ZavenDotNetInterview.Database.Context;
using ZavenDotNetInterview.Database.Entities;

namespace ZavenDotNetInterview.App.Repositories
{
    public class JobsRepository : IJobsRepository
    {
        private readonly ZavenDotNetInterviewContext _context;

        public JobsRepository(ZavenDotNetInterviewContext ctx)
        {
            _context = ctx;
        }

        public void AddJob(Job newJob)
        {
            _context.Jobs.Add(newJob);

        }

        public void UpdateJob(Job newJob)
        {
            _context.Entry(newJob).Reload();

        }

        public void AttachJob(Job job)
        {
            _context.Jobs.Attach(job);
        }


        public async Task<List<Job>> GetAllJobs()
        {
            var allListJob = await _context.Jobs.ToListAsync();
            allListJob.ForEach(x => _context.Entry(x).Reload());
            return allListJob;
        }


        public Job GetJob(Guid jobId)
        {
            return _context.Jobs.Find(jobId);
        }

        public async Task<List<Job>> GetNewAndFailedAvailableJobs()
        {
            var jobList = await _context.Jobs.Where(x => (x.Status == JobStatus.New || x.Status == JobStatus.Failed) && (x.StartDateOfJobProcess <= DateTime.Now || x.StartDateOfJobProcess == null)).AsNoTracking().ToListAsync();
          
            return jobList;
        }

    }
}