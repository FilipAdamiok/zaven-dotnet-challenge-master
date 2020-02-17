using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ZavenDotNetInterview.App.Extensions;
using ZavenDotNetInterview.App.Repositories;
using ZavenDotNetInterview.Database.Context;
using ZavenDotNetInterview.Database.Entities;

namespace ZavenDotNetInterview.App.Services
{
    public class JobProcessorService : IJobProcessorService
    {


        public async Task ProcessJobs(IEnumerable<Job> jobsToProcess, IUnitOfWork unitPrimary)
        {

            Parallel.ForEach(jobsToProcess, (currentJob) =>
        {
            new Task(async () =>
            {
                using (var _unitOfWork = new UnitOfWork(new ZavenDotNetInterviewContext()))
                {
                    _unitOfWork.Jobs().AttachJob(currentJob);

                    await ChangeStatusToInProcessAndLogBehaviour(currentJob, _unitOfWork);

                    bool result = await ProcessJob(currentJob);
                    if (result)
                    {
                        await ChangeStatusToDoneAndLogBehaviour(currentJob, _unitOfWork);

                    }
                    else if (currentJob.FailureCount < 4)
                    {

                        await ChangeStatusToFailedAndLogBehaviour(currentJob, _unitOfWork);

                    }
                    else
                    {
                        await ChangeStatusToClosedAndLogBehaviour(currentJob, _unitOfWork);
                    }

                    _unitOfWork.Dispose();

                }
            }).Start();
        });
            


        }

        private async Task ChangeStatusToClosedAndLogBehaviour(Job currentJob, IUnitOfWork _unitOfWork)
        {
            currentJob.FailureCount++;
            currentJob.ChangeStatus(JobStatus.Closed);

            Log log = new Log
            {
                Id = Guid.NewGuid(),
                JobId = currentJob.Id,
                Description = "Status of job '" + currentJob.Name + "' has been changed to  Closed"
            };


            await AddLogAndCommitChanges(currentJob, log, _unitOfWork);
        }

        private async Task ChangeStatusToDoneAndLogBehaviour(Job currentJob, IUnitOfWork _unitOfWork)
        {
            currentJob.ChangeStatus(JobStatus.Done);

            Log log = new Log
            {
                Id = Guid.NewGuid(),
                JobId = currentJob.Id,
                Description = "Status of job '" + currentJob.Name + "' has been changed to  Done"
            };

            await AddLogAndCommitChanges(currentJob, log, _unitOfWork);
        }

        private async Task ChangeStatusToFailedAndLogBehaviour(Job currentJob, IUnitOfWork _unitOfWork)
        {
            currentJob.FailureCount++;
            currentJob.ChangeStatus(JobStatus.Failed);
            
            Log log = new Log
            {
                Id = Guid.NewGuid(),
                JobId = currentJob.Id,
                Description = "Status of job '" + currentJob.Name + "' has been changed to Failed"
            };

            await AddLogAndCommitChanges(currentJob, log, _unitOfWork);
        }

        private async Task ChangeStatusToInProcessAndLogBehaviour(Job currentJob, IUnitOfWork _unitOfWork)
        {
            currentJob.ChangeStatus(JobStatus.InProgress);
            
            Log log = new Log
            {
                Id = Guid.NewGuid(),
                JobId = currentJob.Id,
                Description = "Status of job '" + currentJob.Name + "' has been changed to  InProgress"
            };
           await AddLogAndCommitChanges(currentJob,log, _unitOfWork);
            
        }



        private async Task<bool> ProcessJob(Job job)
        {
            Random rand = new Random();
            int random = rand.Next(10);
            if (random < 5)
            {
                await Task.Delay(2000);
                return false;
            }
            else
            {
                await Task.Delay(1000);
                return true;
            }
        }


        private async Task AddLogAndCommitChanges(Job currentJob, Log log, IUnitOfWork _unitOfWork)
        {
            currentJob.ChangeLastUpdatedDate();
           _unitOfWork.Logs().InsertLog(log);
            await _unitOfWork.CommitAsync();
        }

    }
}