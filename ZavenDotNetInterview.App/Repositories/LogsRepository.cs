using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ZavenDotNetInterview.Database.Context;
using ZavenDotNetInterview.Database.Entities;

namespace ZavenDotNetInterview.App.Repositories
{
    public class LogsRepository : ILogsRepository
    {
        private readonly ZavenDotNetInterviewContext _context;
        public LogsRepository(ZavenDotNetInterviewContext context)
        {
            _context = context;
        }

        public async Task<List<Log>> GetJobsLogs(Guid jobId)
        {
            return await _context.Logs.Where(x => x.JobId == jobId).ToListAsync();
        }

        public void InsertLog(Log log)
        {
            log.CreationDate = DateTime.UtcNow;
            _context.Logs.Add(log);
                
        }
    }
}