using System;
using System.Threading.Tasks;
using ZavenDotNetInterview.Database.Context;

namespace ZavenDotNetInterview.App.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ZavenDotNetInterviewContext _context;
        private ILogsRepository _logsRepository;
        private IJobsRepository _jobsRepository;


        public UnitOfWork(ZavenDotNetInterviewContext context)
        {
            _context = context;
            _logsRepository = new LogsRepository(context);
            _jobsRepository = new JobsRepository(context);
        }

        public IJobsRepository Jobs()
        {
            return _jobsRepository;
        }

        public ILogsRepository Logs()
        {
            return _logsRepository;
        }

        public async Task CommitAsync()
        {
            bool changesMade = _context.ChangeTracker.HasChanges();
            await _context.SaveChangesAsync();
        }
      

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Commit()
        {
            bool changesMade = _context.ChangeTracker.HasChanges();
            _context.SaveChanges();
        }
    }
}