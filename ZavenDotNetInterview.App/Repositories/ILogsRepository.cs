using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZavenDotNetInterview.Database.Entities;

namespace ZavenDotNetInterview.App.Repositories
{
    public interface ILogsRepository
    {
        Task<List<Log>> GetJobsLogs(Guid jobId);

        void InsertLog(Log log);
    }
}
