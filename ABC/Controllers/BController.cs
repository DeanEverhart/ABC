using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ABC.Data;
using ABC.Models;

namespace ABC.Controllers
{
    public class BController : Controller
    {
        private readonly ABCContext _context;

        public BController(ABCContext context)
        {
            _context = context;
        }

        // GET: B
        public async Task<IActionResult> Index()
        {
              return _context.B != null ? 
                          View(await _context.B.ToListAsync()) :
                          Problem("Entity set 'ABCContext.B'  is null.");
        }

        // GET: B/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.B == null)
            {
                return NotFound();
            }

            var b = await _context.B
                .FirstOrDefaultAsync(m => m.Id == id);
            if (b == null)
            {
                return NotFound();
            }

            return View(b);
        }

        // GET: B/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: B/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,One,Two,Three")] B b)
        {
            if (ModelState.IsValid)
            {
                _context.Add(b);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(b);
        }

        // GET: B/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.B == null)
            {
                return NotFound();
            }

            var b = await _context.B.FindAsync(id);
            if (b == null)
            {
                return NotFound();
            }
            return View(b);
        }

        // POST: B/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,One,Two,Three")] B b)
        {
            if (id != b.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(b);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BExists(b.Id))
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
            return View(b);
        }

        // GET: B/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.B == null)
            {
                return NotFound();
            }

            var b = await _context.B
                .FirstOrDefaultAsync(m => m.Id == id);
            if (b == null)
            {
                return NotFound();
            }

            return View(b);
        }

        // POST: B/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.B == null)
            {
                return Problem("Entity set 'ABCContext.B'  is null.");
            }
            var b = await _context.B.FindAsync(id);
            if (b != null)
            {
                _context.B.Remove(b);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BExists(int id)
        {
          return (_context.B?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
