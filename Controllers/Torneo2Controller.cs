using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Identidad.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using Identidad.ViewModels;

namespace Identidad.Controllers
{
    public class Torneo2Controller : Controller
    {
        private readonly AppDB _context;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        public Torneo2Controller(AppDB context, UserManager<Usuario> userManager
            , SignInManager<Usuario> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;

        }

        // GET: Torneo2
        public async Task<IActionResult> Index()
        {
            List<Torneo2> torList = await _context.Torneos2.ToListAsync();
            foreach (var item in torList)
            {
                item.Club = await _context.Club.FirstOrDefaultAsync(t => t.ClubID == item.ClubRefId);
                item.CatTor = await _context.CategoriasTorneos.FirstOrDefaultAsync(t => t.catTorneoID == item.CatTorRefId);
                item.CanJug = await _context.CantidadJugadores.FirstOrDefaultAsync(t => t.cantJugID == item.CanJugRefId);
                item.Cat = await _context.Categorias.FirstOrDefaultAsync(t => t.categoriaID == item.CatRefId);
                item.SisTor = await _context.SistemasTorneos.FirstOrDefaultAsync(t => t.sisTorID == item.SisTorRefId);

            }
            
            return View(torList);
        }

        // GET: Torneo2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var torneo2 = await _context.Torneos2
                .Include(t => t.Anotaciones).ThenInclude(a => a.Perfil)
                .FirstOrDefaultAsync(m => m.TorneoID == id);

            if (torneo2 == null) 
            {
                return NotFound();
            }
            torneo2.Anotaciones.OrderBy(t => t.Perfil.apellido);
            torneo2.Club = await _context.Club.FirstOrDefaultAsync(t => t.ClubID == torneo2.ClubRefId);
            torneo2.CatTor = await _context.CategoriasTorneos.FirstOrDefaultAsync(t => t.catTorneoID == torneo2.CatTorRefId);
            torneo2.CanJug = await _context.CantidadJugadores.FirstOrDefaultAsync(t => t.cantJugID == torneo2.CanJugRefId);
            torneo2.Cat = await _context.Categorias.FirstOrDefaultAsync(t => t.categoriaID == torneo2.CatRefId);
            torneo2.SisTor = await _context.SistemasTorneos.FirstOrDefaultAsync(t => t.sisTorID == torneo2.SisTorRefId);
            torneo2.Zones = await _context.Zones.Where(t => t.TorneoID == id).ToListAsync();
            return View(torneo2);
        }

        // GET: Torneo2/Create
        public IActionResult Create()
        {
            ViewData["ClubFK"] = new SelectList(_context.Club, "ClubID", "NombreClub");
            ViewData["CatTorFK"] = new SelectList(_context.CategoriasTorneos, "catTorneoID", "catTorneo");
            ViewData["CanJugFK"] = new SelectList(_context.CantidadJugadores, "cantJugID", "cantJug");
            ViewData["CatFK"] = new SelectList(_context.Categorias, "categoriaID", "categoria");
            ViewData["SisTorFK"] = new SelectList(_context.SistemasTorneos, "sisTorID", "sisTor");
            ViewData["Juegos"] = new SelectList(_context.Juegoes, "JuegoID", "nombreJuego");

            return View();
        }

