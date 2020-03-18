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
    public class ClubsController : Controller
    {
        private readonly AppDB _context;

        public ClubsController(AppDB context)
        {
            _context = context;
        }

        // GET: Clubs
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Dueño") || User.IsInRole("Presidente Club") || User.IsInRole("Apoderado Club"))
            {
                ViewData["Autorizado"] = "ApoderadoClub";
            }
            var clubDB = _context.Club.Include(c => c.Provincia).Include(c => c.Federacion);
          
            return View(await clubDB.ToListAsync());
        }

        // GET: Clubs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club = await _context.Club.Include(c => c.Provincia).Include(c => c.Federacion)
                .FirstOrDefaultAsync(m => m.ClubID == id);
            if (club == null)
            {
                return NotFound();
            }
            club.PresidenteClub = await _context.PresidentesClub.Where(f => f.PerfilID == club.PresClubID)
                .Include(p => p.Perfil)
                .FirstOrDefaultAsync();
            club.ApoderadosClub = await _context.ApoderadosClub.Where(f => f.ClubID == club.ClubID)
                .Include(a => a.Perfil)
                .ToListAsync();

            return View(club);
        }

        // GET: Clubs/Create
        public IActionResult Create()
        {
            ViewData["provinciaID"] = new SelectList(_context.Provincias, "ID", "nombre");
            ViewData["FedID"] = new SelectList(_context.Federaciones, "FederacionID", "nombre");

            return View();
        }

        // POST: Clubs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClubID,NombreClub,SiglaClub,Calle,Altura,Ciudad,ProvinciaID,ClubEmail,ClubUrl,Telefono,FederacionID")] Club club)
        {
            if (ModelState.IsValid)
            {
                _context.Add(club);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["provinciaID"] = new SelectList(_context.Provincias, "ID", "nombre");
            ViewData["FedID"] = new SelectList(_context.Federaciones, "FedID", "nombre");
            return View(club);
        }

        // GET: Clubs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Club Club = await _context.Club.Include(c => c.Provincia).Include(c => c.Federacion)
                 .FirstOrDefaultAsync(m => m.ClubID == id);
            if (Club == null)
            {
                return NotFound();
            }
            Club.Federacion = await _context.Federaciones.Where(f => f.FederacionID == Club.FederacionID).FirstOrDefaultAsync();
            Club.PresidenteClub = await _context.PresidentesClub.Where(f => f.PerfilID == Club.PresClubID)
                .Include(p => p.Perfil)
                .FirstOrDefaultAsync();
            Club.ApoderadosClub = await _context.ApoderadosClub.Where(f => f.ClubID == Club.ClubID)
                .Include(a => a.Perfil)
                .ToListAsync();


            ViewData["provinciaID"] = new SelectList(_context.Provincias, "ID", "nombre");
            ViewData["FedID"] = new SelectList(_context.Federaciones, "FederacionID", "nombre");
            ViewData["PerfilID"] = new SelectList(_context.Perfiles.Where(p => p.clubID == Club.ClubID), "ID", "NombreCompleto");

            return View(Club);
        }

        // POST: Clubs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClubID,NombreClub,SiglaClub,Calle,Altura,Ciudad,ProvinciaID,ClubEmail,ClubUrl,Telefono,FederacionID")] Club club)
        {
            if (id != club.ClubID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(club);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClubExists(club.ClubID))
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
            return View(club);
        }

        // GET: Clubs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club = await _context.Club.Include(c => c.Provincia).Include(c => c.Federacion)
                .FirstOrDefaultAsync(m => m.ClubID == id);
            if (club == null)
            {
                return NotFound();
            }

            return View(club);
        }

        // POST: Clubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var club = await _context.Club.FindAsync(id);
            _context.Club.Remove(club);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClubExists(int id)
        {
            return _context.Club.Any(e => e.ClubID == id);
        }
    }
}
