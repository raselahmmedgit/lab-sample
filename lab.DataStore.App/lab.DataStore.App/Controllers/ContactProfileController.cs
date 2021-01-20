using AutoMapper;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using lab.DataStore.App.Core;
using lab.DataStore.App.DataContext;
using lab.DataStore.App.EntityModels;
using lab.DataStore.App.Helpers;
using lab.DataStore.App.Managers;
using lab.DataStore.App.PageViewModels;
using lab.DataStore.App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace lab.DataStore.App.Controllers
{
    public class ContactProfileController : BaseController
    {
        #region Global Variable Declaration
        private readonly ILogger<ContactProfileController> _logger;
        private readonly IMapper _iMapper;
        private readonly IContactProfileManager _iContactProfileManager;
        private readonly IAddressTypeManager _iAddressTypeManager;
        private readonly AppDbContext _context;
        #endregion

        #region Constructor
        public ContactProfileController(ILogger<ContactProfileController> logger
            , IMapper iMapper
            , IContactProfileManager iContactProfileManager
            , IAddressTypeManager iAddressTypeManager
            , AppDbContext context)
        {
            _logger = logger;
            _logger.LogInformation("ContactProfileController instance created...");
            _iMapper = iMapper;
            _iContactProfileManager = iContactProfileManager;
            _iAddressTypeManager = iAddressTypeManager;
            _context = context;
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

        public async Task<IActionResult> GetDataAsync(IDataTablesRequest request)
        {
            try
            {
                DataTablesResponse response = await _iContactProfileManager.GetDataTablesResponseAsync(request);
                return new DataTablesJsonResult(response, true);
            }
            catch (Exception ex)
            {
                return ErrorPartialView(ex);
            }
        }

        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var contactProfileViewModel = await _iContactProfileManager.GetContactProfileAsync(id);
                var model = _iMapper.Map<ContactProfileViewModel, ContactProfilePageViewModel>(contactProfileViewModel);

                if (model != null)
                {
                    return View(model);
                }
                else
                {
                    return ErrorView(ExceptionHelper.ExceptionErrorMessageForNullObject());
                }
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        public IActionResult Create()
        {
            try
            {
                var model = new ContactProfilePageViewModel();
                return View(model);
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,PreferredName,AddressId,PrimaryPassword,IsDeactivated,ProfilePictureId,EmailAllowed,SmsAllowed,RegistrationDate,DateOfBirth,GenderTypeId,IsArchived,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,IsDeleted,DeletedBy,DeletedDate,Id")] ContactProfile contactProfile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contactProfile.Id = Guid.NewGuid();
                    _context.Add(contactProfile);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(contactProfile);
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var contactProfileViewModel = await _iContactProfileManager.GetContactProfileAsync(id);
                var model = _iMapper.Map<ContactProfileViewModel, ContactProfilePageViewModel>(contactProfileViewModel);

                if (model != null)
                {
                    return View(model);
                }
                else
                {
                    return ErrorView(ExceptionHelper.ExceptionErrorMessageForNullObject());
                }
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("FirstName,LastName,PreferredName,AddressId,PrimaryPassword,IsDeactivated,ProfilePictureId,EmailAllowed,SmsAllowed,RegistrationDate,DateOfBirth,GenderTypeId,IsArchived,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,IsDeleted,DeletedBy,DeletedDate,Id")] ContactProfile contactProfile)
        {
            try
            {
                var contactProfileViewModel = await _iContactProfileManager.GetContactProfileAsync(id);
                var model = _iMapper.Map<ContactProfileViewModel, ContactProfilePageViewModel>(contactProfileViewModel);

                if (id == contactProfile.Id)
                {
                    if (ModelState.IsValid)
                    {
                        try
                        {
                            _context.Update(contactProfile);
                            await _context.SaveChangesAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!ContactProfileExists(contactProfile.Id))
                            {
                                return NotFound();
                            }
                            else
                            {
                                throw;
                            }
                        }
                        return RedirectToAction(nameof(Index));
                    }
                    return View(contactProfile);
                }
                else
                {
                    return ErrorView(ExceptionHelper.ExceptionErrorMessageForNullObject());
                }
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (id != null || id != Guid.Empty)
                {
                    _result = await _iContactProfileManager.DeleteContactProfileAsync(id);
                }
                else
                {
                    _result = Result.Fail(MessageHelper.DeleteFail);
                }

                return JsonResult(_result);
            }
            catch (Exception ex)
            {
                return JsonResult(ex);
            }
        }

        private bool ContactProfileExists(Guid id)
        {
            return _context.ContactProfile.Any(e => e.Id == id);
        }

        #endregion
    }
}
