using RnD.TestSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RnD.TestSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            Profile profile = new Profile();
            return View(profile);
        }

        public ActionResult CreateAjax()
        {
            Profile profile = new Profile();
            return View(profile);
        }

        public ActionResult CreateAjaxValid()
        {
            Profile profile = new Profile();
            return View(profile);
        }

        public ActionResult CreateAjaxWithParial()
        {
            Profile profile = new Profile();
            return View(profile);
        }

        [HttpPost]
        public ActionResult Create(Profile profile)
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAjax(Profile profile)
        {
            return View();
        }

    }
}
