using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ledger.Models;

namespace Ledger.Controllers
{
    public class AuthorController : Controller
    {
        private readonly LedgerContext _context;

        public AuthorController(LedgerContext context)
        {
            _context = context;
        }

        // GET: Author
        public async Task<IActionResult> Index()
        {
            return View(await _context.Author.ToListAsync());
        }

        // GET: Author/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorClass = await _context.Author
                .SingleOrDefaultAsync(m => m.ID == id);
            if (authorClass == null)
            {
                return NotFound();
            }

            return View(authorClass);
        }

        // GET: Author/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName")] AuthorClass authorClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(authorClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(authorClass);
        }

        // GET: Author/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorClass = await _context.Author.SingleOrDefaultAsync(m => m.ID == id);
            if (authorClass == null)
            {
                return NotFound();
            }
            return View(authorClass);
        }

        // POST: Author/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName")] AuthorClass authorClass)
        {
            if (id != authorClass.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authorClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorClassExists(authorClass.ID))
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
            return View(authorClass);
        }

        // GET: Author/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorClass = await _context.Author
                .SingleOrDefaultAsync(m => m.ID == id);
            if (authorClass == null)
            {
                return NotFound();
            }

            return View(authorClass);
        }

        // POST: Author/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var authorClass = await _context.Author.SingleOrDefaultAsync(m => m.ID == id);
            _context.Author.Remove(authorClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorClassExists(int id)
        {
            return _context.Author.Any(e => e.ID == id);
        }
    }
}
