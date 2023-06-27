using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITTyping.Data;
using ITTyping.Models;

namespace ITTyping.Controllers
{
    public class TypistsController : Controller
    {
        private readonly ITTypingContext _context;

        public TypistsController(ITTypingContext context)
        {
            _context = context;
        }

        // GET: Typists
        public async Task<IActionResult> Index()
        {
              return _context.Typist != null ? 
                          View(await _context.Typist.ToListAsync()) :
                          Problem("Entity set 'ITTypingContext.Typist'  is null.");
        }

        // GET: Typists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Typist == null)
            {
                return NotFound();
            }

            var typist = await _context.Typist
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typist == null)
            {
                return NotFound();
            }

            return View(typist);
        }

        // GET: Typists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Typists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Password,FirstName,LastName,TypingPackage,PriceDue,LastPurchaseDate")] Typist typist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typist);
        }

        // GET: Typists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Typist == null)
            {
                return NotFound();
            }

            var typist = await _context.Typist.FindAsync(id);
            if (typist == null)
            {
                return NotFound();
            }
            return View(typist);
        }

        // POST: Typists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Password,FirstName,LastName,TypingPackage,PriceDue,LastPurchaseDate")] Typist typist)
        {
            if (id != typist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypistExists(typist.Id))
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
            return View(typist);
        }

        // GET: Typists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Typist == null)
            {
                return NotFound();
            }

            var typist = await _context.Typist
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typist == null)
            {
                return NotFound();
            }

            return View(typist);
        }

        // POST: Typists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Typist == null)
            {
                return Problem("Entity set 'ITTypingContext.Typist'  is null.");
            }
            var typist = await _context.Typist.FindAsync(id);
            if (typist != null)
            {
                _context.Typist.Remove(typist);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypistExists(int id)
        {
          return (_context.Typist?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
