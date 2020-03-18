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
    public class PresidentesFederacionController : Controller
    {
        private readonly AppDB _context;

        public PresidentesFederacionController(AppDB context)
        {
            _context = context;
        }

        // GET: PresidentesFederacion
        public async Task<IActionResult> Index()
        {
            var appDB = await _context.PresidentesFederacion
                .Include(p => p.Perfil)
                .ToListAsync();
            foreach(var a in appDB)
            {
                a.Federacion = await _context.Federaciones.Where(f => f.FederacionID == a.FedID).FirstOrDefaultAsync();
            }
            return View(appDB);
        }

        // GET: PresidentesFederacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PresidenteFederacion presidenteFederacion = await _context.PresidentesFederacion
                .Include(p => p.Perfil)
                .FirstOrDefaultAsync(m => m.PresFedID == id);
            if (presidenteFederacion == null)
            {
                return NotFound();
            }
          
            presidenteFederacion.Federacion = await _context.Federaciones.Where(f => f.FederacionID == presidenteFederacion.FedID).FirstOrDefaultAsync();

            return View(presidenteFederacion);
        }

        // GET: PresidentesFederacion/Create
        public IActionResult Create()
        {
            ViewData["PerfilID"] = new SelectList(_context.Perfiles, "ID", "NombreCompleto");
            ViewData["FedID"] = new SelectList(_context.Federaciones, "FederacionID", "nombre");

            return View();
        }

        // POST: PresidentesFederacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PresFedID,FedID,PerfilID")] PresidenteFederacion presidenteFederacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(presidenteFederacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PerfilID"] = new SelectList(_context.Perfiles, "ID", "Email", presidenteFederacion.PerfilID);
            ViewData["PerfilID"] = new SelectList(_context.Federaciones, "FederacionID", "nombre", presidenteFederacion.FedID);

            return View(presidenteFederacion);
        }

        // GET: PresidentesFederacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presidenteFederacion = await _context.PresidentesFederacion.FindAsync(id);
            if (presidenteFederacion == null)
            {
                return NotFound();
            }
            ViewData["PerfilID"] = new SelectList(_context.Perfiles, "ID", "Email", presidenteFederacion.PerfilID);
            ViewData["FedID"] = new SelectList(_context.Federaciones, "FederacionID", "nombre", presidenteFederacion.FedID);

            return View(presidenteFederacion);
        }

        // POST: PresidentesFederacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PresFedID,FedID,PerfilID")] PresidenteFederacion presidenteFederacion)
        {
            if (id != presidenteFederacion.PresFedID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(presidenteFederacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PresidenteFederacionExists(presidenteFederacion.PresFedID))
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
            ViewData["PerfilID"] = new SelectList(_context.Perfiles, "ID", "Email", presidenteFederacion.PerfilID);
            return View(presidenteFederacion);
        }

        // GET: PresidentesFederacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presidenteFederacion = await _context.PresidentesFederacion
                .Include(p => p.Perfil)
                .FirstOrDefaultAsync(m => m.PresFedID == id);
            if (presidenteFederacion == null)
            {
                return NotFound();
            }
            presidenteFederacion.Federacion = await _context.Federaciones.Where(f => f.FederacionID == presidenteFederacion.FedID).FirstOrDefaultAsync();

            return View(presidenteFederacion);
        }

        // POST: PresidentesFederacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var presidenteFederacion = await _context.PresidentesFederacion.FindAsync(id);
            _context.PresidentesFederacion.Remove(presidenteFederacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PresidenteFederacionExists(int id)
        {
            return _context.PresidentesFederacion.Any(e => e.PresFedID == id);
        }
    }
}
