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
    public class GameplaysController : Controller
    {
        private readonly GamerInfoAppContext _context;

        public GameplaysController(GamerInfoAppContext context)
        {
            _context = context;
        }

        // GET: Gameplays
        public async Task<IActionResult> Index()
        {
            var gamerInfoAppContext = _context.Gameplay.Include(g => g.Game).Include(g => g.Gamer);
            return View(await gamerInfoAppContext.ToListAsync());
        }

        // GET: Gameplays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameplay = await _context.Gameplay
                .Include(g => g.Game)
                .Include(g => g.Gamer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameplay == null)
            {
                return NotFound();
            }

            return View(gameplay);
        }

        // GET: Gameplays/Create
        public IActionResult Create()
        {
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "Id");
            ViewData["GamerId"] = new SelectList(_context.Gamer, "Id", "Id");
            return View();
        }

        // POST: Gameplays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GameId,GamerId")] Gameplay gameplay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameplay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "Id", gameplay.GameId);
            ViewData["GamerId"] = new SelectList(_context.Gamer, "Id", "Id", gameplay.GamerId);
            return View(gameplay);
        }

        // GET: Gameplays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameplay = await _context.Gameplay.FindAsync(id);
            if (gameplay == null)
            {
                return NotFound();
            }
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "Id", gameplay.GameId);
            ViewData["GamerId"] = new SelectList(_context.Gamer, "Id", "Id", gameplay.GamerId);
            return View(gameplay);
        }

        // POST: Gameplays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GameId,GamerId")] Gameplay gameplay)
        {
            if (id != gameplay.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameplay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameplayExists(gameplay.Id))
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
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "Id", gameplay.GameId);
            ViewData["GamerId"] = new SelectList(_context.Gamer, "Id", "Id", gameplay.GamerId);
            return View(gameplay);
        }

        // GET: Gameplays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameplay = await _context.Gameplay
                .Include(g => g.Game)
                .Include(g => g.Gamer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameplay == null)
            {
                return NotFound();
            }

            return View(gameplay);
        }

        // POST: Gameplays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameplay = await _context.Gameplay.FindAsync(id);
            if (gameplay != null)
            {
                _context.Gameplay.Remove(gameplay);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameplayExists(int id)
        {
            return _context.Gameplay.Any(e => e.Id == id);
        }
    }
}
