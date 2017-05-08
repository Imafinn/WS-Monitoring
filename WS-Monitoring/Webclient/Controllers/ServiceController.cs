using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webclient.Helper;

namespace Webclient.Controllers
{
    public class ServiceController : Controller
    {
        private IServiceRepo _repo;

        public ServiceController()
        {
            _repo = new ServiceRepoFake();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_repo.GetAll());
        }

        [HttpGet]
        public ActionResult Start(int id)
        {
            _repo.Start(id);

            return RedirectToAction("Index", "Service");
        }

        [HttpGet]
        public ActionResult Stop(int id)
        {
            _repo.Stop(id);

            return RedirectToAction("Index", "Service");
        }

        [HttpGet]
        public ActionResult Restart(int id)
        {
            _repo.Restart(id);

            return RedirectToAction("Index", "Service");
        }
    }
}
