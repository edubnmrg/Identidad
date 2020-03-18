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
    public class TorneosController : Controller
    {
        private readonly AppDB _context;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;

        public TorneosController(AppDB context, UserManager<Usuario> userManager
            ,SignInManager<Usuario> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Torneos
        public async Task<IActionResult> Index()
        {
            //var appDB = await _context.Torneos.Include(t => t.Club).Include(t => t.CatTor)
            //    .Include(t => t.CanJug).Include(t => t.Cat).Include(t => t.SisTor).ToListAsync();
            //return View( appDB);
           
            List<Torneo> torList= await _context.Torneos.ToListAsync();
            foreach(var item in torList){
                item.Club = _context.Club.FirstOrDefault(t => t.ClubID == item.ClubFK);
                item.CatTor = _context.CategoriasTorneos.FirstOrDefault(t => t.catTorneoID == item.CatTorFK);
                item.CanJug = _context.CantidadJugadores.FirstOrDefault(t => t.cantJugID == item.CanJugFK);
                item.Cat = _context.Categorias.FirstOrDefault(t => t.categoriaID == item.CatFK);
                item.SisTor = _context.SistemasTorneos.FirstOrDefault(t => t.sisTorID == item.SisTorFK);

            }
            return View(torList);
        }

        // GET: Torneos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var torneo = await _context.Torneos
                .Include(t => t.Club)
                .Include(t => t.CatTor)
                .Include(t => t.CanJug)
                .Include(t => t.Cat)
                .Include(t => t.SisTor)
                .FirstOrDefaultAsync(m => m.TorneoID == id);
            if (torneo == null)
            {
                return NotFound();
            }

            return View(torneo);
        }

        // GET: Torneos/Create
        public IActionResult Create()
        {
            
            ViewData["ClubFK"] = new SelectList(_context.Club, "ClubID", "NombreClub");
            ViewData["CatTorFK"] = new SelectList(_context.CategoriasTorneos, "catTorneoID", "catTorneo");
            ViewData["CanJugFK"] = new SelectList(_context.CantidadJugadores, "cantJugID", "cantJug");
            ViewData["CatFK"] = new SelectList(_context.Categorias, "categoriaID", "categoria");
            ViewData["SisTorFK"] = new SelectList(_context.SistemasTorneos, "sisTorID", "sisTor");
            return View();
        }

        // POST: Torneos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TorneoID,NombreTorneo,ClubFK,CatTorFK,CanJugFK,CatFK,SisTorFK,Desde,Hasta,ValorInscripcion,Notas")] Torneo2 torneo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(torneo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(torneo);
        }

        // GET: Torneos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var torneo = await _context.Torneos.FindAsync(id);
            if (torneo == null)
            {
                return NotFound();
            }
            ViewData["ClubFK"] = new SelectList(_context.Club, "ClubID", "NombreClub");
            ViewData["CatTorFK"] = new SelectList(_context.CategoriasTorneos, "catTorneoID", "catTorneo");
            ViewData["CanJugFK"] = new SelectList(_context.CantidadJugadores, "cantJugID", "cantJug");
            ViewData["CatFK"] = new SelectList(_context.Categorias, "categoriaID", "categoria");
            ViewData["SisTorFK"] = new SelectList(_context.SistemasTorneos, "sisTorID", "sisTor");
            return View(torneo);
        }

        // POST: Torneos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TorneoID,NombreTorneo,ClubFK,CatTorFK,CanJugFK,CatFK,SisTorFK,Desde,Hasta,ValorInscripcion,Notas")] Torneo torneo)
        {
            if (id != torneo.TorneoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(torneo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TorneoExists(torneo.TorneoID))
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
            ViewData["ClubFK"] = new SelectList(_context.Club, "ClubID", "NombreClub", torneo.ClubFK);
            ViewData["CatTorFK"] = new SelectList(_context.CategoriasTorneos, "catTorneoID", "catTorneo", torneo.CatTorFK);
            ViewData["CanJugFK"] = new SelectList(_context.CantidadJugadores, "cantJugID", "cantJug", torneo.CanJugFK);
            ViewData["CatFK"] = new SelectList(_context.Categorias, "categoriaID", "categoria", torneo.CatFK);
            ViewData["SisTorFK"] = new SelectList(_context.SistemasTorneos, "sisTorID", "sisTor", torneo.SisTorFK);
            return View(torneo);
        }

        // GET: Torneos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var torneo = await _context.Torneos
                .Include(t => t.SisTor)
                .Include(t => t.Club)
                .Include(t => t.CatTor)
                .Include(t => t.CanJug)
                .Include(t => t.Cat)               
                .FirstOrDefaultAsync(m => m.TorneoID == id);
            if (torneo == null)
            {
                return NotFound();
            }

            return View(torneo);
        }

        // POST: Torneos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var torneo = await _context.Torneos.FindAsync(id);
            _context.Torneos.Remove(torneo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Inscribirme(int id)
        {
            var torneo = await _context.Torneos.FindAsync(id);
            Inscripcion inscripcion = new Inscripcion();
            string uid = _userManager.GetUserId(User);
            Perfil miPerfil = await _context.Perfiles.FirstOrDefaultAsync(p => p.UserID == uid);
            inscripcion.PerfilFK = miPerfil.ID;
            inscripcion.TorneoFK = id;
            await _context.Inscripciones.AddAsync(inscripcion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
      
        public async Task<IActionResult> Inscriptos(int id)
        {
            var torneo = await _context.Torneos.FindAsync(id);
            List<Inscripcion> inscriptos = new List<Inscripcion>();
        
            inscriptos=await _context.Inscripciones.Where(i => i.TorneoFK == id).ToListAsync();
            return RedirectToAction(nameof(Index));
        }
      
        private bool TorneoExists(int id)
        {
            return _context.Torneos.Any(e => e.TorneoID == id);
        }
    }
}
