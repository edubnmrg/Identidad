using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Identidad.Models;
using Identidad.Models.Recursos;

namespace Identidad.Controllers
{
    public class CantidadJugadoresController : Controller
    {
        private readonly AppDB _context;

        public CantidadJugadoresController(AppDB context)
        {
            _context = context;
        }

        // GET: CantidadJugadores
        public async Task<IActionResult> Index()
        {
            return View(await _context.CantidadJugadores.ToListAsync());
        }

        // GET: CantidadJugadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cantidadJugadores = await _context.CantidadJugadores
                .FirstOrDefaultAsync(m => m.cantJugID == id);
            if (cantidadJugadores == null)
            {
                return NotFound();
            }

            return View(cantidadJugadores);
        }

        // GET: CantidadJugadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CantidadJugadores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cantJugID,cantJug")] CantidadJugadores cantidadJugadores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cantidadJugadores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cantidadJugadores);
        }

        // GET: CantidadJugadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cantidadJugadores = await _context.CantidadJugadores.FindAsync(id);
            if (cantidadJugadores == null)
            {
                return NotFound();
            }
            return View(cantidadJugadores);
        }

        // POST: CantidadJugadores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cantJugID,cantJug")] CantidadJugadores cantidadJugadores)
        {
            if (id != cantidadJugadores.cantJugID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cantidadJugadores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CantidadJugadoresExists(cantidadJugadores.cantJugID))
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
            return View(cantidadJugadores);
        }

        // GET: CantidadJugadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cantidadJugadores = await _context.CantidadJugadores
                .FirstOrDefaultAsync(m => m.cantJugID == id);
            if (cantidadJugadores == null)
            {
                return NotFound();
            }

            return View(cantidadJugadores);
        }

        // POST: CantidadJugadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cantidadJugadores = await _context.CantidadJugadores.FindAsync(id);
            _context.CantidadJugadores.Remove(cantidadJugadores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CantidadJugadoresExists(int id)
        {
            return _context.CantidadJugadores.Any(e => e.cantJugID == id);
        }
    }
}
