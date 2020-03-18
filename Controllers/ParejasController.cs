using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Identidad.Models;

namespace Identidad.Controllers
{
    public class ParejasController : Controller
    {
        private readonly AppDB _context;

        public ParejasController(AppDB context)
        {
            _context = context;
        }

        // GET: Parejas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Parejas.ToListAsync());
        }

        // GET: Parejas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pareja = await _context.Parejas
                .FirstOrDefaultAsync(m => m.ParejaID == id);
            if (pareja == null)
            {
                return NotFound();
            }

            return View(pareja);
        }

        // GET: Parejas/Create
        public IActionResult Create()
        {
            ViewData["Jugador1"] = new SelectList(_context.Perfiles, "ID", "NombreCompleto");
            ViewData["Jugador2"] = new SelectList(_context.Perfiles, "ID", "NombreCompleto");
            return View();
        }

        // POST: Parejas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParejaID,Jugador1,Jugador2")] Pareja pareja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pareja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pareja);
        }

        // GET: Parejas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pareja = await _context.Parejas.FindAsync(id);
            if (pareja == null)
            {
                return NotFound();
            }
            ViewData["Jugador1"] = new SelectList(_context.Perfiles, "ID", "NombreCompleto");
            ViewData["Jugador2"] = new SelectList(_context.Perfiles, "ID", "NombreCompleto");
            return View(pareja);
        }

        // POST: Parejas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParejaID,Jugador1,Jugador2")] Pareja pareja)
        {
            if (id != pareja.ParejaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pareja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParejaExists(pareja.ParejaID))
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
            return View(pareja);
        }

        // GET: Parejas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pareja = await _context.Parejas
                .FirstOrDefaultAsync(m => m.ParejaID == id);
            if (pareja == null)
            {
                return NotFound();
            }

            return View(pareja);
        }

        // POST: Parejas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pareja = await _context.Parejas.FindAsync(id);
            _context.Parejas.Remove(pareja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParejaExists(int id)
        {
            return _context.Parejas.Any(e => e.ParejaID == id);
        }
    }
}
