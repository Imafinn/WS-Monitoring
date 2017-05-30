using Newtonsoft.Json;
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
        /// <summary>
        /// Updates the performance from time to time.
        /// </summary>
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
    }
}
