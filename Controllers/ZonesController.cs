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
    public class ZonesController : Controller
    {
        private readonly AppDB _context;

        public ZonesController(AppDB context)
        {
            _context = context;
        }

        // GET: Zones
        public async Task<IActionResult> Index()
        {
            var appDB = await _context.Zones.Include(z => z.Torneo).ToListAsync();
            if(appDB != null)
            {
                foreach( var j in appDB)
                {
                    j.ZonaJugadores = await _context.ZonasJugadores.Where(t => t.ZonaID == j.ZonaID).Include(p => p.Perfil).ToListAsync();
                }
            }
            return View(appDB);
        }

        // GET: Zones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zone = await _context.Zones
                .Include(z => z.Torneo)
                .FirstOrDefaultAsync(m => m.ZonaID == id);
            if (zone == null)
            {
                return NotFound();
            }

            return View(zone);
        }

        // GET: Zones/Create
        public IActionResult Create()
        {
            ViewData["TorneoID"] = new SelectList(_context.Torneos2, "TorneoID", "NombreTorneo");
            return View();
        }

        // POST: Zones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZonaID,TorneoID,Numero,CantidadJugadores")] Zone zone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TorneoID"] = new SelectList(_context.Torneos2, "TorneoID", "NombreTorneo", zone.TorneoID);
            return View(zone);
        }

        // GET: Zones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zone = await _context.Zones.Where(z => z.ZonaID == id).FirstOrDefaultAsync();
            zone.ZonaJugadores = await _context.ZonasJugadores.Where(z => z.ZonaID==zone.ZonaID).Include(p => p.Perfil).ToListAsync();
            if (zone == null)
            {
                return NotFound();
            }
            ViewData["TorneoID"] = new SelectList(_context.Torneos2, "TorneoID", "NombreTorneo", zone.TorneoID);
            return View(zone);
        }

        // POST: Zones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZonaID,TorneoID,Numero,CantidadJugadores")] Zone zone)
        {
            if (id != zone.ZonaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZoneExists(zone.ZonaID))
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
            ViewData["TorneoID"] = new SelectList(_context.Torneos2, "TorneoID", "NombreTorneo", zone.TorneoID);
            return View(zone);
        }

        // GET: Zones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zone = await _context.Zones
                .Include(z => z.Torneo)
                .FirstOrDefaultAsync(m => m.ZonaID == id);
            if (zone == null)
            {
                return NotFound();
            }

            return View(zone);
        }

        // POST: Zones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zone = await _context.Zones.FindAsync(id);
            _context.Zones.Remove(zone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZoneExists(int id)
        {
            return _context.Zones.Any(e => e.ZonaID == id);
        }
    }
}
