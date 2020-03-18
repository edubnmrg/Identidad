using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Identidad.Models;
using Identidad.ViewModels;
using System.IO;

namespace Identidad.Controllers
{
    public class GaleriasController : Controller
    {
        private readonly AppDB _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public GaleriasController(AppDB context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Galerias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Galerias.ToListAsync());
        }

        // GET: Galerias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galeria = await _context.Galerias
                .FirstOrDefaultAsync(m => m.GaleriaId == id);
            if (galeria == null)
            {
                return NotFound();
            }

            return View(galeria);
        }

        // GET: Galerias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Galerias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GaleriaId,FotoPath,Fecha,Nota,Photo")] GaleriaViewModel galeria)
        {
            if (ModelState.IsValid)
            {
                Galeria Gal = new Galeria();
                Gal.Fecha = galeria.Fecha;
                Gal.Nota = galeria.Nota;
                if (galeria.Photo != null)
                {
                    Gal.FotoPath = ProcessUploadedFile(galeria);
                    if (galeria.Photo.ContentType.ToLower().StartsWith("image/"))
                    // Check whether the selected file is image
                    {

                        using (BinaryReader br = new BinaryReader(galeria.Photo.OpenReadStream()))
                        {
                            //per.foto = br.ReadBytes((int)galeria.Photo.OpenReadStream().Length);
                            // Convert the image in to bytes
                        }
                    }
                }
                _context.Add(Gal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(galeria);
        }

        // GET: Galerias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galeria = await _context.Galerias.FindAsync(id);
            if (galeria == null)
            {
                return NotFound();
            }
            return View(galeria);
        }

        // POST: Galerias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GaleriaId,FotoPath,Fecha,Nota")] Galeria galeria)
        {
            if (id != galeria.GaleriaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(galeria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GaleriaExists(galeria.GaleriaId))
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
            return View(galeria);
        }

        // GET: Galerias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galeria = await _context.Galerias
                .FirstOrDefaultAsync(m => m.GaleriaId == id);
            if (galeria == null)
            {
                return NotFound();
            }

            return View(galeria);
        }

        // POST: Galerias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var galeria = await _context.Galerias.FindAsync(id);
            _context.Galerias.Remove(galeria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private string ProcessUploadedFile(GaleriaViewModel model)
        {
            string uniqueFileName = null;
            string filePath = "";
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img\\Galeria");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            //return uniqueFileName;
            return uniqueFileName;
        }
        private bool GaleriaExists(int id)
        {
            return _context.Galerias.Any(e => e.GaleriaId == id);
        }
    }
}
