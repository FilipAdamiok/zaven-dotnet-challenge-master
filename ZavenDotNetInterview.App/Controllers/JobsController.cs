using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ZavenDotNetInterview.App.Models;
using ZavenDotNetInterview.App.Services;
using ZavenDotNetInterview.App.Statics;

namespace ZavenDotNetInterview.App.Controllers
{
    public class JobsController : Controller
    {

        private readonly IJobTools _jobTools;
        public JobsController(JobTools jobTools)
        {
            _jobTools = jobTools;

        }

        // GET: Tasks
        public async Task<ActionResult> Index()
        {
            var listOfJobs = await _jobTools.GetAllJobs();

            return View(listOfJobs.OrderBy(x=>x.CreationDate).ToList());
        }

        // POST: Tasks/Process
        [HttpGet]
        public async Task<ActionResult> Process()
        {
          await  _jobTools.ProcessJobs();

            return RedirectToAction("Index");
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            
            return View(new JobViewModel { ErrorMessageDate ="", ErrorMessageName=""});
        }

        // POST: Tasks/Create
        [HttpPost]
        public async Task<ActionResult> Create(JobViewModel jobViewModel)
        {
            if (await _jobTools.ValidateModel(jobViewModel))
            {
                try
                {

                  await  _jobTools.AddJobAndLogsToDatabase(JobCreator.CreateJob(jobViewModel));

                    return RedirectToAction("Index");
                }
                catch (SqlException ex) //tutaj cos musisz zrobic
                {
                    return View();
                }
            }
            return View(jobViewModel);
        }

        public async Task<ActionResult> Details(Guid jobId)
        {

            return View(await _jobTools.GetJobDetails(jobId));
        }
    }
}
