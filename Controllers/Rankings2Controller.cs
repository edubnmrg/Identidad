using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identidad.Models;
using Identidad.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Identidad.Controllers
{
    public class Rankings2Controller : Controller
    {
        private readonly AppDB _context;

        public Rankings2Controller(AppDB context)
        {
            _context = context;
        }

        // GET: Rankings
        public async Task<IActionResult> Index(int? id)
        {
            Rankings2VM RankVM = new Rankings2VM();
            RankVM.Categorias = await _context.Categorias
                .Where(c => c.categoriaID <8)
                .ToListAsync();
       
            if(id == null)
            {
                RankVM.CategoriaActiva = 0;
            }
            else 
            {
                RankVM.CategoriaActiva = (int)(id == null ? 0 : id);

            }

            var ran  = await _context.Rankings2
                .GroupBy(r => new { r.PerfilID, r.JuegoID, r.CategoriaID })  
                .Select(r => new { r.Key.PerfilID    ,
                                     r.Key.JuegoID,
                                     r.Key.CategoriaID,
                                    Puntos = r.Sum(r => r.Puntos)})
                .ToListAsync();
            
            foreach(var r in ran)
            {
                if(r.CategoriaID == RankVM.CategoriaActiva)
                {
                    Ranking2 r2 = new Ranking2();
                    r2.CategoriaID = r.CategoriaID;
                    r2.JuegoID = r.JuegoID;
                    r2.PerfilID = r.PerfilID;
                    r2.Puntos = r.Puntos;
                    RankVM.Rankings.Add(r2);
                }
            }
            return View(RankVM);
        }

        // GET: Rankings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ranking = await _context.Rankings2
                .Include(r => r.Perfil)
                .FirstOrDefaultAsync(m => m.RankingID == id);
            if (ranking == null)
            {
                return NotFound();
            }

            return View(ranking);
        }

        // GET: Rankings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rankings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RankingID,PerfilID,Categoria,Fecha,Puntos")] Ranking ranking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ranking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ranking);
        }

        // GET: Rankings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ranking = await _context.Rankings2.FindAsync(id);
            if (ranking == null)
            {
                return NotFound();
            }
            return View(ranking);
        }

        // POST: Rankings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RankingID,PerfilID,Categoria,Fecha,Puntos")] Ranking ranking)
        {
            if (id != ranking.RankingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ranking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RankingExists(ranking.RankingID))
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
            return View(ranking);
        }

        // GET: Rankings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ranking = await _context.Rankings2
                .Include(r => r.Perfil)
                .FirstOrDefaultAsync(m => m.RankingID == id);
            if (ranking == null)
            {
                return NotFound();
            }

            return View(ranking);
        }

        // POST: Rankings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ranking = await _context.Rankings2.FindAsync(id);
            _context.Rankings2.Remove(ranking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RankingExists(int id)
        {
            return _context.Rankings2.Any(e => e.RankingID == id);
        }
    }
}