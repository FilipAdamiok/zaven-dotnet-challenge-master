using System.Data.Entity;
using ZavenDotNetInterview.Database.Entities;

namespace ZavenDotNetInterview.Database.Context
{
    public class ZavenDotNetInterviewContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Log> Logs { get; set; }

        public ZavenDotNetInterviewContext() : base("name=ZavenDotNetInterview")
        {
        }
    }
}