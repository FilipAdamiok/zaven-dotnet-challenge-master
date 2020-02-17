using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZavenDotNetInterview.App.Models;
using ZavenDotNetInterview.App.Repositories;
using ZavenDotNetInterview.Database.Entities;

namespace ZavenDotNetInterview.App.Services
{
    public class JobTools : IJobTools
    {
        private readonly  IJobProcessorService _jobProcessorService;
        private readonly IUnitOfWork _unitOFWork;
        private readonly IJobValidate _jobValidate;

        public JobTools(JobProcessorService jobProcessorService, UnitOfWork unitOFWork, JobValidator jobValidate)
        {
            _jobProcessorService = jobProcessorService;
            _unitOFWork = unitOFWork;
            _jobValidate = jobValidate;
        }

        public async Task AddJobAndLogsToDatabase(Job job)
        {
            job.Id = Guid.NewGuid();
            _unitOFWork.Jobs().AddJob(job);

            Log log = new Log
            {
                Id = Guid.NewGuid(),
                JobId = job.Id,
                Description = "Job " + job.Name + " has been created"
            };

             _unitOFWork.Logs().InsertLog(log);

            await _unitOFWork.CommitAsync();
        }

        public async Task<List<Job>> GetAllJobs()
        {
            return await _unitOFWork.Jobs().GetAllJobs();
        }

        public  async Task<Job> GetJobDetails(Guid jobId)
        {
            Job job = _unitOFWork.Jobs().GetJob(jobId);
            List<Log> logs = await _unitOFWork.Logs().GetJobsLogs(jobId);
            job.Logs = logs.OrderBy(x=>x.CreationDate).ToList();
            return job;
        }

        public async  Task ProcessJobs()
        {
            var jobList = await _unitOFWork.Jobs().GetNewAndFailedAvailableJobs();
           await _jobProcessorService.ProcessJobs(jobList, _unitOFWork);
        }

        public  async Task<bool> ValidateModel(JobViewModel jobViewModel)
        {

            return await _jobValidate.JobValidate(jobViewModel);
        }
    }
}