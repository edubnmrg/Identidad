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
    public class ApoderadosClubController : Controller
    {
        private readonly AppDB _context;
        private readonly UserManager<Usuario> _userManager;
        public ApoderadosClubController(AppDB context, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: ApoderadosClub
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Dueño") || User.IsInRole("Presidente Club") || User.IsInRole("Apoderado Club"))
            {
                ViewData["Autorizado"] = "ApoderadoClub";
            }
            var appDB = _context.ApoderadosClub.Include(a => a.Club).Include(a => a.Perfil);
            return View(await appDB.ToListAsync());
        }

        // GET: ApoderadosClub/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apoderadoClub = await _context.ApoderadosClub
                .Include(a => a.Club)
                .Include(a => a.Perfil)
                .FirstOrDefaultAsync(m => m.ApoClubID == id);
            if (apoderadoClub == null)
            {
                return NotFound();
            }

            return View(apoderadoClub);
        }

        // GET: ApoderadosClub/Create
        public IActionResult Create(int? id)
        {
            if(id == null)
            {
                ViewData["ClubID"] = new SelectList(_context.Club, "ClubID", "NombreClub");
                ViewData["PerfilID"] = new SelectList(_context.Perfiles, "ID", "NombreCompleto");

            }
            else
            {
                ViewData["ClubID"] = new SelectList(_context.Club.Where(c => c.ClubID == id), "ClubID", "NombreClub");
                ViewData["PerfilID"] = new SelectList(_context.Perfiles.Where(p => p.clubID == id), "ID", "NombreCompleto");

            }
            return View();
        }

        // POST: ApoderadosClub/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApoClubID,ClubID,PerfilID")] ApoderadoClub apoderadoClub)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apoderadoClub);
                await _context.SaveChangesAsync();
                Perfil Perfil = await _context.Perfiles.Where(p => p.ID == apoderadoClub.PerfilID).FirstOrDefaultAsync();
                Usuario Usuario = await _userManager.FindByIdAsync(Perfil.UserID);
                await _userManager.AddToRoleAsync(Usuario, "Apoderado Club");
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClubID"] = new SelectList(_context.Club, "ClubID", "NombreClub", apoderadoClub.ClubID);
            ViewData["PerfilID"] = new SelectList(_context.Perfiles.Where(p => p.clubID == apoderadoClub.ClubID), "ID", "Email", apoderadoClub.PerfilID);
            return View(apoderadoClub);
        }

        // GET: ApoderadosClub/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apoderadoClub = await _context.ApoderadosClub.FindAsync(id);
            if (apoderadoClub == null)
            {
                return NotFound();
            }
            ViewData["ClubID"] = new SelectList(_context.Club.Where(c => c.ClubID == apoderadoClub.ClubID), "ClubID", "NombreClub", apoderadoClub.ClubID);
            ViewData["PerfilID"] = new SelectList(_context.Perfiles, "ID", "NombreCompleto", apoderadoClub.PerfilID);
            return View(apoderadoClub);
        }

        // POST: ApoderadosClub/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApoClubID,ClubID,PerfilID")] ApoderadoClub apoderadoClub)
        {
            if (id != apoderadoClub.ApoClubID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apoderadoClub);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApoderadoClubExists(apoderadoClub.ApoClubID))
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
            ViewData["ClubID"] = new SelectList(_context.Club, "ClubID", "NombreClub", apoderadoClub.ClubID);
            ViewData["PerfilID"] = new SelectList(_context.Perfiles, "ID", "Email", apoderadoClub.PerfilID);
            return View(apoderadoClub);
        }

        // GET: ApoderadosClub/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apoderadoClub = await _context.ApoderadosClub
                .Include(a => a.Club)
                .Include(a => a.Perfil)
                .FirstOrDefaultAsync(m => m.ApoClubID == id);
            if (apoderadoClub == null)
            {
                return NotFound();
            }

            return View(apoderadoClub);
        }

        // POST: ApoderadosClub/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apoderadoClub = await _context.ApoderadosClub.FindAsync(id);
            _context.ApoderadosClub.Remove(apoderadoClub);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApoderadoClubExists(int id)
        {
            return _context.ApoderadosClub.Any(e => e.ApoClubID == id);
        }
    }
}
