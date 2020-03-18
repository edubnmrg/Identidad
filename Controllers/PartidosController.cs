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
    public class PartidosController : Controller
    {
        private readonly AppDB _context;

        public PartidosController(AppDB context)
        {
            _context = context;
        }

        // GET: Partidos
        public async Task<IActionResult> Index()
        {
            List<Partido> Partidos = await _context.Partidos
                .Include(p => p.Etapa).ToListAsync();
            foreach(Partido p in Partidos)
            {
                p.Perfil1 = await _context.Perfiles.Where(q => q.ID == p.Jugador1Id).FirstOrDefaultAsync();

                p.Perfil = await _context.Perfiles.Where(q => q.ID == p.Jugador2Id).FirstOrDefaultAsync();
            }
            return View(Partidos);
        }

        // GET: Partidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partido = await _context.Partidos
                .Include(p => p.Etapa)
                .Include(p => p.Perfil1)
                .Include(p => p.Perfil)
                .FirstOrDefaultAsync(m => m.PartidoId == id);
            if (partido == null)
            {
                return NotFound();
            }

            return View(partido);
        }

        // GET: Partidos/Create
        public IActionResult Create()
        {
            ViewData["EtapaId"] = new SelectList(_context.Etapas, "EtapaId", "NombreEtapa");
            return View();
        }

        // POST: Partidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PartidoId,Jugador1Id,Jugador2Id,ZonaId,EtapaId,PartidoNumero,Cerrado,Ganador")] Partido partido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EtapaId"] = new SelectList(_context.Etapas, "EtapaId", "NombreEtapa", partido.EtapaId);
            return View(partido);
        }

        // GET: Partidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partido = await _context.Partidos.FindAsync(id);
            if (partido == null)
            {
                return NotFound();
            }
            ViewData["EtapaId"] = new SelectList(_context.Etapas, "EtapaId", "NombreEtapa", partido.EtapaId);
            return View(partido);
        }

        // POST: Partidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PartidoId,Jugador1Id,Jugador2Id,ZonaId,EtapaId,PartidoNumero,Cerrado,Ganador")] Partido partido)
        {
            if (id != partido.PartidoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartidoExists(partido.PartidoId))
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
            ViewData["EtapaId"] = new SelectList(_context.Etapas, "EtapaId", "NombreEtapa", partido.EtapaId);
            return RedirectToAction(nameof(Index));
        }

        // GET: Partidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partido = await _context.Partidos
                .Include(p => p.Etapa)
                .Include(p => p.Perfil1)
                .Include(p => p.Perfil)
                .FirstOrDefaultAsync(m => m.PartidoId == id);
            if (partido == null)
            {
                return NotFound();
            }

            return View(partido);
        }

        // POST: Partidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partido = await _context.Partidos.FindAsync(id);
            _context.Partidos.Remove(partido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartidoExists(int id)
        {
            return _context.Partidos.Any(e => e.PartidoId == id);
        }
    }
}
