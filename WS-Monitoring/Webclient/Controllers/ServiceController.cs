using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webclient.Helper;

namespace Webclient.Controllers
{
    /// <summary>
    /// Controller is responsible for the view Index.cshtml
    /// </summary>
    public class ServiceController : Controller
    {
        /// <summary>
        /// The ServiceRepository executes the different actions with services.
        /// </summary>
        private IServiceRepo _repo;

        /// <summary>
        /// Constructor initalizes the ServiceRepository.
        /// </summary>
        public ServiceController()
        {
            _repo = new ServiceRepo();
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

        /// <summary>
        /// Starts a service and refreshes the view.
        /// </summary>
        /// <param name="id">Id of the associated service.</param>
        /// <returns>Returns the Index.cshtml</returns>
        [HttpGet]
        public ActionResult Start(int id)
        {
            _repo.Start(id);

            return RedirectToAction("Index", "Service");
        }

        /// <summary>
        /// Stops a service and refreshes the view
        /// </summary>
        /// <param name="id">Id of the associated service.</param>
        /// <returns>Returns the Index.cshtml</returns>
        [HttpGet]
        public ActionResult Stop(int id)
        {
            _repo.Stop(id);

            return RedirectToAction("Index", "Service");
        }

        /// <summary>
        /// Restarts a service and refreshes the view.
        /// </summary>
        /// <param name="id">Id of the associated service.</param>
        /// <returns>Returns the Index.cshtml</returns>
        [HttpGet]
        public ActionResult Restart(int id)
        {
            _repo.Restart(id);

            return RedirectToAction("Index", "Service");
        }
    }
}
