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
    public class BookController : Controller
    {
        private readonly LedgerContext _context;

        public BookController(LedgerContext context)
        {
            _context = context;
        }

        // GET: Book
        public async Task<IActionResult> Index()
        {
            return View(await _context.Book.ToListAsync());
        }

        // GET: Book/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookClass = await _context.Book
                .SingleOrDefaultAsync(m => m.AuthorID == id);
            if (bookClass == null)
            {
                return NotFound();
            }

            return View(bookClass);
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AuthorID,Title,ISBN,PublishDate")] BookClass bookClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookClass);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookClass = await _context.Book.SingleOrDefaultAsync(m => m.AuthorID == id);
            if (bookClass == null)
            {
                return NotFound();
            }
            return View(bookClass);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AuthorID,Title,ISBN,PublishDate")] BookClass bookClass)
        {
            if (id != bookClass.AuthorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookClassExists(bookClass.AuthorID))
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
            return View(bookClass);
        }

        // GET: Book/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookClass = await _context.Book
                .SingleOrDefaultAsync(m => m.AuthorID == id);
            if (bookClass == null)
            {
                return NotFound();
            }

            return View(bookClass);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookClass = await _context.Book.SingleOrDefaultAsync(m => m.AuthorID == id);
            _context.Book.Remove(bookClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookClassExists(int id)
        {
            return _context.Book.Any(e => e.AuthorID == id);
        }
    }
}
