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
    public class InscripcionesController : Controller
    {
        private readonly AppDB _context;

        public InscripcionesController(AppDB context)
        {
            _context = context;
        }

        // GET: Inscripciones
        public async Task<IActionResult> Index()
        {
            var appDB = _context.Inscripciones.Include(i => i.Perfil).Include(i => i.Torneo);
            return View(await appDB.ToListAsync());
        }

        // GET: Inscripciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscripcion = await _context.Inscripciones
                .Include(i => i.Perfil)
                .Include(i => i.Torneo)
                .FirstOrDefaultAsync(m => m.InscripcionID == id);
            if (inscripcion == null)
            {
                return NotFound();
            }

            return View(inscripcion);
        }

        // GET: Inscripciones/Create
        public IActionResult Create()
        {
            ViewData["PerfilFK"] = new SelectList(_context.Perfiles, "ID", "NombreCompleto");
            ViewData["TorneoFK"] = new SelectList(_context.Torneos, "TorneoID", "NombreTorneo");
            return View();
        }

        // POST: Inscripciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InscripcionID,PerfilFK,TorneoFK")] Inscripcion inscripcion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inscripcion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PerfilFK"] = new SelectList(_context.Club, "ID", "calle", inscripcion.PerfilFK);
            ViewData["TorneoFK"] = new SelectList(_context.Club, "ID", "calle", inscripcion.TorneoFK);
            return View(inscripcion);
        }

        // GET: Inscripciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscripcion = await _context.Inscripciones.FindAsync(id);
            if (inscripcion == null)
            {
                return NotFound();
            }
            ViewData["PerfilFK"] = new SelectList(_context.Club, "ID", "calle", inscripcion.PerfilFK);
            ViewData["TorneoFK"] = new SelectList(_context.Club, "ID", "calle", inscripcion.TorneoFK);
            return View(inscripcion);
        }

        // POST: Inscripciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InscripcionID,PerfilFK,TorneoFK")] Inscripcion inscripcion)
        {
            if (id != inscripcion.InscripcionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscripcion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscripcionExists(inscripcion.InscripcionID))
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
            ViewData["PerfilFK"] = new SelectList(_context.Club, "ID", "calle", inscripcion.PerfilFK);
            ViewData["TorneoFK"] = new SelectList(_context.Club, "ID", "calle", inscripcion.TorneoFK);
            return View(inscripcion);
        }

        // GET: Inscripciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscripcion = await _context.Inscripciones
                .Include(i => i.Perfil)
                .Include(i => i.Torneo)
                .FirstOrDefaultAsync(m => m.InscripcionID == id);
            if (inscripcion == null)
            {
                return NotFound();
            }

            return View(inscripcion);
        }

        // POST: Inscripciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inscripcion = await _context.Inscripciones.FindAsync(id);
            _context.Inscripciones.Remove(inscripcion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscripcionExists(int id)
        {
            return _context.Inscripciones.Any(e => e.InscripcionID == id);
        }
    }
}
