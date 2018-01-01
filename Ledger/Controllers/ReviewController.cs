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
    public class ReviewController : Controller
    {
        private readonly LedgerContext _context;

        public ReviewController(LedgerContext context)
        {
            _context = context;
        }

        // GET: Review
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reveiw.ToListAsync());
        }

        // GET: Review/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewClass = await _context.Reveiw
                .SingleOrDefaultAsync(m => m.BookID == id);
            if (reviewClass == null)
            {
                return NotFound();
            }

            return View(reviewClass);
        }

        // GET: Review/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Review/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,BookID")] ReviewClass reviewClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reviewClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reviewClass);
        }

        // GET: Review/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewClass = await _context.Reveiw.SingleOrDefaultAsync(m => m.BookID == id);
            if (reviewClass == null)
            {
                return NotFound();
            }
            return View(reviewClass);
        }

        // POST: Review/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,BookID")] ReviewClass reviewClass)
        {
            if (id != reviewClass.BookID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reviewClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewClassExists(reviewClass.BookID))
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
            return View(reviewClass);
        }

        // GET: Review/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewClass = await _context.Reveiw
                .SingleOrDefaultAsync(m => m.BookID == id);
            if (reviewClass == null)
            {
                return NotFound();
            }

            return View(reviewClass);
        }

        // POST: Review/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reviewClass = await _context.Reveiw.SingleOrDefaultAsync(m => m.BookID == id);
            _context.Reveiw.Remove(reviewClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewClassExists(int id)
        {
            return _context.Reveiw.Any(e => e.BookID == id);
        }
    }
}
