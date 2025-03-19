using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GamerInfoApp.Data;
using GamerInfoApp.Models;

namespace GamerInfoApp.Controllers
{
    public class GamersController : Controller
    {
        private readonly GamerInfoAppContext _context;

        public GamersController(GamerInfoAppContext context)
        {
            _context = context;
        }

        // GET: Gamers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gamer.ToListAsync());
        }

        // GET: Gamers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamer = await _context.Gamer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gamer == null)
            {
                return NotFound();
            }

            return View(gamer);
        }

        // GET: Gamers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gamers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Email,Score")] Gamer gamer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gamer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gamer);
        }

        // GET: Gamers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamer = await _context.Gamer.FindAsync(id);
            if (gamer == null)
            {
                return NotFound();
            }
            return View(gamer);
        }

        // POST: Gamers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Email,Score")] Gamer gamer)
        {
            if (id != gamer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gamer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GamerExists(gamer.Id))
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
            return View(gamer);
        }

        // GET: Gamers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamer = await _context.Gamer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gamer == null)
            {
                return NotFound();
            }

            return View(gamer);
        }

        // POST: Gamers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gamer = await _context.Gamer.FindAsync(id);
            if (gamer != null)
            {
                _context.Gamer.Remove(gamer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GamerExists(int id)
        {
            return _context.Gamer.Any(e => e.Id == id);
        }
    }
}
