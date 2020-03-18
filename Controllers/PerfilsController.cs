using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Identidad.Models;
using Identidad.ViewModels;
using System.IO;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace Identidad.Controllers
{
    public class PerfilsController : Controller
    {
        private readonly AppDB _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<Usuario> _usermanager;

        public PerfilsController(AppDB context,IHostingEnvironment hostingEnvironment
            , UserManager<Usuario> usermanager)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _usermanager = usermanager;
        }

        // GET: Perfils
        public async Task<IActionResult> Index()
        {
            var appDB = _context.Perfiles
                .Include(p => p.club)
                .Include(p => p.Provincia)
                .Include(p => p.tipoDeDocumento);
            return View(await appDB.ToListAsync());
        }

        // GET: Perfils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                Perfil Perfil =  _context.Perfiles.Where(p => p.UserID == _usermanager.GetUserId(User)).FirstOrDefault();
                if (Perfil == null)
                {
                    return RedirectToAction("Create", "Perfils");
                }
                else
                {
                    id = Perfil.ID;
                }

            }

            var perfil = await _context.Perfiles
                .Include(p => p.club)
                .Include(p => p.Provincia)
                .Include(p => p.tipoDeDocumento)
                .FirstOrDefaultAsync(m => m.ID == id);
            PerfilDetailsVM PerfilDetails = new PerfilDetailsVM();
            List<CategoriaJugador> CategoriasJugador = await _context.CategoriasJugadores
                .Where(c => c.PerfilFK == perfil.ID)
                .Include(c=> c.Categoria)
                .Include(c => c.Juego)
                .ToListAsync();
            PerfilDetails.CategoriasJugador = new List<CategoriaJugador>();
            foreach(var c in CategoriasJugador)
            {
                PerfilDetails.CategoriasJugador.Add(c);
            }
            var rankings = await _context.Rankings2.Where(r => r.PerfilID == perfil.ID)
                .GroupBy(r => new { r.PerfilID , r.JuegoID, r.CategoriaID})
                .Select(  r => new  {  r.Key.PerfilID,  r.Key.JuegoID,r.Key.CategoriaID,Puntos = r.Sum( t=>t.Puntos)})
                .ToListAsync();
            PerfilDetails.Perfil = perfil;
            PerfilDetails.Rankings = new List<Ranking2>();
            foreach(var r in rankings)
            {
                Ranking2 r2 = new Ranking2();
                r2.PerfilID = r.PerfilID;
                r2.JuegoID = r.JuegoID;
                r2.Juego = _context.Juegoes.Find(r.JuegoID);
                r2.CategoriaID = r.CategoriaID;
                r2.Puntos = r.Puntos;
                PerfilDetails.Rankings.Add(r2);
            }
            if (perfil == null)
            {
                return RedirectToAction("Create", "Perfils", new { id });
            }

            return View(PerfilDetails);
        }

        // GET: Perfils/Create
        public IActionResult Create(string id)
        {
            ViewData["clubID"] = new SelectList(_context.Club, "ClubID", "NombreClub");
            ViewData["provinciaID"] = new SelectList(_context.Provincias, "ID", "nombre");
            ViewData["tDocID"] = new SelectList(_context.TipoDocumentos, "ID", "tipoDeDocumento");
            ViewData["usuario"] = _usermanager.GetUserId (User);
            return View();
        }

        // POST: Perfils/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nombre,apellido,tDocID,numeroDocumento,calle,altura,ciudad,provinciaID,provincia,Email,telefono,celular,clubID,foto,fotoPath,UserID,Photo")] EditPerfilViewModel perfil)
        {
            if (ModelState.IsValid)
            {
                Perfil per = new Perfil();
                perfil.ToParent(per);
                if (perfil.Photo != null) 
                {
                    per.fotoPath = ProcessUploadedFile(perfil);
                    if (perfil.Photo.ContentType.ToLower().StartsWith("image/"))
                    // Check whether the selected file is image
                    {
                       
                        using (BinaryReader br = new BinaryReader(perfil.Photo.OpenReadStream()))
                        {
                            per.foto = br.ReadBytes((int)perfil.Photo.OpenReadStream().Length);
                            // Convert the image in to bytes
                        }
                    }
                }
                _context.Add(per);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(perfil);
        }

        // GET: Perfils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}
            Usuario uId=new Usuario();
            Perfil perfil = new Perfil();
            if (id == null)
            {
                var userId = User.Identity.Name;
                uId= await _context.Usuarios.FirstOrDefaultAsync(t => t.UserName == userId);
                if (uId == null) 
                { 
                    return NotFound();
                } else 
                {
                    perfil = await _context.Perfiles.FirstOrDefaultAsync(t => t.UserID == uId.Id);
                    if (perfil == null)
                    {
                        return RedirectToAction("Create", "Perfils",  new  { id = uId.Id } );
                    }
                    else
                    {

                        return RedirectToAction("Edit", "Perfils", new { id = perfil.ID });
                    }
                }
                
            }else 
            { 
                perfil = await _context.Perfiles.FindAsync(id);

                if (perfil == null)
                {
                    return NotFound();
                }
            }
           
            ViewData["clubID"] = new SelectList(_context.Club, "ClubID", "NombreClub", perfil.clubID);
            ViewData["provinciaID"] = new SelectList(_context.Provincias, "ID", "nombre", perfil.provinciaID);
            ViewData["tDocID"] = new SelectList(_context.TipoDocumentos, "ID", "tipoDeDocumento", perfil.tDocID);

            EditPerfilViewModel perfilVM = new EditPerfilViewModel();
            perfilVM.FromParent(perfil);
            return View(perfilVM);
        }
        private string ProcessUploadedFile(EditPerfilViewModel model)
        {
            string uniqueFileName = null;
            string filePath = "";
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img\\fotosPerfiles");
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
        // POST: Perfils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,nombre,apellido,tDocID,numeroDocumento,calle,altura,ciudad,provinciaID,Email,telefono,celular,clubID,fotoPath,UserID,Photo")] EditPerfilViewModel perfilVM)
        {
            if (id != perfilVM.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Perfil perfil = new Perfil();
                perfilVM.ToParent(perfil);
                if (perfilVM.Photo != null)
                {
                    perfil.fotoPath = ProcessUploadedFile(perfilVM);
                    if (perfilVM.Photo.ContentType.ToLower().StartsWith("image/"))
                    // Check whether the selected file is image
                    {
                        using (BinaryReader br = new BinaryReader(perfilVM.Photo.OpenReadStream()))
                        {
                            perfil.foto = br.ReadBytes((int)perfilVM.Photo.OpenReadStream().Length);
                            // Convert the image in to bytes
                        }
                    }
                }
                try
                {
                    _context.Update(perfil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerfilExists(perfil.ID))
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
            ViewData["clubID"] = new SelectList(_context.Club, "ClubID", "NombreClub", perfilVM.clubID);
            ViewData["provinciaID"] = new SelectList(_context.Provincias, "ID", "nombre", perfilVM.provinciaID);
            ViewData["tDocID"] = new SelectList(_context.TipoDocumentos, "ID", "tipoDeDocumento", perfilVM.tDocID);

            return View(perfilVM);
        }

        // GET: Perfils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfil = await _context.Perfiles
                .Include(p => p.club).Include(p => p.Provincia)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (perfil == null)
            {
                return NotFound();
            }

            return View(perfil);
        }

        // POST: Perfils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var perfil = await _context.Perfiles.FindAsync(id);
            _context.Perfiles.Remove(perfil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerfilExists(int id)
        {
            return _context.Perfiles.Any(e => e.ID == id);
        }
    }
}
