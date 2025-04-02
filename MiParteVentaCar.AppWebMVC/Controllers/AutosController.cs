using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiParteVentaCar.AppWebMVC.Models;

namespace MiParteVentaCar.AppWebMVC.Controllers
{
    public class AutosController : Controller
    {
        private readonly VentacarProyectContext _context;

        public AutosController(VentacarProyectContext context)
        {
            _context = context;
        }

        // GET: Autos
        public async Task<IActionResult> Index()
        {
            var ventacarProyectContext = _context.Autos.Include(a => a.IdDepartamentoNavigation).Include(a => a.IdMarcaNavigation).Include(a => a.IdVendedorNavigation);
            return View(await ventacarProyectContext.ToListAsync());
        }

        // GET: Autos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auto = await _context.Autos
                .Include(a => a.IdDepartamentoNavigation)
                .Include(a => a.IdMarcaNavigation)
                .Include(a => a.IdVendedorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auto == null)
            {
                return NotFound();
            }

            return View(auto);
        }

        // GET: Autos/Create
        public IActionResult Create()
        {
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "Id", "Id");
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "Id", "Id");
            ViewData["IdVendedor"] = new SelectList(_context.Vendedores, "Id", "Id");
            return View();
        }

        // POST: Autos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdVendedor,IdDepartamento,IdMarca,AnnoFabricacion,Modelo,DescripcionA,Kilometraje,Estado,Precio,Urlimagen,Urt,FechaRp,Actividad,Comentario")] Auto auto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "Id", "Id", auto.IdDepartamento);
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "Id", "Id", auto.IdMarca);
            ViewData["IdVendedor"] = new SelectList(_context.Vendedores, "Id", "Id", auto.IdVendedor);
            return View(auto);
        }

        // GET: Autos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auto = await _context.Autos.FindAsync(id);
            if (auto == null)
            {
                return NotFound();
            }
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "Id", "Id", auto.IdDepartamento);
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "Id", "Id", auto.IdMarca);
            ViewData["IdVendedor"] = new SelectList(_context.Vendedores, "Id", "Id", auto.IdVendedor);
            return View(auto);
        }

        // POST: Autos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdVendedor,IdDepartamento,IdMarca,AnnoFabricacion,Modelo,DescripcionA,Kilometraje,Estado,Precio,Urlimagen,Urt,FechaRp,Actividad,Comentario")] Auto auto)
        {
            if (id != auto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoExists(auto.Id))
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
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "Id", "Id", auto.IdDepartamento);
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "Id", "Id", auto.IdMarca);
            ViewData["IdVendedor"] = new SelectList(_context.Vendedores, "Id", "Id", auto.IdVendedor);
            return View(auto);
        }

        // GET: Autos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auto = await _context.Autos
                .Include(a => a.IdDepartamentoNavigation)
                .Include(a => a.IdMarcaNavigation)
                .Include(a => a.IdVendedorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auto == null)
            {
                return NotFound();
            }

            return View(auto);
        }

        // POST: Autos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var auto = await _context.Autos.FindAsync(id);
            if (auto != null)
            {
                _context.Autos.Remove(auto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoExists(int id)
        {
            return _context.Autos.Any(e => e.Id == id);
        }
    }
}
