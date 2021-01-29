using CityGlassCompany.WebSite.Core;
using CityGlassCompany.WebSite.Helper;
using CityGlassCompany.WebSite.Helpers;
using CityGlassCompany.WebSite.Managers;
using CityGlassCompany.WebSite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CityGlassCompany.WebSite.Controllers
{
    public class HomeController : BaseController
    {
        #region Global Variable Declaration
        private readonly ILogger<HomeController> _logger;
        private static IEmailSenderManager _iEmailSenderManager;
        private readonly IWebHostEnvironment _environment;
        #endregion

        #region Constructor
        public HomeController(ILogger<HomeController> logger, IEmailSenderManager iEmailSenderManager, IWebHostEnvironment environment)
        {
            _iEmailSenderManager = iEmailSenderManager;
            _logger = logger;
            _environment = environment;
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
                _logger.LogError(LoggerMessageHelper.FormateMessageForException(ex, "Index"));
                return ErrorView(ex);
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Route("SendContactMessage")]
        public async Task<IActionResult> SendContactMessage(ContactSendMessageViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var emailSentResult = await _iEmailSenderManager.ContactSendEmailToAdmin(model);
                    if (emailSentResult.Success)
                    {
                        _result = Result.Ok(MessageHelper.SentMessage);
                    }
                    else
                    {
                        _result = Result.Fail(MessageHelper.SentMessageFail);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggerMessageHelper.FormateMessageForException(ex, "SendContactMessage"));
                _result = Result.Fail(MessageHelper.SentMessageFail);
            }
            var json = new { success = _result.Success, errortype = _result.ErrorType, error = _result.Error };
            return new JsonResult(json);
        }


        #region Residential

        [Route("Residential")]
        [HttpGet]
        public IActionResult Residential()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggerMessageHelper.FormateMessageForException(ex, "Residential"));
                return ErrorView(ex);
            }
        }

        [Route("Flat-Glass-Plastics")]
        [HttpGet]
        public IActionResult FlatGlassPlastics()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggerMessageHelper.FormateMessageForException(ex, "FlatGlassPlastics"));
                return ErrorView(ex);
            }
        }

        [Route("Mirrors-Shower-Doors")]
        [HttpGet]
        public IActionResult MirrorsShowerDoors()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggerMessageHelper.FormateMessageForException(ex, "MirrorsShowerDoors"));
                return ErrorView(ex);
            }
        }

        [Route("Screens")]
        [HttpGet]
        public IActionResult Screens()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggerMessageHelper.FormateMessageForException(ex, "Screens"));
                return ErrorView(ex);
            }
        }

        [Route("Windows-Doors")]
        [HttpGet]
        public IActionResult WindowsDoors()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggerMessageHelper.FormateMessageForException(ex, "WindowsDoors"));
                return ErrorView(ex);
            }
        }

        [Route("Services")]
        [HttpGet]
        public IActionResult Services()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggerMessageHelper.FormateMessageForException(ex, "Services"));
                return ErrorView(ex);
            }
        }

        #endregion

        #region Commercial

        [Route("Commercial")]
        [HttpGet]
        public IActionResult Commercial()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggerMessageHelper.FormateMessageForException(ex, "Commercial"));
                return ErrorView(ex);
            }
        }

        [Route("New-Construction")]
        [HttpGet]
        public IActionResult NewConstruction()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggerMessageHelper.FormateMessageForException(ex, "NewConstruction"));
                return ErrorView(ex);
            }
        }

        [Route("Repair-Replace")]
        [HttpGet]
        public IActionResult RepairReplace()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggerMessageHelper.FormateMessageForException(ex, "RepairReplace"));
                return ErrorView(ex);
            }
        }

        #endregion

        [Route("About")]
        [HttpGet]
        public IActionResult About()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggerMessageHelper.FormateMessageForException(ex, "About"));
                return ErrorView(ex);
            }
        }

        [Route("Contact")]
        [HttpGet]
        public IActionResult Contact()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggerMessageHelper.FormateMessageForException(ex, "Contact"));
                return ErrorView(ex);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}
