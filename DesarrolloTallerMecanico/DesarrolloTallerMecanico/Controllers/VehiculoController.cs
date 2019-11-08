﻿using System;
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
    public class VehiculoController : Controller
    {
        private readonly DesarrolloTallerMecanicoContext _context;

        public VehiculoController(DesarrolloTallerMecanicoContext context)
        {
            _context = context;
        }

        // GET: Vehiculo
        public async Task<IActionResult> Index()
        {
            var desarrolloTallerMecanicoContext = _context.Vehiculo.Include(v => v.Cliente).Include(v => v.TipoVehiculo);
            return View(await desarrolloTallerMecanicoContext.ToListAsync());
        }

        // GET: Vehiculo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculo
                .Include(v => v.Cliente)
                .Include(v => v.TipoVehiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // GET: Vehiculo/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Apellidos");
            ViewData["TipoVehiculoId"] = new SelectList(_context.TipoVehiculo, "Id", "Id");
            return View();
        }

        // POST: Vehiculo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumeroPlaca,Descripcion,NumeroMotor,NumeroChasis,ClienteId,TipoVehiculoId")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Apellidos", vehiculo.ClienteId);
            ViewData["TipoVehiculoId"] = new SelectList(_context.TipoVehiculo, "Id", "Id", vehiculo.TipoVehiculoId);
            return View(vehiculo);
        }

        // GET: Vehiculo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculo.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Apellidos", vehiculo.ClienteId);
            ViewData["TipoVehiculoId"] = new SelectList(_context.TipoVehiculo, "Id", "Id", vehiculo.TipoVehiculoId);
            return View(vehiculo);
        }

        // POST: Vehiculo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeroPlaca,Descripcion,NumeroMotor,NumeroChasis,ClienteId,TipoVehiculoId")] Vehiculo vehiculo)
        {
            if (id != vehiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculoExists(vehiculo.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Apellidos", vehiculo.ClienteId);
            ViewData["TipoVehiculoId"] = new SelectList(_context.TipoVehiculo, "Id", "Id", vehiculo.TipoVehiculoId);
            return View(vehiculo);
        }

        // GET: Vehiculo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculo
                .Include(v => v.Cliente)
                .Include(v => v.TipoVehiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // POST: Vehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehiculo = await _context.Vehiculo.FindAsync(id);
            _context.Vehiculo.Remove(vehiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculoExists(int id)
        {
            return _context.Vehiculo.Any(e => e.Id == id);
        }
    }
}
