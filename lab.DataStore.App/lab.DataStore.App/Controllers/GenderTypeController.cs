using lab.DataStore.App.DataContext;
using lab.DataStore.App.EntityModels.Type;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace lab.DataStore.App.Controllers
{
    public class GenderTypeController : Controller
    {
        private readonly AppDbContext _context;

        public GenderTypeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: GenderType
        public async Task<IActionResult> Index()
        {
            return View(await _context.GenderType.ToListAsync());
        }

        // GET: GenderType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genderType = await _context.GenderType
                .FirstOrDefaultAsync(m => m.TypeId == id);
            if (genderType == null)
            {
                return NotFound();
            }

            return View(genderType);
        }

        // GET: GenderType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GenderType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeId,TypeName")] GenderType genderType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genderType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genderType);
        }

        // GET: GenderType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genderType = await _context.GenderType.FindAsync(id);
            if (genderType == null)
            {
                return NotFound();
            }
            return View(genderType);
        }

        // POST: GenderType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeId,TypeName")] GenderType genderType)
        {
            if (id != genderType.TypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genderType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenderTypeExists(genderType.TypeId))
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
            return View(genderType);
        }

        // GET: GenderType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genderType = await _context.GenderType
                .FirstOrDefaultAsync(m => m.TypeId == id);
            if (genderType == null)
            {
                return NotFound();
            }

            return View(genderType);
        }

        // POST: GenderType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genderType = await _context.GenderType.FindAsync(id);
            _context.GenderType.Remove(genderType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenderTypeExists(int id)
        {
            return _context.GenderType.Any(e => e.TypeId == id);
        }
    }
}
