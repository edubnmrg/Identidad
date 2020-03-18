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
    public class ZonasJugadoresController : Controller
    {
        private readonly AppDB _context;

        public ZonasJugadoresController(AppDB context)
        {
            _context = context;
        }

        // GET: ZonasJugadores
        public async Task<IActionResult> Index()
        {
            var zJ = _context.ZonasJugadores.Include(z => z.Zone).ThenInclude(t => t.Torneo)
                .Include(p => p.Perfil);
            return View(await zJ.ToListAsync());
        }

        // GET: ZonasJugadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zonaJugador = await _context.ZonasJugadores
                .FirstOrDefaultAsync(m => m.ZonaJugadorID == id);
            if (zonaJugador == null)
            {
                return NotFound();
            }

            return View(zonaJugador);
        }

        // GET: ZonasJugadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ZonasJugadores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZonaJugadorID,ZonaID,JugadorID")] ZonaJugador zonaJugador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zonaJugador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zonaJugador);
        }

        // GET: ZonasJugadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zonaJugador = await _context.ZonasJugadores.FindAsync(id);
            if (zonaJugador == null)
            {
                return NotFound();
            }
            return View(zonaJugador);
        }

        // POST: ZonasJugadores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZonaJugadorID,ZonaID,JugadorID")] ZonaJugador zonaJugador)
        {
            if (id != zonaJugador.ZonaJugadorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zonaJugador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZonaJugadorExists(zonaJugador.ZonaJugadorID))
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
            return View(zonaJugador);
        }

        // GET: ZonasJugadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zonaJugador = await _context.ZonasJugadores
                .FirstOrDefaultAsync(m => m.ZonaJugadorID == id);
            if (zonaJugador == null)
            {
                return NotFound();
            }

            return View(zonaJugador);
        }

        // POST: ZonasJugadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zonaJugador = await _context.ZonasJugadores.FindAsync(id);
            _context.ZonasJugadores.Remove(zonaJugador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZonaJugadorExists(int id)
        {
            return _context.ZonasJugadores.Any(e => e.ZonaJugadorID == id);
        }
    }
}
