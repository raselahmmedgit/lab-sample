using AeonicTech.TestApp.Exceptions;
using AeonicTech.TestApp.Helpers;
using AeonicTech.TestApp.Managers;
using AeonicTech.TestApp.ViewModels;
using AutoMapper;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AeonicTech.TestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AddressApiController : ControllerBase
    {
        #region Global Variable Declaration
        private readonly IMapper _iMapper;
        private readonly IAddressManager _iAddressManager;
        private readonly ILog _log;
        #endregion

        #region Constructor
        public AddressApiController(IAddressManager iAddressManager
            , IMapper iMapper
        )
        {
            _iAddressManager = iAddressManager;
            _iMapper = iMapper;
            _log = LogManager.GetLogger(typeof(AddressController));
        }
        #endregion

        #region Actions

        [HttpGet]
        [Route("GetAllAddress")]
        public async Task<IActionResult> GetAllAddress()
        {
            try
            {
                _log.Info(LogMessageHelper.FormateMessageForStart("GetAllAddress[GET]"));

                var response = await _iAddressManager.GetAddressEntitysAsync();

                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "GetAllAddress[GET]"));
            }

            return BadRequest(MessageHelper.NullReferenceExceptionError);
        }

        [HttpGet]
        [Route("GetAddress")]
        public async Task<IActionResult> GetAddress(int id)
        {
            try
            {
                _log.Info(LogMessageHelper.FormateMessageForStart("GetAddress[GET]"));

                var response = await _iAddressManager.GetAddressEntityAsync(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "GetAddress[GET]"));
            }

            return BadRequest(MessageHelper.NullReferenceExceptionError);
        }

        [HttpPost]
        [Route("SaveAddress")]
        public async Task<IActionResult> SaveAddress(AddressEntityViewModel viewModel)
        {
            Result result = new Result();
            try
            {
                _log.Info(LogMessageHelper.FormateMessageForStart("AddAddress[POST]"));

                if (ModelState.IsValid)
                {
                    //add
                    if (viewModel.AddressId == 0)
                    {
                        result = await _iAddressManager.InsertAddressEntityAsync(viewModel);
                    }
                    else if (viewModel.AddressId > 0) //edit
                    {
                        result = await _iAddressManager.UpdateAddressEntityAsync(viewModel);
                    }

                    if (result.Success)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return BadRequest(result);
                    }
                }
                else
                {
                    var modelStateError = ExceptionHelper.ModelStateErrorFirstFormat(ModelState);
                    result = Result.Fail(modelStateError);
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "AddAddress[POST]"));
            }

            return BadRequest(MessageHelper.NullReferenceExceptionError);
        }

        [HttpPost]
        [Route("DeleteAddress")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            Result result = new Result();
            try
            {
                _log.Info(LogMessageHelper.FormateMessageForStart("DeleteAddress[POST]"));

                if (id > 0)
                {
                    result = await _iAddressManager.DeleteAddressEntityAsync(id);
                }
                else
                {
                    result = Result.Fail(MessageHelper.DeleteFail);
                }

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "DeleteAddress[POST]"));
                result = Result.Fail(MessageHelper.UnhandelledError);
                return BadRequest(result);
            }

            return BadRequest(MessageHelper.NullReferenceExceptionError);
        }

        [HttpGet]
        [Route("GetAllCountry")]
        public async Task<IActionResult> GetAllCountry()
        {
            try
            {
                _log.Info(LogMessageHelper.FormateMessageForStart("GetAllCountry[GET]"));

                var response = await _iAddressManager.GetCountryEntitysAsync();

                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "GetAllCountry[GET]"));
            }

            return BadRequest(MessageHelper.NullReferenceExceptionError);
        }

        [HttpGet]
        [Route("GetAllState")]
        public async Task<IActionResult> GetAllState()
        {
            try
            {
                _log.Info(LogMessageHelper.FormateMessageForStart("GetAllState[GET]"));

                var response = await _iAddressManager.GetStateEntitysAsync();

                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "GetAllState[GET]"));
            }

            return BadRequest(MessageHelper.NullReferenceExceptionError);
        }

        #endregion
    }
}
