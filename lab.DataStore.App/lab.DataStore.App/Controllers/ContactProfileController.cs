using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab.DataStore.App.EntityModels;
using lab.DataStore.App.Models;
using lab.DataStore.App.DataContext;

namespace lab.DataStore.App.Controllers
{
    public class ContactProfileController : Controller
    {
        private readonly AppDbContext _context;

        public ContactProfileController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ContactProfile
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactProfile.ToListAsync());
        }

        // GET: ContactProfile/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactProfile = await _context.ContactProfile
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactProfile == null)
            {
                return NotFound();
            }

            return View(contactProfile);
        }

        // GET: ContactProfile/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactProfile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,PreferredName,AddressId,PrimaryPassword,IsDeactivated,ProfilePictureId,EmailAllowed,SmsAllowed,RegistrationDate,DateOfBirth,GenderTypeId,IsArchived,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,IsDeleted,DeletedBy,DeletedDate,Id")] ContactProfile contactProfile)
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

        // GET: ContactProfile/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactProfile = await _context.ContactProfile.FindAsync(id);
            if (contactProfile == null)
            {
                return NotFound();
            }
            return View(contactProfile);
        }

        // POST: ContactProfile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("FirstName,LastName,PreferredName,AddressId,PrimaryPassword,IsDeactivated,ProfilePictureId,EmailAllowed,SmsAllowed,RegistrationDate,DateOfBirth,GenderTypeId,IsArchived,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,IsDeleted,DeletedBy,DeletedDate,Id")] ContactProfile contactProfile)
        {
            if (id != contactProfile.Id)
            {
                return NotFound();
            }

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

        // GET: ContactProfile/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactProfile = await _context.ContactProfile
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactProfile == null)
            {
                return NotFound();
            }

            return View(contactProfile);
        }

        // POST: ContactProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var contactProfile = await _context.ContactProfile.FindAsync(id);
            _context.ContactProfile.Remove(contactProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactProfileExists(Guid id)
        {
            return _context.ContactProfile.Any(e => e.Id == id);
        }
    }
}
