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
    public class CategoriasJugadoresController : Controller
    {
        private readonly AppDB _context;

        public CategoriasJugadoresController(AppDB context)
        {
            _context = context;
        }

        // GET: CategoriasJugadores
        public async Task<IActionResult> Index()
        {
            var appDB = await _context.CategoriasJugadores.Include(c => c.Categoria)
                .Include(c => c.Juego).Include(c => c.Perfil)
                .ToListAsync();
            return View(appDB);
        }

        // GET: CategoriasJugadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaJugador = await _context.CategoriasJugadores
                .Include(c => c.Categoria)
                .Include(c => c.Juego)
                .Include(c => c.Perfil)
                .FirstOrDefaultAsync(m => m.CategoriaJugadorID == id);
            if (categoriaJugador == null)
            {
                return NotFound();
            }

            return View(categoriaJugador);
        }

        // GET: CategoriasJugadores/Create
        public IActionResult Create()
        {
            ViewData["CategoriaFK"] = new SelectList(_context.Categorias, "categoriaID", "categoria");
            ViewData["JuegoFK"] = new SelectList(_context.Juegoes, "JuegoID", "nombreJuego");
            ViewData["PerfilFK"] = new SelectList(_context.Perfiles, "ID", "NombreCompleto");
            return View();
        }

        // POST: CategoriasJugadores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriaJugadorID,PerfilFK,JuegoFK,CategoriaFK")] CategoriaJugador categoriaJugador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaJugador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaFK"] = new SelectList(_context.Categorias, "categoriaID", "categoria", categoriaJugador.CategoriaFK);
            ViewData["JuegoFK"] = new SelectList(_context.Juegoes, "JuegoID", "nombreJuego", categoriaJugador.JuegoFK);
            ViewData["PerfilFK"] = new SelectList(_context.Perfiles, "ID", "NombreCompleto", categoriaJugador.PerfilFK);
            return View(categoriaJugador);
        }

        // GET: CategoriasJugadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaJugador = await _context.CategoriasJugadores.FindAsync(id);
            if (categoriaJugador == null)
            {
                return NotFound();
            }
            ViewData["CategoriaFK"] = new SelectList(_context.Categorias, "categoriaID", "categoria", categoriaJugador.CategoriaFK);
            ViewData["JuegoFK"] = new SelectList(_context.Juegoes, "JuegoID", "nombreJuego", categoriaJugador.JuegoFK);
            ViewData["PerfilFK"] = new SelectList(_context.Perfiles, "ID", "NombreCompleto", categoriaJugador.PerfilFK);
            return View(categoriaJugador);
        }

        // POST: CategoriasJugadores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoriaJugadorID,PerfilFK,JuegoFK,CategoriaFK")] CategoriaJugador categoriaJugador)
        {
            if (id != categoriaJugador.CategoriaJugadorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaJugador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaJugadorExists(categoriaJugador.CategoriaJugadorID))
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
            ViewData["CategoriaFK"] = new SelectList(_context.Club, "ID", "calle", categoriaJugador.CategoriaFK);
            ViewData["JuegoFK"] = new SelectList(_context.Club, "ID", "calle", categoriaJugador.JuegoFK);
            ViewData["PerfilFK"] = new SelectList(_context.Club, "ID", "calle", categoriaJugador.PerfilFK);
            return View(categoriaJugador);
        }

        // GET: CategoriasJugadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaJugador = await _context.CategoriasJugadores
                .Include(c => c.Categoria)
                .Include(c => c.Juego)
                .Include(c => c.Perfil)
                .FirstOrDefaultAsync(m => m.CategoriaJugadorID == id);
            if (categoriaJugador == null)
            {
                return NotFound();
            }

            return View(categoriaJugador);
        }

        // POST: CategoriasJugadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaJugador = await _context.CategoriasJugadores.FindAsync(id);
            _context.CategoriasJugadores.Remove(categoriaJugador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaJugadorExists(int id)
        {
            return _context.CategoriasJugadores.Any(e => e.CategoriaJugadorID == id);
        }
    }
}
