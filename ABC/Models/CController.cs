using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ABC.Data;

namespace ABC.Models
{
    public class CController : Controller
    {
        private readonly ABCContext _context;

        public CController(ABCContext context)
        {
            _context = context;
        }

        // GET: C
        public async Task<IActionResult> Index()
        {
            var aBCContext = _context.C.Include(c => c.A).Include(c => c.B);
            return View(await aBCContext.ToListAsync());
        }

        // GET: C/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.C == null)
            {
                return NotFound();
            }

            var c = await _context.C
                .Include(c => c.A)
                .Include(c => c.B)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (c == null)
            {
                return NotFound();
            }

            return View(c);
        }

        // GET: C/Create
        public IActionResult Create()
        {
            ViewData["AId"] = new SelectList(_context.A, "Id", "Id");
            ViewData["BId"] = new SelectList(_context.B, "Id", "Id");
            return View();
        }

        // POST: C/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AId,BId")] C c)
        {
            if (ModelState.IsValid)
            {
                _context.Add(c);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AId"] = new SelectList(_context.A, "Id", "Id", c.AId);
            ViewData["BId"] = new SelectList(_context.B, "Id", "Id", c.BId);
            return View(c);
        }

        // GET: C/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.C == null)
            {
                return NotFound();
            }

            var c = await _context.C.FindAsync(id);
            if (c == null)
            {
                return NotFound();
            }
            ViewData["AId"] = new SelectList(_context.A, "Id", "Id", c.AId);
            ViewData["BId"] = new SelectList(_context.B, "Id", "Id", c.BId);
            return View(c);
        }

        // POST: C/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AId,BId")] C c)
        {
            if (id != c.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(c);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CExists(c.Id))
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
            ViewData["AId"] = new SelectList(_context.A, "Id", "Id", c.AId);
            ViewData["BId"] = new SelectList(_context.B, "Id", "Id", c.BId);
            return View(c);
        }

        // GET: C/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.C == null)
            {
                return NotFound();
            }

            var c = await _context.C
                .Include(c => c.A)
                .Include(c => c.B)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (c == null)
            {
                return NotFound();
            }

            return View(c);
        }

        // POST: C/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.C == null)
            {
                return Problem("Entity set 'ABCContext.C'  is null.");
            }
            var c = await _context.C.FindAsync(id);
            if (c != null)
            {
                _context.C.Remove(c);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CExists(int id)
        {
          return (_context.C?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
