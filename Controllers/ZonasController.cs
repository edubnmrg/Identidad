﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Identidad.Models;

namespace Identidad.Controllers
{
    public class ZonasController : Controller
    {
        private readonly AppDB _context;

        public ZonasController(AppDB context)
        {
            _context = context;
        }

        // GET: Zonas
        public async Task<IActionResult> Index()
        {
            List<Torneo2> Torneos = await _context.Torneos2.Include(z => z.Zones).ToListAsync();
            foreach(Torneo2 t  in Torneos)
            {
                foreach(Zone z in t.Zones)
                {
                    z.ZonaJugadores = await _context.ZonasJugadores.Where(j => j.ZonaID == z.ZonaID).ToListAsync();
                    foreach(ZonaJugador zj in z.ZonaJugadores)
                    {
                        zj.Perfil = await _context.Perfiles.Where(p => p.ID == zj.PerfilID).FirstOrDefaultAsync();
                    }
                }
            }
            return View( Torneos);
        }

        // GET: Zonas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zona = await _context.Zonas
                .Include(z => z.Torneo)
                .FirstOrDefaultAsync(m => m.ZonaID == id);
            if (zona == null)
            {
                return NotFound();
            }

            return View(zona);
        }

        // GET: Zonas/Create
        public IActionResult Create()
        {
            ViewData["TorneoID"] = new SelectList(_context.Torneos, "TorneoID", "NombreTorneo");
            return View();
        }

        // POST: Zonas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZonaID,TorneoID,Numero,CantidadJugadores")] Zona zona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TorneoID"] = new SelectList(_context.Torneos, "TorneoID", "NombreTorneo", zona.TorneoID);
            return View(zona);
        }

        // GET: Zonas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zona = await _context.Zonas.FindAsync(id);
            if (zona == null)
            {
                return NotFound();
            }
            ViewData["TorneoID"] = new SelectList(_context.Torneos, "TorneoID", "NombreTorneo", zona.TorneoID);
            return View(zona);
        }

        // POST: Zonas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZonaID,TorneoID,Numero,CantidadJugadores")] Zona zona)
        {
            if (id != zona.ZonaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZonaExists(zona.ZonaID))
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
            ViewData["TorneoID"] = new SelectList(_context.Torneos, "TorneoID", "NombreTorneo", zona.TorneoID);
            return View(zona);
        }

        // GET: Zonas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zona = await _context.Zonas
                .Include(z => z.Torneo)
                .FirstOrDefaultAsync(m => m.ZonaID == id);
            if (zona == null)
            {
                return NotFound();
            }

            return View(zona);
        }

        // POST: Zonas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zona = await _context.Zonas.FindAsync(id);
            _context.Zonas.Remove(zona);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZonaExists(int id)
        {
            return _context.Zonas.Any(e => e.ZonaID == id);
        }
    }
}
