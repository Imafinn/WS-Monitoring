﻿using Newtonsoft.Json;
using Ninject;
using Ninject.Parameters;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Webclient.Helper;

namespace Webclient.Controllers
{
    /// <summary>
    /// Controller is responsible for the view Index.cshtml
    /// </summary>
    public class ServiceMonitorController : Controller
    {
        /// <summary>
        /// The ServiceRepository executes the different actions with services.
        /// </summary>
        private IServiceRepo _repo;
        private IPerformanceTimer _performanceTimer;

        /// <summary>
        /// Constructor initalizes the ServiceRepository.
        /// </summary>
        public ServiceMonitorController()
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            _repo = kernel.Get<IServiceRepo>();
            _performanceTimer = kernel.Get<IPerformanceTimer>( new ConstructorArgument("list", _repo.GetAll()));
        }

        /// <summary>
        /// Receives a list of all available services and gives them back with the view.
        /// </summary>
        /// <returns>Returns the Index.cshtml view with a list of all available services.</returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View(_repo.GetAll());
        }

        [HttpGet]
        public string GetServiceById(int id)
        {
            return JsonConvert.SerializeObject(_repo.GetServiceById(id));
        }

        // Start, Stop & Restart Methods aren't used anymore. This calls will be done by JS(SignalR).

        ///// <summary>
        ///// Starts a service and refreshes the view.
        ///// </summary>
        ///// <param name="id">Id of the associated service.</param>
        ///// <returns>Returns the Index.cshtml</returns>
        //[HttpGet]
        //public ActionResult Start(int id, string name)
        //{
        //    _repo.Start(id, name);

        //    return RedirectToAction("Index", "ServiceMonitor");
        //}

        ///// <summary>
        ///// Stops a service and refreshes the view
        ///// </summary>
        ///// <param name="id">Id of the associated service.</param>
        ///// <returns>Returns the Index.cshtml</returns>
        //[HttpGet]
        //public ActionResult Stop(int id, string name)
        //{
        //    _repo.Stop(id, name);

        //    return RedirectToAction("Index", "ServiceMonitor");
        //}

        ///// <summary>
        ///// Restarts a service and refreshes the view.
        ///// </summary>
        ///// <param name="id">Id of the associated service.</param>
        ///// <returns>Returns the Index.cshtml</returns>
        //[HttpGet]
        //public ActionResult Restart(int id, string name)
        //{
        //    _repo.Restart(id, name);

        //    return RedirectToAction("Index", "ServiceMonitor");
        //}
    }
}