        // POST: Torneo2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TorneoID,NombreTorneo,ClubRefId,CatTorRefId,CanJugRefId,CatRefId,SisTorRefId,Desde,Hasta,ValorInscripcion,Notas")] Torneo2 torneo2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(torneo2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClubRefId"] = new SelectList(_context.Club, "ClubID", "NombreClub", torneo2.ClubRefId);
            return View(torneo2);
        }

        // GET: Torneo2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var torneo2 = await _context.Torneos2.FindAsync(id);
            if (torneo2 == null)
            {
                return NotFound();
            }
            ViewData["ClubFK"] = new SelectList(_context.Club, "ClubID", "NombreClub",torneo2.ClubRefId);
            ViewData["CatTorFK"] = new SelectList(_context.CategoriasTorneos, "catTorneoID", "catTorneo",torneo2.CatTorRefId);
            ViewData["CanJugFK"] = new SelectList(_context.CantidadJugadores, "cantJugID", "cantJug",torneo2.CanJugRefId);
            ViewData["CatFK"] = new SelectList(_context.Categorias, "categoriaID", "categoria",torneo2.CatRefId);
            ViewData["SisTorFK"] = new SelectList(_context.SistemasTorneos, "sisTorID", "sisTor",torneo2.SisTorRefId);
            ViewData["Juegos"] = new SelectList(_context.Juegoes, "JuegoID", "nombreJuego");

            return View(torneo2);
        }

        // POST: Torneo2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TorneoID,NombreTorneo,ClubRefId,CatTorRefId,CanJugRefId,CatRefId,JuegoID,SisTorRefId,Desde,Hasta,ValorInscripcion,Notas,InscripcionCerrada,ZonasCerradas, CrucesCerrados, TorneoCerrado")] Torneo2 torneo2)
        {
            if (id != torneo2.TorneoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(torneo2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Torneo2Exists(torneo2.TorneoID))
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
            ViewData["ClubRefId"] = new SelectList(_context.Club, "ClubID", "NombreClub", torneo2.ClubRefId);
            return View(torneo2);
        }

        // GET: Torneo2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var torneo2 = await _context.Torneos2.FirstOrDefaultAsync(m => m.TorneoID == id);
            if (torneo2 == null)
            {
                return NotFound();
            }
            torneo2.Club = await _context.Club.FirstOrDefaultAsync(t => t.ClubID == torneo2.ClubRefId);
            torneo2.CatTor = await _context.CategoriasTorneos.FirstOrDefaultAsync(t => t.catTorneoID == torneo2.CatTorRefId);
            torneo2.CanJug = await _context.CantidadJugadores.FirstOrDefaultAsync(t => t.cantJugID == torneo2.CanJugRefId);
            torneo2.Cat = await _context.Categorias.FirstOrDefaultAsync(t => t.categoriaID == torneo2.CatRefId);
            torneo2.SisTor = await _context.SistemasTorneos.FirstOrDefaultAsync(t => t.sisTorID == torneo2.SisTorRefId);

            return View(torneo2);
        }

        // POST: Torneo2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var torneo2 = await _context.Torneos2.FindAsync(id);
            _context.Torneos2.Remove(torneo2);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Inscribirme(int id)
        {
            var torneo = await _context.Torneos2.FindAsync(id);
            Anotacion anotacion = new Anotacion();
            string uid = _userManager.GetUserId(User);
            Perfil miPerfil = await _context.Perfiles.FirstOrDefaultAsync(p => p.UserID == uid);

            if(!EstoyAnotado(miPerfil.ID, torneo.TorneoID)) 
            {
                anotacion.PerfilRefId = miPerfil.ID;
                anotacion.TorneoRefId = id;
                await _context.Anotaciones.AddAsync(anotacion);
                await _context.SaveChangesAsync();
                return RedirectToAction("InscriptosAlTorneo", "Anotaciones", new { id = torneo.TorneoID });
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Inscriptos(int id)
        {
            var torneo = await _context.Torneos2.FindAsync(id);
            List<Anotacion> inscriptos = new List<Anotacion>();

            inscriptos = await _context.Anotaciones.Where(i => i.TorneoRefId == id).ToListAsync();
            return RedirectToAction("InscriptosAlTorneo", "Anotaciones", new { id = torneo.TorneoID });
        }

        public async Task<IActionResult> AsignarZonas(int id)
        {
            int j = 0;
          
            var hayZonas = await _context.Zones.Where(z => z.TorneoID == id).ToListAsync();
            if(hayZonas.Count == 0 ) 
            {
                var anotados = await _context.Anotaciones.Where(z => z.TorneoRefId == id).ToListAsync();
                if( anotados.Count >0) 
                {
                    j = anotados.Count % 4;
                    if (j != 0) { j = 1; }
                    List<Zone> zonas = new List<Zone>();
                    for (int i = 0; i < (anotados.Count / 4) + j; i++)
                    {
                        Zone z = new Zone();
                        z.Numero = i+1;
                        z.TorneoID = id;
                        z.CantidadJugadores = 4;
                        zonas.Add(z);
                    }
                    _context.Zones.AddRange(zonas);
                    _context.SaveChanges();
                }
                
            }
            var torneo2 = await _context.Torneos2
                .Include(t => t.Anotaciones).ThenInclude(a => a.Perfil)
                .FirstOrDefaultAsync(m => m.TorneoID == id);
            if (torneo2 == null)
            {
                return NotFound();
            }
            torneo2.Club = await _context.Club.FirstOrDefaultAsync(t => t.ClubID == torneo2.ClubRefId);
            torneo2.CatTor = await _context.CategoriasTorneos.FirstOrDefaultAsync(t => t.catTorneoID == torneo2.CatTorRefId);
            torneo2.CanJug = await _context.CantidadJugadores.FirstOrDefaultAsync(t => t.cantJugID == torneo2.CanJugRefId);
            torneo2.Cat = await _context.Categorias.FirstOrDefaultAsync(t => t.categoriaID == torneo2.CatRefId);
            torneo2.SisTor = await _context.SistemasTorneos.FirstOrDefaultAsync(t => t.sisTorID == torneo2.SisTorRefId);
            torneo2.Zones = await _context.Zones.Where(z => z.TorneoID == id).ToListAsync();

            return View(torneo2);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> GuardarZonas(int id, [Bind("TorneoID,NombreTorneo,ClubRefId,CatTorRefId,CanJugRefId,CatRefId,SisTorRefId,Desde,Hasta,ValorInscripcion,Notas")] Torneo2 torneo2)
        //{
        //    return RedirectToAction(nameof(Index));
        //}

        [HttpGet]
        public async Task<IActionResult> ZonasAutomaticas(int id)
        { 
            int listIx = 0;
            List<ZonaJugador> zonaJugador = new List<ZonaJugador>();
            List<Zone> Zonas = GenerarZonas(id);
            List<Anotacion> anotados = await _context.Anotaciones.Where(a => a.TorneoRefId == id).ToListAsync();
            for (int i =1;i < 5; i++)
            {
                for (int j = 0; j < Zonas.Count  ; j++)
                {
                    ZonaJugador zj = new ZonaJugador();
                    zj.ZonaID = Zonas[j].ZonaID;
                    zj.posicion = i;
                    zj.PerfilID = anotados[listIx].PerfilRefId;
                  
                    zonaJugador.Add(zj);
                    listIx++;
                    if (listIx > anotados.Count()-1)
                    {
                        break;
                    }
                }
            }
            await _context.ZonasJugadores.AddRangeAsync(zonaJugador);
            await _context.SaveChangesAsync();

            //List<Partido> ps = GenerarPartidosIniciales(Zonas);
            await _context.Partidos.AddRangeAsync(GenerarPartidosIniciales(Zonas));
            Torneo2 T = _context.Torneos2.Find(id);
            T.InscripcionCerrada = true;
            _context.Update(T);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Zones", new { id }); 
        }

        private  List<Zone> GenerarZonas(int torneoId)
        {
            int j = 0;

            var hayZonas =  _context.Zones.Where(z => z.TorneoID == torneoId).ToList();
            if (hayZonas.Count == 0)
            {
                var anotados =  _context.Anotaciones.Where(z => z.TorneoRefId == torneoId).ToList();
                if (anotados.Count > 0)
                {
                    j = anotados.Count % 4;
                    if (j != 0) { j = 1; }
                    List<Zone> zonas = new List<Zone>();
                    for (int i = 0; i < (anotados.Count / 4) + j; i++)
                    {
                        Zone z = new Zone();
                        z.Numero = i + 1;
                        z.TorneoID = torneoId;
                        z.CantidadJugadores = 4;
                        zonas.Add(z);
                    }
                    _context.Zones.AddRange(zonas);
                    //_context.SaveChanges();
                    using (var transaction = _context.Database.BeginTransaction())
                    {
                        try
                        {
                            _context.SaveChanges();              

                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                        }
                    }
                    return zonas;

                }
            }
            return hayZonas;
        }

        public async Task<ActionResult> Administrar(int id)
        {
            int tid = id / 100;
            ViewData["activa"] = id % 100;
            Torneo2ViewModel torView = new Torneo2ViewModel();
            torView.ZonaActiva= id % 100-1;
            torView.Tor = await _context.Torneos2
                .Include(t => t.Zones)
                .Where(t => t.TorneoID == tid)
                .FirstOrDefaultAsync();
            if(torView.Tor.Zones.Count() > 0) {
                
                torView.Tor.SisTor = await _context.SistemasTorneos.Where(s => s.sisTorID == torView.Tor.SisTorRefId).FirstAsync();
                //foreach(Zone zn in torView.Tor.Zones)
                //{
                Zone zn = torView.Tor.Zones[torView.ZonaActiva];
                zn.ZonaJugadores = await _context.ZonasJugadores.Where(z => z.ZonaID == zn.ZonaID)
                    .Include(j => j.Perfil)
                    .OrderBy(j => j.posicion)
                    .ToListAsync();
                zn.Partidos = await _context.Partidos.Where(z => z.ZonaId == zn.ZonaID)
                    .Include(j => j.Scores).OrderBy(p => p.PartidoNumero)
                    .ToListAsync();
                torView.apellidos = new List<String>();
                for (int p = 0; p < zn.Partidos.Count(); p++)
                {
                    if (zn.Partidos[p].Jugador1Id > 0)
                    {
                        torView.apellidos.Add(_context.Perfiles.Where(s => s.ID == zn.Partidos[p].Jugador1Id).FirstOrDefault().NombreTorneo);

                    }
                    else
                    {
                        torView.apellidos.Add("-----");
                    }
                    if (zn.Partidos[p].Jugador2Id > 0)
                    {
                        torView.apellidos.Add(_context.Perfiles.Where(s => s.ID == zn.Partidos[p].Jugador2Id).FirstOrDefault().NombreTorneo);

                    }
                    else
                    {
                        torView.apellidos.Add("-----");
                    }
                    await CargarScoresAsync(zn.Partidos[p], torView.Tor.SisTor.CantSets);

                }
                //}
                torView.Partidos = new List<List<int>>();


                for (int j = 0; j < torView.Tor.Zones[torView.ZonaActiva].Partidos.Count(); j++)
                {

                    List<int> p = new List<int>();
                    for (int k = 0; k < torView.Tor.Zones[torView.ZonaActiva].Partidos[j].Scores.Count(); k++)
                    {
                        p.Add(torView.Tor.Zones[torView.ZonaActiva].Partidos[j].Scores[k].Score1);
                        p.Add(torView.Tor.Zones[torView.ZonaActiva].Partidos[j].Scores[k].Score2);

                    }
                    torView.Partidos.Add(p);
                }

                //for(int i=0; i < 4; i++)
                //{
                //    torView.Partidos.Add(new List<int>());
                //    torView.Partidos[i] = new List<int>();
                //    for(int j=0; j < torView.Tor.SisTor.CantSets *2; j++)
                //    {
                //        torView.Partidos[i].Add(0);

                //    }

                //}
                return View(torView);
            }

            return RedirectToAction("Details","Torneo2",new { id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ActualizarResultados([Bind("Tor","Partidos", "ZonaActiva")] Torneo2ViewModel torVM)
        {
            int tn = torVM.Tor.TorneoID;
            //int z = id % 100;
            int zonasCerradas = 0;

            var tor = await _context.Torneos2.Where(t => t.TorneoID == tn)
               .Include(t => t.Zones)
               .Include(t => t.SisTor)
               .FirstOrDefaultAsync();
            tor.SisTor = await _context.SistemasTorneos.Where(s => s.sisTorID == tor.SisTorRefId).FirstAsync();
            for(int par = 0; par < torVM.Partidos.Count(); par ++)
            {
                Zone z = tor.Zones[ torVM.ZonaActiva-1];
                Partido partidoGuardado = await _context.Partidos.Where(p => p.ZonaId == tor.Zones[torVM.ZonaActiva-1].ZonaID && p.PartidoNumero == par + 1).FirstAsync();
                if (partidoGuardado == null)
                {
                    Partido partidoNuevo = new Partido();
                }
                else
                {
                    if (!partidoGuardado.Cerrado)
                    {
                        if (partidoGuardado.Jugador2Id < 1)
                        {
                            partidoGuardado.Cerrado = true;
                            partidoGuardado.Ganador = partidoGuardado.Jugador1Id;
                            _context.Partidos.Update(partidoGuardado);
                            await _context.SaveChangesAsync();

                        }
                        else 
                        { 
                        List<Score> listaScore = await _context.Scores.Where(s => s.PartidoId == partidoGuardado.PartidoId).OrderBy(o => o.NumeroSet).ToListAsync();
                        if (listaScore.Count() > 0)
                        {
                            foreach (Score s in listaScore)
                            {
                                _context.Scores.Remove(s);

                            }
                            await _context.SaveChangesAsync();

                        }
                        int partidoA = tor.SisTor.Puntos;
                        int j1 = 0;
                        int j2 = 0;
                        List<Score> scores = new List<Score>();
                        for (int p = 0; p < torVM.Partidos[par].Count / 2; p++)
                        {

                            Score sc = new Score();
                            sc.PartidoId = partidoGuardado.PartidoId;
                            sc.NumeroSet = p + 1;
                            sc.Score1 = torVM.Partidos[par][2 * p] > partidoA ? partidoA : torVM.Partidos[par][2 * p];
                            if (sc.Score1 == partidoA) { j1++; }

                            sc.Score2 = torVM.Partidos[par][2 * p + 1] > partidoA ? partidoA : torVM.Partidos[par][2 * p + 1];
                            if (sc.Score2 == partidoA) { j2++; }
                            if (!(sc.Score1 == 0 && sc.Score2 == 0))
                            {
                                scores.Add(sc);

                            }

                        }
                        _context.Scores.AddRange(scores);
                        await _context.SaveChangesAsync();

                        if (j1 > tor.SisTor.CantSets / 2)
                        {
                            partidoGuardado.Cerrado = true;
                            partidoGuardado.Ganador = partidoGuardado.Jugador1Id;
                            _context.Partidos.Update(partidoGuardado);
                            await _context.SaveChangesAsync();

                        }
                        if (j2 > tor.SisTor.CantSets / 2)
                        {
                            partidoGuardado.Cerrado = true;
                            partidoGuardado.Ganador = partidoGuardado.Jugador2Id;
                            _context.Partidos.Update(partidoGuardado);
                            await _context.SaveChangesAsync();

                        }
                        }
                        switch (partidoGuardado.PartidoNumero)
                        {
                            case 1:
                                if (partidoGuardado.Cerrado)
                                {
                                    await GenerarPartidos3y4(partidoGuardado, 2);

                                }

                                break;
                            case 2:
                                if (partidoGuardado.Cerrado)
                                {
                                    await GenerarPartidos3y4(partidoGuardado, 1);
                                }
                                break;
                            case 3:
                                if (partidoGuardado.Cerrado)
                                {
                                    await GenerarPartido5(partidoGuardado, 4);
                                }
                                break;
                            case 4:
                                if (partidoGuardado.Cerrado)
                                {
                                    await GenerarPartido5(partidoGuardado, 3);
                                }
                                break;
                            case 5:
                                if (partidoGuardado.Cerrado)
                                {
                                    zonasCerradas = await CerrarZona(partidoGuardado, tor);
                                }
                                break;
                            default:
                                break;
                        }
                    
                    }

                    
                }

            }
            if(zonasCerradas == -2)
            {
                int idTor = tor.TorneoID * 100 + torVM.ZonaActiva;
                return RedirectToAction("AdministrarCruces", "Torneo2", new {  idTor });
            }
            else
            {
                int idTor = tor.TorneoID * 100 + torVM.ZonaActiva;
                return RedirectToAction("Administrar", "Torneo2", new { id = idTor });

            }
            //return View(tor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AdministrarCruces([Bind("Torneo", "Clasificados", "Partidos")] CrucesViewModel Cruces)
        {
            bool crucesCerrados = true;
   
            for (int p = 0; p< Cruces.Partidos.Count(); p++)
            {
                Partido par = Cruces.Partidos[p];
                if (!par.Cerrado)
                {
                    int j1 = 0;
                    int j2 = 0;
                    List<Score> Scores = new List<Score>();
                    for (int s = 0; s < par.Scores.Count(); s++)
                    {
                        Scores.Add(par.Scores[s]);
                        j1 = par.Scores[s].Score1 == Cruces.Torneo.SisTor.Puntos ? j1 + 1 : j1;
                        j2 = par.Scores[s].Score2 == Cruces.Torneo.SisTor.Puntos ? j2 + 1 : j2;

                    }
                    if (j1 > Cruces.Torneo.SisTor.CantSets / 2)
                    {
                        //Partido pr = await _context.Partidos.Where(p => p.PartidoId == par.PartidoId).FirstOrDefaultAsync();
                        par.Cerrado = true;
                        par.Ganador = par.Jugador1Id;
                        _context.Update(par);
                        await _context.SaveChangesAsync();

                        EliminarClasificado(par.Jugador2Id);
                        ActualizarRanking(par.Jugador1Id, Cruces.Torneo, 2);
                        await _context.SaveChangesAsync();
                    }
                    if (j2 > Cruces.Torneo.SisTor.CantSets / 2)
                    {
                        par.Cerrado = true;
                        par.Ganador = par.Jugador2Id;
                        _context.Update(par);
                        EliminarClasificado(par.Jugador1Id);
                        ActualizarRanking(par.Jugador2Id, Cruces.Torneo, 2);
                        await _context.SaveChangesAsync();
                    }
                }
                
                crucesCerrados = crucesCerrados && par.Cerrado;
            }
            if (crucesCerrados)
            {
                Cruces.Torneo.CrucesCerrados = true;
                Torneo2 Tor = _context.Torneos2.Where(t => t.TorneoID == Cruces.Torneo.TorneoID).FirstOrDefault();
                Tor.CrucesCerrados = true;
                _context.Update(Tor);
                await _context.SaveChangesAsync();
                await OrganizarEliminatoriaAsync(Cruces.Torneo);
                return RedirectToAction("AdministrarEliminatoria", "Torneo2", new { id = Cruces.Torneo.TorneoID  });

            }
            return RedirectToAction("AdministrarCruces", "Torneo2", new { id = Cruces.Torneo.TorneoID *100 });

        }
        private void EliminarClasificado(int id)
        {
            Clasificado NoClasificado = _context.Clasificados.Where(c => c.PerfilID == id).FirstOrDefault();
            if (!(NoClasificado == null))
            {
                Eliminado Eliminado = new Eliminado();
                Eliminado.PerfilID = NoClasificado.PerfilID;
                Eliminado.Puesto = NoClasificado.Puesto;
                Eliminado.Promedio = NoClasificado.Promedio;
                Eliminado.TorneoID = NoClasificado.TorneoID;
                _context.Eliminados.Add(Eliminado);
                _context.Clasificados.Remove(NoClasificado);

            }

        }

        private void ActualizarRanking(int JugadorId, Torneo2 Torneo, int ronda)
        {
            CategoriaJugador CatJug = _context.CategoriasJugadores
                .Where(c => c.PerfilFK == JugadorId && c.JuegoFK == Torneo.JuegoID).FirstOrDefault();
            Ranking2 Rank = new Ranking2();
            Rank.PerfilID = JugadorId;
            Rank.CategoriaID = CatJug.CategoriaFK;
            Rank.JuegoID = Torneo.JuegoID;
            Rank.Fecha = Torneo.Hasta;
            Rank.Puntos = ronda;
            _context.Rankings2.Add(Rank);
            _context.SaveChanges();
        }

        [HttpGet]
        public async Task<ActionResult> AdministrarCruces(int id)
        {
            int tid = id / 100;
            CrucesViewModel Cruces = new CrucesViewModel();

            Cruces.Partidos = await _context.Partidos.Include(p => p.Scores)
                .Where(p => p.TorneoID == tid && p.EtapaId == 9).ToListAsync();
            if (Cruces.Partidos.Count() > 0)
            {
                Cruces.Torneo = await _context.Torneos2.FirstOrDefaultAsync(t => t.TorneoID == tid);
                Cruces.Torneo.SisTor = await _context.SistemasTorneos.Where(s => s.sisTorID == Cruces.Torneo.SisTorRefId).FirstOrDefaultAsync();
                Cruces.Clasificados = await _context.Clasificados
                    .Include(c => c.Perfil)
                    .Where(c => c.TorneoID == tid).ToListAsync();

                foreach (Partido p in Cruces.Partidos)
                {
                    p.Perfil1 = await _context.Perfiles.Where(x => x.ID == p.Jugador1Id).FirstOrDefaultAsync();
                    p.Perfil = await _context.Perfiles.Where(x => x.ID == p.Jugador2Id).FirstOrDefaultAsync();
                    await CargarScoresAsync(p, Cruces.Torneo.SisTor.CantSets);
                }

                return View(Cruces);
            }
            return RedirectToAction("Details","Torneo2",new { id = (id/100)});
        }
        [HttpGet]
        public async Task<ActionResult> AdministrarEliminatoria(int id)
        {
            Torneo2 Torneo = await _context.Torneos2.Where(t => t.TorneoID == id)
                .Include(t => t.SisTor)
                .FirstOrDefaultAsync();
            if (Torneo.CrucesCerrados) 
            { 
                ViewData["Nombre"] = Torneo.NombreTorneo;
                List<Partido> Partidos = new List<Partido>();
                var par = await _context.Partidos.Where(p => p.TorneoID == id && p.Ronda>=3)
                    .OrderBy(p => p.PartidoNumero)
                    .ToListAsync();
                Torneo.Matches = par.ToList();
                foreach(Partido p in Torneo.Matches)
                {
                    if (p.Jugador1Id != -1)
                    {
                        p.Perfil1 = await _context.Perfiles.Where(pf => pf.ID == p.Jugador1Id).FirstAsync();
                    }
                    if (p.Jugador2Id != -1)
                    {
                        p.Perfil = await _context.Perfiles.Where(pf => pf.ID == p.Jugador2Id).FirstAsync();
                    }
                    p.Scores = await _context.Scores.Where(s => s.PartidoId == p.PartidoId).ToListAsync();
                }
                return View(Torneo);
            }
            else
            {
                return RedirectToAction("Details", "Torneo2", new { Torneo.TorneoID });

            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> AdministrarEliminatoria([Bind("Matches", "SisTorRefId", "Hasta", "Cerrado", "Ronda", "TorneoID")] Torneo2 Torneo)
        {
            if (Torneo.Matches.Count() > 0)
            {

            
            Torneo.SisTor = _context.SistemasTorneos.Find(Torneo.SisTorRefId);
            foreach (Partido p in Torneo.Matches)
            {
                if (!p.Cerrado)
                {
                    //foreach(Score s in p.Scores)
                    //{
                    //    _context.Scores.Remove(s);
                    //}
                    //await _context.SaveChangesAsync();
                    List<Score> newScores = new List<Score>();
                    int j1 = 0;
                    int j2 = 0;
                    for (int i = 0; i < p.Scores.Count(); i++)
                    {
                        if (p.Scores[i].Score1 == Torneo.SisTor.Puntos)
                        {
                            j1++;
                        }
                        if (p.Scores[i].Score2 == Torneo.SisTor.Puntos)
                        {
                            j2++;
                        }
                        _context.Update(p.Scores[i]);

                    }
                    //_context.Scores.AddRange(newScores);
                    await _context.SaveChangesAsync();
                    if (j1 > Torneo.SisTor.CantSets / 2)
                    {
                        p.Cerrado = true;
                        p.Ganador = p.Jugador1Id;
                        _context.Update(p);
                        //actualizar ranking
                        Ranking2 rank = await _context.Rankings2.Where(r => r.PerfilID == p.Jugador1Id && r.Fecha == Torneo.Hasta).FirstOrDefaultAsync();
                        rank.Puntos = (int)Math.Pow(2, p.Ronda - 1);
                        _context.Update(rank);
                    }
                    if (j2 > Torneo.SisTor.CantSets / 2)
                    {
                        p.Cerrado = true;
                        p.Ganador = p.Jugador2Id;
                        _context.Update(p);
                        Ranking2 rank = await _context.Rankings2.Where(r => r.PerfilID == p.Jugador2Id && r.Fecha == Torneo.Hasta).FirstOrDefaultAsync();
                        rank.Puntos = (int)Math.Pow(2, p.Ronda - 1);
                        _context.Update(rank);

                    }
                    if (p.Cerrado)
                    {
                        //borrar los scores sobrantes
                        newScores = await _context.Scores
                       .Where(s => s.PartidoId == p.PartidoId && (s.Score1 == 0 && s.Score2 == 0))
                       .ToListAsync();
                        _context.RemoveRange(newScores);
                        //pasar ganador a partido siguiente
                        int partidoSiguiente = AsignarPartido(p);
                        if (partidoSiguiente > 0)
                        {
                            Partido nuevoPartido = await _context.Partidos.Where(p => p.PartidoNumero == partidoSiguiente && p.TorneoID==Torneo.TorneoID).FirstAsync();
                            if (nuevoPartido.Jugador1Id < 0)
                            {
                                nuevoPartido.Jugador1Id = p.Ganador;
                            }
                            else
                            {
                                nuevoPartido.Jugador2Id = p.Ganador;

                            }
                            _context.Update(nuevoPartido);
                        }


                        if (TorneoCerrado(Torneo))
                        {
                            Torneo2 T = _context.Torneos2.Find(Torneo.TorneoID);
                            T.TorneoCerrado = true;
                            _context.Update(T);
                        }
                    }

                    _context.SaveChanges();
                }
            }
                return RedirectToAction("AdministrarEliminatoria", "Torneo2", new { Torneo.TorneoID });

            }
            else
            {
                return RedirectToAction("Details", "Torneo2", new { Torneo.TorneoID });

            }
        }
        private bool TorneoCerrado(Torneo2 Torneo)
        {
            bool Cerrado = true;
            foreach(Partido p in Torneo.Matches)
            {
                Cerrado = Cerrado && p.Cerrado;
            }
            return Cerrado;
        }
        private int AsignarPartido(Partido p)
        {
            switch (p.PartidoNumero)
            {
                 case 1:
                    return 9;
                case 2:
                    return 10;
                case 3:
                    return 12;
                case 4:
                    return 11;
                case 5:
                    return 10;
                case 6:
                    return 11;
                case 7:
                    return 12;
                case 8:
                    return 9;
                case 9:
                    return 13;
                case 10:
                    return 14;
                case 11:
                    return 14;
                case 12:
                    return 13;
                case 13:
                    return 15;
                case 14:
                    return 15;
                default:
                    return 0;
            }
               
        }
        private List<Partido> GenerarPartidosIniciales(List<Zone> zonas)
        {
            List<Partido> partidos = new List<Partido>();
            foreach(Zone z in zonas)
            {
                var zj =  _context.ZonasJugadores.Where(t => t.ZonaID == z.ZonaID).OrderBy(j=>j.posicion).ToList();
                Partido p1 = new Partido(  );
                p1.PartidoId = 0;
                p1.Jugador1Id = zj[0].PerfilID;
                p1.Jugador2Id = zj[1].PerfilID;
                p1.ZonaId = z.ZonaID;
                p1.EtapaId = 1;
                p1.Ronda = 1;
                p1.PartidoNumero = 1;
                p1.Cerrado = false;
                p1.TorneoID = z.TorneoID;
                partidos.Add(p1);                
                Partido p2 = new Partido();
                p2.PartidoId = 0;
                p2.Jugador1Id = zj[2].PerfilID;
                if (zj.Count() == 4)
                {
                    p2.Jugador2Id = zj[3].PerfilID;

                }
                else
                {
                    p2.Jugador2Id = 0;
                    //p2.Cerrado = true;
                    //p2.Ganador = p2.Jugador1Id;
                  
                }
                p2.ZonaId = z.ZonaID;
                p2.EtapaId = 1;
                p2.Ronda = 1;
                p2.PartidoNumero = 2;
                
                p2.TorneoID = z.TorneoID;

                partidos.Add(p2);

            }
            return partidos;
        }
        private  async Task<int> GenerarPartidos3y4(Partido partidoGuardado, int numero)
        {
            Partido partidoDos = _context.Partidos.Where(p => p.PartidoNumero == numero && p.ZonaId==partidoGuardado.ZonaId).FirstOrDefault();
            if (partidoDos.Cerrado)
            {
                Partido partido3 = new Partido();
                partido3.Jugador1Id = partidoGuardado.Ganador;
                partido3.Jugador2Id = partidoDos.Ganador;
                partido3.ZonaId = partidoGuardado.ZonaId;
                partido3.EtapaId = 1;
                partido3.Ronda = 1;
                partido3.PartidoNumero = 3;
                partido3.Cerrado = false;
                partido3.Ganador = 0;
                partido3.TorneoID = partidoGuardado.TorneoID;

                Partido partido4 = new Partido();
                partido4.Jugador1Id = partidoGuardado.Ganador == partidoGuardado.Jugador1Id ? partidoGuardado.Jugador2Id : partidoGuardado.Jugador1Id;
                partido4.Jugador2Id = partidoDos.Ganador == partidoDos.Jugador1Id ? partidoDos.Jugador2Id : partidoDos.Jugador1Id;
                partido4.ZonaId = partidoGuardado.ZonaId;
                partido4.EtapaId = 1;
                partido4.Ronda = 1;
                partido4.PartidoNumero = 4;
                partido4.Cerrado = false;
                partido4.Ganador = 0;
                partido4.TorneoID = partidoGuardado.TorneoID;

                _context.Partidos.Add(partido3);
                _context.Partidos.Add(partido4);

            }
            return await _context.SaveChangesAsync();
            
        }
        private async Task<int> GenerarPartido5(Partido partidoGuardado, int numero) 
        {
            Partido partidoDos = _context.Partidos.Where(p => p.PartidoNumero == numero && p.ZonaId==partidoGuardado.ZonaId).FirstOrDefault();
            if (partidoDos.Cerrado)
            {
                Partido partido5 = new Partido();
                partido5.Jugador1Id = partidoDos.Ganador== partidoDos.Jugador1Id? partidoDos.Jugador2Id: partidoDos.Jugador1Id;
                partido5.Jugador2Id = partidoGuardado.Ganador;
                partido5.ZonaId = partidoGuardado.ZonaId;
                partido5.EtapaId = 1;
                partido5.Ronda = 1;
                partido5.PartidoNumero = 5;
                partido5.Cerrado = false;
                partido5.Ganador = 0;
                partido5.TorneoID = partidoGuardado.TorneoID;

                _context.Partidos.Add(partido5);

            }
            return await _context.SaveChangesAsync();

        }
        private async Task<int> CerrarZona(Partido partidoGuardado, Torneo2 Torneo)
        {
            Clasificado Primero = new Clasificado();
            Clasificado Segundo = new Clasificado();
            List<Partido> PartidoPrimero = await _context.Partidos.Where(p => p.ZonaId == partidoGuardado.ZonaId)
                .OrderBy(p => p.PartidoNumero).ToListAsync();
            Primero.TorneoID = Torneo.TorneoID;
            Primero.PerfilID = PartidoPrimero[2].Ganador;
            List<Partido> PartidosGanador = PartidoPrimero
                .Where(p => p.Jugador1Id == Primero.PerfilID || p.Jugador2Id == Primero.PerfilID).ToList();
            int Afavor = 0;
            int EnContra = 0;
            foreach(Partido par in PartidosGanador)
            {
                int PosicionPartido = par.Jugador1Id == Primero.PerfilID ? 1 : 2;
                List<Score> Scores = await _context.Scores.Where(s => s.PartidoId == par.PartidoId).ToListAsync();
                foreach(Score sco in Scores)
                {
                    if(PosicionPartido == 1)
                    {
                        Afavor += sco.Score1;
                        EnContra += sco.Score2;
                    }
                    else
                    {
                        Afavor += sco.Score2;
                        EnContra += sco.Score1;
                    }
                }
            }
            Primero.Puesto = 1;
            Primero.Promedio = (float)Afavor / (float)EnContra;
            _context.Clasificados.Add(Primero);

            Ranking2 Rank1 = new Ranking2();
            Rank1.PerfilID = Primero.PerfilID;
            Rank1.Fecha = Torneo.Hasta;

            CategoriaJugador cat = await _context.CategoriasJugadores
                .Where(c => c.PerfilFK == Primero.PerfilID && c.JuegoFK == 1).FirstOrDefaultAsync();
            Rank1.CategoriaID = cat.CategoriaFK;
            Rank1.JuegoID = Torneo.JuegoID;
            Rank1.Puntos = 2;
            _context.Rankings2.Add(Rank1);

            Segundo.TorneoID = Torneo.TorneoID;
            Segundo.PerfilID = partidoGuardado.Ganador;
            List<Partido> PartidoSegundo = await _context.Partidos.Where(p => p.ZonaId == partidoGuardado.ZonaId)
                .OrderBy(p => p.PartidoNumero).ToListAsync();
            List<Partido> PartidosEscolta = PartidoSegundo
              .Where(p => p.Jugador1Id == Segundo.PerfilID || p.Jugador2Id == Segundo.PerfilID).ToList();
            Afavor = 0;
            EnContra = 0;
            foreach (Partido par in PartidosEscolta)
            {
                int PosicionPartido = par.Jugador1Id == Segundo.PerfilID ? 1 : 2;
                List<Score> Scores = await _context.Scores.Where(s => s.PartidoId == par.PartidoId).ToListAsync();
                foreach (Score sco in Scores)
                {
                    if (PosicionPartido == 1)
                    {
                        Afavor += sco.Score1;
                        EnContra += sco.Score2;
                    }
                    else
                    {
                        Afavor += sco.Score2;
                        EnContra += sco.Score1;
                    }
                }
            }
            Segundo.Puesto = 2;
            Segundo.Promedio = (float)Afavor / (float) EnContra;
            _context.Clasificados.Add(Segundo);

            Ranking2 Rank2 = new Ranking2();
            Rank2.PerfilID = Segundo.PerfilID;
            Rank2.Fecha = Torneo.Hasta;
            cat = await _context.CategoriasJugadores
                .Where(c => c.PerfilFK == Segundo.PerfilID && c.JuegoFK == 1).FirstOrDefaultAsync();
            Rank2.CategoriaID = cat.CategoriaFK;
            Rank2.JuegoID = Torneo.JuegoID;
            Rank2.Puntos = 1;
            _context.Rankings2.Add(Rank2);
            await _context.SaveChangesAsync();
            if (ZonasCerradas(Torneo.TorneoID).Result)
            {
                Torneo.ZonasCerradas = true;
                _context.Update(Torneo);
                await _context.SaveChangesAsync();

                int x = await OrganizarCrucesAsync(Torneo.TorneoID);
                switch (x)
                {
                    case -1:
                        break;
                    case 0:
                        int eliminatoria = await OrganizarEliminatoriaAsync(Torneo);

                        break;
                    default:
                        break;
                }
            }
            return -2;
        }
        private async Task<int> CargarScoresAsync(Partido p, int nroSets)
        {
            p.Scores = await _context.Scores.Where(s => s.PartidoId == p.PartidoId).OrderBy(s => s.NumeroSet).ToListAsync();
            for (int j = p.Scores.Count(); j < nroSets; j++)
            {
                Score s = new Score();
                s.ScoreId = 0;
                s.PartidoId = p.PartidoId;
                s.NumeroSet = p.PartidoNumero;
                s.Score1 = 0;
                s.Score2 = 0;
                p.Scores.Add(s);
            }
            return 1;
        }

        public async Task<ActionResult> VerZonas(int? id)
        {
            List<Torneo2> Torneos = await _context.Torneos2.Include(z => z.Zones).ToListAsync();
            foreach (Torneo2 t in Torneos)
            {
                foreach (Zone z in t.Zones)
                {
                    z.ZonaJugadores = await _context.ZonasJugadores.Where(j => j.ZonaID == z.ZonaID).ToListAsync();
                    foreach (ZonaJugador zj in z.ZonaJugadores)
                    {
                        zj.Perfil = await _context.Perfiles.Where(p => p.ID == zj.PerfilID).FirstOrDefaultAsync();
                    }
                }
            }
            return View(Torneos);
        }
        private bool Torneo2Exists(int id)
        {
            return _context.Torneos2.Any(e => e.TorneoID == id);
        }
        private bool EstoyAnotado(int perfilid,int torneoid)
        {
            var result = _context.Anotaciones.Where(i => i.TorneoRefId == torneoid && i.PerfilRefId == perfilid).FirstOrDefault();
            return (result != null);
        }
        private async Task<bool> ZonasCerradas(int torneoID) 
        {
            List<Zone> Zones = await _context.Zones.Where(zx => zx.TorneoID == torneoID).ToListAsync();
            foreach(Zone z in Zones)
            {
                z.Partidos = await _context.Partidos.Where(p => p.ZonaId == z.ZonaID).ToListAsync();
            }
            foreach(Zone z in Zones)
            {
                if (z.Partidos.Count() < 5)
                {
                    return false;
                }
                if (!z.Partidos[4].Cerrado)
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<int> OrganizarCrucesAsync(int torneoID)

        {
            int clasificados = _context.Clasificados.Where(c => c.TorneoID == torneoID).Count();
            if (clasificados == 0)
            {
                return -1;
            }
            int i = 1;
            while (clasificados > Math.Pow(2, i))
            {
                i++;
            }
            if (clasificados == Math.Pow(2, i))
            {
                return 0;
            }
            double resto = clasificados % Math.Pow(2, i-1);
            List<Clasificado> cru = await _context.Clasificados.Where(c => c.TorneoID == torneoID)
                .OrderByDescending(c => c.Puesto).ThenBy(c => c.Promedio)
                .ToListAsync();
            var cruces = cru.Take((int)(resto * 2));

            List<Partido> Partidos = new List<Partido>();
            int k = cruces.Count();
            for (int j=0; j < k / 2; j++)
            {

                Partido cruce = new Partido();
                cruce.Jugador1Id = cruces.ElementAt(j).PerfilID;
                cruce.Jugador2Id = cruces.ElementAt(k - 1 - j).PerfilID;
                cruce.EtapaId = 9;
                cruce.Ronda = 2;
                cruce.Cerrado = false;
                cruce.Ganador = 0;
                cruce.PartidoNumero = 0;
                cruce.TorneoID = torneoID;
                Partidos.Add(cruce);

            }
            _context.Partidos.AddRange(Partidos);
            return await _context.SaveChangesAsync();
        }
        //public async Task<int> TestEliminatoria(int id)
        //{
        //    Torneo2 t = await _context.Torneos2.Where(t => t.TorneoID == id /100).FirstOrDefaultAsync();
        //    await OrganizarEliminatoriaAsync(t);
        //    return - 1;
        //}
        private async Task<int> OrganizarEliminatoriaAsync(Torneo2 Torneo)

        {
            List<Clasificado> Clasificados  = await _context.Clasificados
                .Where(c => c.TorneoID == Torneo.TorneoID)
                .OrderBy(c => c.Puesto)
                .OrderByDescending(c => c.Promedio).ToListAsync();

            switch (Clasificados.Count())
            {
                case 4:
                    await PartidosPrimeraRondaAsync(Clasificados, 7, Torneo);

                    break;
                case 8:
                    await PartidosPrimeraRondaAsync(Clasificados,6, Torneo);
                    break;
                case 16:
                    await PartidosPrimeraRondaAsync(Clasificados,5, Torneo);
                    break;
                case 32:
                    await PartidosPrimeraRondaAsync(Clasificados,4, Torneo);
                    break;
                case  64:
                    await PartidosPrimeraRondaAsync(Clasificados,3, Torneo);
                    break;
                default:
                    break;
            }
            return await _context.SaveChangesAsync();
        }
        private async Task<int> PartidosPrimeraRondaAsync(List<Clasificado> Clasificados, int etapaID, Torneo2 Torneo)

        {
            List<Partido> Partidos = new List<Partido>();
            int tID = Clasificados[0].TorneoID;
            int nro = Clasificados.Count();
            int ultimaRonda =  _context.Partidos.Where(p => p.TorneoID == Torneo.TorneoID).Max(p => p.Ronda);
            ultimaRonda=3;
            for (int i=1; i < nro / 2 + 1; i++)
            {
                Partido p = new Partido();
                p.Jugador1Id = Clasificados[i - 1].PerfilID;
                p.Jugador2Id = Clasificados[nro - i].PerfilID;
                p.TorneoID = tID;
                p.EtapaId = etapaID;
                p.Ronda = ultimaRonda;
                p.ZonaId = 0;
                p.PartidoNumero = i;
                p.Cerrado = false;
                p.Ganador = 0;
                Partidos.Add(p);

            }
            //partidos futuros
            ultimaRonda++;
            for (int i = nro / 2+1; i < nro / 2+ nro /4 +1 ; i++)
            {
                Partido p = new Partido();
                p.Jugador1Id = -1;
                p.Jugador2Id = -1;
                p.TorneoID = tID;
                p.EtapaId = etapaID;
                p.Ronda = ultimaRonda;
                p.ZonaId = 0;
                p.PartidoNumero = i;
                p.Cerrado = false;
                p.Ganador = 0;
                Partidos.Add(p);

            }
            ultimaRonda++;
            for (int i = nro / 2 + nro / 4+1; i < nro / 2 + nro / 4+ nro / 8 +1; i++)
            {
                Partido p = new Partido();
                p.Jugador1Id = -1;
                p.Jugador2Id = -1;
                p.TorneoID = tID;
                p.EtapaId = etapaID;
                p.Ronda = ultimaRonda;
                p.ZonaId = 0;
                p.PartidoNumero = i;
                p.Cerrado = false;
                p.Ganador = 0;
                Partidos.Add(p);

            }
            ultimaRonda++;
            for (int i = nro / 2 + nro / 4 + nro / 8+1; i < nro / 2 + nro / 4 + nro / 8+nro /16+1; i++)
            {
                Partido p = new Partido();
                p.Jugador1Id = -1;
                p.Jugador2Id = -1;
                p.TorneoID = tID;
                p.EtapaId = etapaID;
                p.Ronda = ultimaRonda;
                p.ZonaId = 0;
                p.PartidoNumero = i;
                p.Cerrado = false;
                p.Ganador = 0;
                Partidos.Add(p);

            }
            _context.Partidos.AddRange(Partidos);
            await _context.SaveChangesAsync();
            Partidos = await _context.Partidos.Where(p => p.TorneoID == Torneo.TorneoID && (!p.Cerrado)).ToListAsync();
            List<Score> Scores = new List<Score>();
            foreach(Partido p in Partidos)
            {
                for(int i = 0; i < Torneo.SisTor.CantSets; i++)
                {
                    Score sco = new Score();
                    sco.PartidoId = p.PartidoId;
                    sco.NumeroSet = i + 1;
                    sco.Score1 = 0;
                    sco.Score2 = 0;
                    Scores.Add(sco);
                }
            }
            _context.Scores.AddRange(Scores);
            return await _context.SaveChangesAsync();
        }
    }
}
