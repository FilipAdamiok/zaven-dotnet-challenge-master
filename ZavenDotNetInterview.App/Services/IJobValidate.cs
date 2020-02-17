using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using ZavenDotNetInterview.App.Models;

namespace ZavenDotNetInterview.App.Services
{
    public interface IJobValidate
    {
        Task<bool> JobValidate(JobViewModel job);
    }
}
