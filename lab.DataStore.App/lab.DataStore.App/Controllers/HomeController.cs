using lab.DataStore.App.Helper;
using lab.DataStore.App.Helpers;
using lab.DataStore.App.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace lab.DataStore.App.Controllers
{
    public class HomeController : Controller
    {
        #region Global Variable Declaration
        private readonly ILogger<HomeController> _logger;
        private readonly DhtmlxSchedulerHelper _dhtmlxSchedulerHelper;
        #endregion

        #region Constructor
        public HomeController(ILogger<HomeController> logger, IHostingEnvironment iHostingEnvironment)
        {
            _logger = logger;
            _logger.LogInformation("AddressTypeController instance created...");
            _dhtmlxSchedulerHelper = new DhtmlxSchedulerHelper(iHostingEnvironment);
        }
        #endregion

        #region Actions
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Angular()
        {
            return View();
        }

        public IActionResult React()
        {
            return View();
        }

        public IActionResult Vue()
        {
            return View();
        }

        public IActionResult DhtmlxScheduler()
        {
            return View();
        }

        public IActionResult TheThirdMeal()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetDhtmlxScheduler()
        {
            try
            {
                var data = _dhtmlxSchedulerHelper.GetDhtmlxSchedulerData();
                return Json(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(Log4NetMessageHelper.FormateMessageForException(ex, "GetDhtmlxSchedulerAsync"));
            }

            return Json(null);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}
