using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tareaitla2.Models;

namespace tareaitla2.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly EstudianteContext _context;

        public EstudiantesController(EstudianteContext context)
        {
            _context = context;
        }

        // GET: Estudiantes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DatosEstudiante.ToListAsync());
        }

        // GET: Estudiantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosEstudiante = await _context.DatosEstudiante
                .FirstOrDefaultAsync(m => m.IdEstudiante == id);
            if (datosEstudiante == null)
            {
                return NotFound();
            }

            return View(datosEstudiante);
        }

        // GET: Estudiantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estudiantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstudiante,Nombre,Apellido,Activo,Carrera")] DatosEstudiante datosEstudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(datosEstudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(datosEstudiante);
        }

        // GET: Estudiantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosEstudiante = await _context.DatosEstudiante.FindAsync(id);
            if (datosEstudiante == null)
            {
                return NotFound();
            }
            return View(datosEstudiante);
        }

        // POST: Estudiantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstudiante,Nombre,Apellido,Activo,Carrera")] DatosEstudiante datosEstudiante)
        {
            if (id != datosEstudiante.IdEstudiante)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datosEstudiante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatosEstudianteExists(datosEstudiante.IdEstudiante))
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
            return View(datosEstudiante);
        }

        // GET: Estudiantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosEstudiante = await _context.DatosEstudiante
                .FirstOrDefaultAsync(m => m.IdEstudiante == id);
            if (datosEstudiante == null)
            {
                return NotFound();
            }

            return View(datosEstudiante);
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var datosEstudiante = await _context.DatosEstudiante.FindAsync(id);
            _context.DatosEstudiante.Remove(datosEstudiante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatosEstudianteExists(int id)
        {
            return _context.DatosEstudiante.Any(e => e.IdEstudiante == id);
        }
    }
}
