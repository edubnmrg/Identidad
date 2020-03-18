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
    public class ClasificadosController : Controller
    {
        private readonly AppDB _context;

        public ClasificadosController(AppDB context)
        {
            _context = context;
        }

        // GET: Clasificados
        public async Task<IActionResult> Index()
        {
            var Clas = await _context.Clasificados
                .Include(c => c.Perfil)
                .OrderBy(c => c.Puesto)
                .OrderByDescending(c => c.Promedio).ToListAsync();
            return View(Clas);
        }

        // GET: Clasificados del Torneo
        public async Task<IActionResult> ClasificadosTorneo(int id)
        {
            ViewData["NombreTorneo"] = _context.Torneos2.Find(id).NombreTorneo;
            List<Clasificado> Clasificados = await _context.Clasificados
                .Include(c => c.Torneo)
                .Include(c => c.Perfil)
                .Where(c => c.Torneo.TorneoID==id)
                .OrderBy(c =>  c.Puesto).ThenByDescending(c => c.Promedio)
                .ToListAsync();
            if (Clasificados.Count() > 0)
            {
                return View(Clasificados);

            }
            else
            {
                return RedirectToAction("Administrar", "Torneo2", new { id  });

            }
        }
        // GET: Clasificados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasificado = await _context.Clasificados
                .FirstOrDefaultAsync(m => m.ClasificadoID == id);
            if (clasificado == null)
            {
                return NotFound();
            }

            return View(clasificado);
        }

        // GET: Clasificados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clasificados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClasificadoID,TorneoID,PerfilID,Puesto,Promedio")] Clasificado clasificado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clasificado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clasificado);
        }

        // GET: Clasificados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasificado = await _context.Clasificados.FindAsync(id);
            if (clasificado == null)
            {
                return NotFound();
            }
            return View(clasificado);
        }

        // POST: Clasificados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClasificadoID,TorneoID,PerfilID,Puesto,Promedio")] Clasificado clasificado)
        {
            if (id != clasificado.ClasificadoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clasificado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClasificadoExists(clasificado.ClasificadoID))
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
            return View(clasificado);
        }

        // GET: Clasificados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasificado = await _context.Clasificados
                .FirstOrDefaultAsync(m => m.ClasificadoID == id);
            if (clasificado == null)
            {
                return NotFound();
            }

            return View(clasificado);
        }

        // POST: Clasificados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clasificado = await _context.Clasificados.FindAsync(id);
            _context.Clasificados.Remove(clasificado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClasificadoExists(int id)
        {
            return _context.Clasificados.Any(e => e.ClasificadoID == id);
        }
    }
}
