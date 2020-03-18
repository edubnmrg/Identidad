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
    public class AnotacionesController : Controller
    {
        private readonly AppDB _context;

        public AnotacionesController(AppDB context)
        {
            _context = context;
        }

        // GET: Anotaciones
        public async Task<IActionResult> Index()
        {
            var appDB = _context.Anotaciones.Include(a => a.Perfil).Include(a => a.Torneo);
            return View(await appDB.ToListAsync());
        }
        public async Task<IActionResult> InscriptosAlTorneo(int id)
        {
            var appDB = _context.Anotaciones.Where(a => a.TorneoRefId == id).Include(a => a.Perfil).Include(a => a.Torneo);
            return View("Index",await appDB.ToListAsync());
        }
        // GET: Anotaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anotacion = await _context.Anotaciones
                .Include(a => a.Perfil)
                .Include(a => a.Torneo)
                .FirstOrDefaultAsync(m => m.AnotacionID == id);
            if (anotacion == null)
            {
                return NotFound();
            }

            return View(anotacion);
        }

        // GET: Anotaciones/Create
        public IActionResult Create()
        {
            ViewData["PerfilRefId"] = new SelectList(_context.Perfiles, "ID", "NombreCompleto");
            ViewData["TorneoRefId"] = new SelectList(_context.Torneos, "TorneoID", "NombreTorneo");
            return View();
        }

        // POST: Anotaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnotacionID,PerfilRefId,TorneoRefId")] Anotacion anotacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anotacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PerfilRefId"] = new SelectList(_context.Perfiles, "ID", "NombreCompleto", anotacion.PerfilRefId);
            ViewData["TorneoRefId"] = new SelectList(_context.Torneos2, "TorneoID", "NombreTorneo", anotacion.TorneoRefId);
            return View(anotacion);
        }

        // GET: Anotaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anotacion = await _context.Anotaciones.FindAsync(id);
            if (anotacion == null)
            {
                return NotFound();
            }
            ViewData["PerfilRefId"] = new SelectList(_context.Perfiles, "ID", "NombreCompleto", anotacion.PerfilRefId);
            ViewData["TorneoRefId"] = new SelectList(_context.Torneos2, "TorneoID", "NombreTorneo", anotacion.TorneoRefId);
            return View(anotacion);
        }

        // POST: Anotaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnotacionID,PerfilRefId,TorneoRefId")] Anotacion anotacion)
        {
            if (id != anotacion.AnotacionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anotacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnotacionExists(anotacion.AnotacionID))
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
            ViewData["PerfilRefId"] = new SelectList(_context.Perfiles, "ID", "NombreCompleto", anotacion.PerfilRefId);
            ViewData["TorneoRefId"] = new SelectList(_context.Torneos2, "TorneoID", "NombreTorneo", anotacion.TorneoRefId);
            return View(anotacion);
        }

        // GET: Anotaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anotacion = await _context.Anotaciones
                .Include(a => a.Perfil)
                .Include(a => a.Torneo)
                .FirstOrDefaultAsync(m => m.AnotacionID == id);
            if (anotacion == null)
            {
                return NotFound();
            }

            return View(anotacion);
        }

        // POST: Anotaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anotacion = await _context.Anotaciones.FindAsync(id);
            _context.Anotaciones.Remove(anotacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnotacionExists(int id)
        {
            return _context.Anotaciones.Any(e => e.AnotacionID == id);
        }
    }
}
