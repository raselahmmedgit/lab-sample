using AeonicTech.TestApp.Identity;
using AutoMapper;
using log4net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AeonicTech.TestApp.Controllers
{
    public class HomeController : BaseController
    {
        #region Global Variable Declaration
        private readonly IMapper _iMapper;
        private readonly ILog _log;
        #endregion

        #region Constructor
        public HomeController(IMapper iMapper)
        {
            _iMapper = iMapper;
            _log = LogManager.GetLogger(typeof(HomeController));
        }
        #endregion

        #region Actions

        public IActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        #endregion
    }
}
