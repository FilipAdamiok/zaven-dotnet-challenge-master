using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.ModelBinding;
using ZavenDotNetInterview.App.Models;
using ZavenDotNetInterview.App.Repositories;

namespace ZavenDotNetInterview.App.Services
{
    public class JobValidator : IJobValidate
    {
        private readonly IJobsRepository _jobsRepository;
        public JobValidator(JobsRepository jobsRepository)
        {
            _jobsRepository = jobsRepository;
        }

        public async Task<bool> JobValidate(JobViewModel job)
        {
            if(job.Name.Trim() == "" || job.Name == null)
            {
                job.ErrorMessageName = "Name can not be empty.";
                return false;
            }
            var allJobList = await _jobsRepository.GetAllJobs();
            if(allJobList.Count(x=>x.Name == job.Name) > 0)
            {
                job.ErrorMessageName = "Job name must be unique.";
                return false;
            }


            return true;
        }
    }
}