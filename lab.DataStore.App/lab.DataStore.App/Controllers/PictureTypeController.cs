using lab.DataStore.App.DataContext;
using lab.DataStore.App.EntityModels.Type;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace lab.DataStore.App.Controllers
{
    public class PictureTypeController : Controller
    {
        private readonly AppDbContext _context;

        public PictureTypeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PictureType
        public async Task<IActionResult> Index()
        {
            return View(await _context.PictureType.ToListAsync());
        }

        // GET: PictureType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pictureType = await _context.PictureType
                .FirstOrDefaultAsync(m => m.TypeId == id);
            if (pictureType == null)
            {
                return NotFound();
            }

            return View(pictureType);
        }

        // GET: PictureType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PictureType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeId,TypeName")] PictureType pictureType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pictureType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pictureType);
        }

        // GET: PictureType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pictureType = await _context.PictureType.FindAsync(id);
            if (pictureType == null)
            {
                return NotFound();
            }
            return View(pictureType);
        }

        // POST: PictureType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeId,TypeName")] PictureType pictureType)
        {
            if (id != pictureType.TypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pictureType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PictureTypeExists(pictureType.TypeId))
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
            return View(pictureType);
        }

        // GET: PictureType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pictureType = await _context.PictureType
                .FirstOrDefaultAsync(m => m.TypeId == id);
            if (pictureType == null)
            {
                return NotFound();
            }

            return View(pictureType);
        }

        // POST: PictureType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pictureType = await _context.PictureType.FindAsync(id);
            _context.PictureType.Remove(pictureType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PictureTypeExists(int id)
        {
            return _context.PictureType.Any(e => e.TypeId == id);
        }
    }
}
