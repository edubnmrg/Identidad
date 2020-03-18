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
    public class SistemaTorneosController : Controller
    {
        private readonly AppDB _context;

        public SistemaTorneosController(AppDB context)
        {
            _context = context;
        }

        // GET: SistemaTorneos
        public async Task<IActionResult> Index()
        {
            return View(await _context.SistemasTorneos.ToListAsync());
        }

        // GET: SistemaTorneos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sistemaTorneo = await _context.SistemasTorneos
                .FirstOrDefaultAsync(m => m.sisTorID == id);
            if (sistemaTorneo == null)
            {
                return NotFound();
            }

            return View(sistemaTorneo);
        }

        // GET: SistemaTorneos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SistemaTorneos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("sisTorID,sisTor")] SistemaTorneo sistemaTorneo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sistemaTorneo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sistemaTorneo);
        }

        // GET: SistemaTorneos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sistemaTorneo = await _context.SistemasTorneos.FindAsync(id);
            if (sistemaTorneo == null)
            {
                return NotFound();
            }
            return View(sistemaTorneo);
        }

        // POST: SistemaTorneos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("sisTorID,sisTor")] SistemaTorneo sistemaTorneo)
        {
            if (id != sistemaTorneo.sisTorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sistemaTorneo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SistemaTorneoExists(sistemaTorneo.sisTorID))
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
            return View(sistemaTorneo);
        }

        // GET: SistemaTorneos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sistemaTorneo = await _context.SistemasTorneos
                .FirstOrDefaultAsync(m => m.sisTorID == id);
            if (sistemaTorneo == null)
            {
                return NotFound();
            }

            return View(sistemaTorneo);
        }

        // POST: SistemaTorneos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sistemaTorneo = await _context.SistemasTorneos.FindAsync(id);
            _context.SistemasTorneos.Remove(sistemaTorneo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SistemaTorneoExists(int id)
        {
            return _context.SistemasTorneos.Any(e => e.sisTorID == id);
        }
    }
}
