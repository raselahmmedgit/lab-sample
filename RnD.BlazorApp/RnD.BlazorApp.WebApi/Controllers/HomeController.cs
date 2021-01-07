using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RnD.BlazorApp.WebApi.Core;
using RnD.BlazorApp.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RnD.BlazorApp.WebApi.Controllers
{
    public class HomeController : Controller
    {
        #region Global Variable Declaration
        private static readonly ILog _log = LogManager.GetLogger(typeof(HomeController));
        private Result _result = new Result();
        #endregion

        #region Constructor
        public HomeController()
        {
        }
        #endregion

        #region Actions
        public IActionResult Index()
        {
            try
            {
                _log.Info(Log4NetMessageHelper.FormateMessageForStart("Index"));

                return View();
            }
            catch (Exception ex)
            {
                _log.Error(Log4NetMessageHelper.FormateMessageForException(ex, "Index"));
                return View("Error");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
        #endregion
    }
}
