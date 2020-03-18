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
    public class ApoderadosFederacionController : Controller
    {
        private readonly AppDB _context;

        public ApoderadosFederacionController(AppDB context)
        {
            _context = context;
        }

        // GET: ApoderadosFederacion
        public async Task<IActionResult> Index()
        {
            var appDB = _context.ApoderadosFederacion.Include(a => a.Perfil);
            return View(await appDB.ToListAsync());
        }

        // GET: ApoderadosFederacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apoderadoFederacion = await _context.ApoderadosFederacion
                .Include(a => a.Perfil)
                .FirstOrDefaultAsync(m => m.ApoFedID == id);
            if (apoderadoFederacion == null)
            {
                return NotFound();
            }

            return View(apoderadoFederacion);
        }

        // GET: ApoderadosFederacion/Create
        public IActionResult Create()
        {
            ViewData["PerfilID"] = new SelectList(_context.Perfiles, "ID", "Email");
            return View();
        }

        // POST: ApoderadosFederacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApoFedID,FedID,PerfilID")] ApoderadoFederacion apoderadoFederacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apoderadoFederacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PerfilID"] = new SelectList(_context.Perfiles, "ID", "Email", apoderadoFederacion.PerfilID);
            return View(apoderadoFederacion);
        }

        // GET: ApoderadosFederacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apoderadoFederacion = await _context.ApoderadosFederacion.FindAsync(id);
            if (apoderadoFederacion == null)
            {
                return NotFound();
            }
            ViewData["PerfilID"] = new SelectList(_context.Perfiles, "ID", "Email", apoderadoFederacion.PerfilID);
            return View(apoderadoFederacion);
        }

        // POST: ApoderadosFederacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApoFedID,FedID,PerfilID")] ApoderadoFederacion apoderadoFederacion)
        {
            if (id != apoderadoFederacion.ApoFedID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apoderadoFederacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApoderadoFederacionExists(apoderadoFederacion.ApoFedID))
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
            ViewData["PerfilID"] = new SelectList(_context.Perfiles, "ID", "Email", apoderadoFederacion.PerfilID);
            return View(apoderadoFederacion);
        }

        // GET: ApoderadosFederacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apoderadoFederacion = await _context.ApoderadosFederacion
                .Include(a => a.Perfil)
                .FirstOrDefaultAsync(m => m.ApoFedID == id);
            if (apoderadoFederacion == null)
            {
                return NotFound();
            }

            return View(apoderadoFederacion);
        }

        // POST: ApoderadosFederacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apoderadoFederacion = await _context.ApoderadosFederacion.FindAsync(id);
            _context.ApoderadosFederacion.Remove(apoderadoFederacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApoderadoFederacionExists(int id)
        {
            return _context.ApoderadosFederacion.Any(e => e.ApoFedID == id);
        }
    }
}
