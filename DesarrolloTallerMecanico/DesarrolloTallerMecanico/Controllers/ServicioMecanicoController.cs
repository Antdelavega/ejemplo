using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DesarrolloTallerMecanico.Models;
using DesarrolloTallerMecanico.Models.Data.DDL;

namespace DesarrolloTallerMecanico.Controllers
{
    public class ServicioMecanicoController : Controller
    {
        private readonly DesarrolloTallerMecanicoContext _context;

        public ServicioMecanicoController(DesarrolloTallerMecanicoContext context)
        {
            _context = context;
        }

        // GET: ServicioMecanico
        public async Task<IActionResult> Index()
        {
            var desarrolloTallerMecanicoContext = _context.ServicioMecanico.Include(s => s.TipoServicio).Include(s => s.Vehiculo);
            return View(await desarrolloTallerMecanicoContext.ToListAsync());
        }

        // GET: ServicioMecanico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicioMecanico = await _context.ServicioMecanico
                .Include(s => s.TipoServicio)
                .Include(s => s.Vehiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicioMecanico == null)
            {
                return NotFound();
            }

            return View(servicioMecanico);
        }

        // GET: ServicioMecanico/Create
        public IActionResult Create()
        {
            ViewData["TipoServicioId"] = new SelectList(_context.Set<TipoServicio>(), "Id", "Nombre");
            ViewData["VehiculoId"] = new SelectList(_context.Set<Vehiculo>(), "Id", "Id");
            return View();
        }

        // POST: ServicioMecanico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaIngresoVehiculo,FechaEntregaVehiculo,DescripcionServicio,VehiculoId,TipoServicioId")] ServicioMecanico servicioMecanico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicioMecanico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoServicioId"] = new SelectList(_context.Set<TipoServicio>(), "Id", "Nombre", servicioMecanico.TipoServicioId);
            ViewData["VehiculoId"] = new SelectList(_context.Set<Vehiculo>(), "Id", "Id", servicioMecanico.VehiculoId);
            return View(servicioMecanico);
        }

        // GET: ServicioMecanico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicioMecanico = await _context.ServicioMecanico.FindAsync(id);
            if (servicioMecanico == null)
            {
                return NotFound();
            }
            ViewData["TipoServicioId"] = new SelectList(_context.Set<TipoServicio>(), "Id", "Nombre", servicioMecanico.TipoServicioId);
            ViewData["VehiculoId"] = new SelectList(_context.Set<Vehiculo>(), "Id", "Id", servicioMecanico.VehiculoId);
            return View(servicioMecanico);
        }

        // POST: ServicioMecanico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaIngresoVehiculo,FechaEntregaVehiculo,DescripcionServicio,VehiculoId,TipoServicioId")] ServicioMecanico servicioMecanico)
        {
            if (id != servicioMecanico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicioMecanico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicioMecanicoExists(servicioMecanico.Id))
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
            ViewData["TipoServicioId"] = new SelectList(_context.Set<TipoServicio>(), "Id", "Nombre", servicioMecanico.TipoServicioId);
            ViewData["VehiculoId"] = new SelectList(_context.Set<Vehiculo>(), "Id", "Id", servicioMecanico.VehiculoId);
            return View(servicioMecanico);
        }

        // GET: ServicioMecanico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicioMecanico = await _context.ServicioMecanico
                .Include(s => s.TipoServicio)
                .Include(s => s.Vehiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicioMecanico == null)
            {
                return NotFound();
            }

            return View(servicioMecanico);
        }

        // POST: ServicioMecanico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicioMecanico = await _context.ServicioMecanico.FindAsync(id);
            _context.ServicioMecanico.Remove(servicioMecanico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicioMecanicoExists(int id)
        {
            return _context.ServicioMecanico.Any(e => e.Id == id);
        }
    }
}
