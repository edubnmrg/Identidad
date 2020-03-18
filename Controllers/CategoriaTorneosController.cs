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
    public class CategoriaTorneosController : Controller
    {
        private readonly AppDB _context;

        public CategoriaTorneosController(AppDB context)
        {
            _context = context;
        }

        // GET: CategoriaTorneos
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoriasTorneos.ToListAsync());
        }

        // GET: CategoriaTorneos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaTorneo = await _context.CategoriasTorneos
                .FirstOrDefaultAsync(m => m.catTorneoID == id);
            if (categoriaTorneo == null)
            {
                return NotFound();
            }

            return View(categoriaTorneo);
        }

        // GET: CategoriaTorneos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaTorneos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("catTorneoID,catTorneo")] CategoriaTorneo categoriaTorneo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaTorneo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaTorneo);
        }

        // GET: CategoriaTorneos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaTorneo = await _context.CategoriasTorneos.FindAsync(id);
            if (categoriaTorneo == null)
            {
                return NotFound();
            }
            return View(categoriaTorneo);
        }

        // POST: CategoriaTorneos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("catTorneoID,catTorneo")] CategoriaTorneo categoriaTorneo)
        {
            if (id != categoriaTorneo.catTorneoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaTorneo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaTorneoExists(categoriaTorneo.catTorneoID))
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
            return View(categoriaTorneo);
        }

        // GET: CategoriaTorneos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaTorneo = await _context.CategoriasTorneos
                .FirstOrDefaultAsync(m => m.catTorneoID == id);
            if (categoriaTorneo == null)
            {
                return NotFound();
            }

            return View(categoriaTorneo);
        }

        // POST: CategoriaTorneos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaTorneo = await _context.CategoriasTorneos.FindAsync(id);
            _context.CategoriasTorneos.Remove(categoriaTorneo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaTorneoExists(int id)
        {
            return _context.CategoriasTorneos.Any(e => e.catTorneoID == id);
        }
    }
}
