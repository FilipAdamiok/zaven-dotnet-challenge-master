using System.Threading.Tasks;

namespace ZavenDotNetInterview.App.Repositories
{
    public interface IUnitOfWork
    {
        IJobsRepository Jobs();
        ILogsRepository Logs();
        Task CommitAsync();
        void Commit();
    }
}
