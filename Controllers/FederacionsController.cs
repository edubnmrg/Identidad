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
    public class FederacionsController : Controller
    {
        private readonly AppDB _context;

        public FederacionsController(AppDB context)
        {
            _context = context;
        }

        // GET: Federacions
        public async Task<IActionResult> Index()
        {
            var fedDB = _context.Federaciones.Include(f => f.Provincia);
            return View(await fedDB.ToListAsync());
        }

        // GET: Federacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Federacion federacion = await _context.Federaciones.Include(f =>f.Provincia)
                .FirstOrDefaultAsync(m => m.FederacionID == id);
            if (federacion == null)
            {
                return NotFound();
            }
            
            federacion.ApoderadosFederacion = await _context.ApoderadosFederacion
                .Where(a => a.FedID == federacion.FederacionID)
                .ToListAsync();
            return View(federacion);
        }

        // GET: Federacions/Create
        public IActionResult Create()
        {
            ViewData["provinciaID"] = new SelectList(_context.Provincias, "ID", "nombre");
            return View();
        }

        // POST: Federacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FederacionID,nombre,sigla,calle,altura,ciudad,provinciaID,fedEmail,fedUrl,telefono")] Federacion federacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(federacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(federacion);
        }

        // GET: Federacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var federacion = await _context.Federaciones.FindAsync(id);
            if (federacion == null)
            {
                return NotFound();
            }
            ViewData["provinciaID"] = new SelectList(_context.Provincias, "ID", "nombre",federacion.provinciaID);

            return View(federacion);
        }

        // POST: Federacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FederacionID,nombre,sigla,calle,altura,ciudad,provinciaID,fedEmail,fedUrl,telefono")] Federacion federacion)
        {
            if (id != federacion.FederacionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(federacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FederacionExists(federacion.FederacionID))
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
            return View(federacion);
        }

        // GET: Federacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var federacion = await _context.Federaciones.Include(f => f.Provincia)
                .FirstOrDefaultAsync(m => m.FederacionID == id);
            if (federacion == null)
            {
                return NotFound();
            }

            return View(federacion);
        }

        // POST: Federacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var federacion = await _context.Federaciones.FindAsync(id);
            _context.Federaciones.Remove(federacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FederacionExists(int id)
        {
            return _context.Federaciones.Any(e => e.FederacionID == id);
        }
    }
}
