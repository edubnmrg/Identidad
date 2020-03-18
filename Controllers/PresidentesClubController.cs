using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Identidad.Models;
using Microsoft.AspNetCore.Identity;

namespace Identidad.Controllers
{
    public class PresidentesClubController : Controller
    {
        private readonly AppDB _context;
        private readonly UserManager<Usuario> _usermanager;
        public PresidentesClubController(AppDB context, UserManager<Usuario> usermanager)
        {
            _context = context;
            _usermanager = usermanager;
        }

        // GET: PresidentesClub
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Dueño") || User.IsInRole("Presidente Club"))
            {
                ViewData["Autorizado"] = "PresidenteClub";
            }
            if (User.IsInRole("Dueño") || User.IsInRole("Presidente Club"))
            {
                ViewData["Autorizado"] = "PresidenteFederacion";
            }
            var appDB = _context.PresidentesClub.Include(p => p.Club).Include(p => p.Perfil);
            return View(await appDB.ToListAsync());
        }

        // GET: PresidentesClub/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presidenteClub = await _context.PresidentesClub
                .Include(p => p.Club)
                .Include(p => p.Perfil)
                .FirstOrDefaultAsync(m => m.PresClubID == id);
            if (presidenteClub == null)
            {
                return NotFound();
            }
          
            return View(presidenteClub);
        }

        // GET: PresidentesClub/Create
        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                ViewData["ClubID"] = new SelectList(_context.Club, "ClubID", "NombreClub");

            }
            else
            {
                ViewData["ClubID"] = new SelectList(_context.Club.Where(c => c.ClubID == id), "ClubID", "NombreClub");

            }
            ViewData["PerfilID"] = new SelectList(_context.Perfiles, "ID", "NombreCompleto");
            return View();
        }

        // POST: PresidentesClub/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PresClubID,ClubID,PerfilID")] PresidenteClub presidenteClub)
        {
            if (ModelState.IsValid)
            {
                _context.Add(presidenteClub);
                await _context.SaveChangesAsync();
                Perfil Perfil = await _context.Perfiles.Where(p => p.ID == presidenteClub.PerfilID).FirstOrDefaultAsync();
                Usuario Usuario = await _usermanager.FindByIdAsync(Perfil.UserID);
                await _usermanager.AddToRoleAsync(Usuario, "Presidente Club");
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClubID"] = new SelectList(_context.Club, "ClubID", "NombreClub", presidenteClub.ClubID);
            ViewData["PerfilID"] = new SelectList(_context.Perfiles, "ID", "nombreCompleto", presidenteClub.PerfilID);
            return View(presidenteClub);
        }

        // GET: PresidentesClub/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presidenteClub = await _context.PresidentesClub.FindAsync(id);
            if (presidenteClub == null)
            {
                return NotFound();
            }
            ViewData["ClubID"] = new SelectList(_context.Club, "ClubID", "NombreClub", presidenteClub.ClubID);
            ViewData["PerfilID"] = new SelectList(_context.Perfiles.Where(p => p.clubID==presidenteClub.ClubID), "ID", "NombreCompleto", presidenteClub.PerfilID);
            return View(presidenteClub);
        }

        // POST: PresidentesClub/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PresClubID,ClubID,PerfilID")] PresidenteClub presidenteClub)
        {
            if (id != presidenteClub.PresClubID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(presidenteClub);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PresidenteClubExists(presidenteClub.PresClubID))
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
            ViewData["ClubID"] = new SelectList(_context.Club, "ClubID", "NombreClub", presidenteClub.ClubID);
            ViewData["PerfilID"] = new SelectList(_context.Perfiles, "ID", "NombreCompleto", presidenteClub.PerfilID);
            return View(presidenteClub);
        }

        // GET: PresidentesClub/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presidenteClub = await _context.PresidentesClub
                .Include(p => p.Club)
                .Include(p => p.Perfil)
                .FirstOrDefaultAsync(m => m.PresClubID == id);
            if (presidenteClub == null)
            {
                return NotFound();
            }

            return View(presidenteClub);
        }

        // POST: PresidentesClub/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var presidenteClub = await _context.PresidentesClub.FindAsync(id);
            _context.PresidentesClub.Remove(presidenteClub);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PresidenteClubExists(int id)
        {
            return _context.PresidentesClub.Any(e => e.PresClubID == id);
        }
    }
}
