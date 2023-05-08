using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clases_Interfaces.Models;

namespace Clases_Interfaces.Controllers
{
    public class MatriculadoesController : Controller
    {
        private readonly DbSistemaCftContext _context;

        public MatriculadoesController(DbSistemaCftContext context)
        {
            _context = context;
        }

        // GET: Matriculadoes
        public async Task<IActionResult> Index()
        {
              return _context.Matriculados != null ? 
                          View(await _context.Matriculados.ToListAsync()) :
                          Problem("Entity set 'DbSistemaCftContext.Matriculados'  is null.");
        }

        // GET: Matriculadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Matriculados == null)
            {
                return NotFound();
            }

            var matriculado = await _context.Matriculados
                .FirstOrDefaultAsync(m => m.IdEstudiante == id);
            if (matriculado == null)
            {
                return NotFound();
            }

            return View(matriculado);
        }

        // GET: Matriculadoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Matriculadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstudiante,IdAsignatura,IdPrimaryKey")] Matriculado matriculado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matriculado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(matriculado);
        }

        // GET: Matriculadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Matriculados == null)
            {
                return NotFound();
            }

            var matriculado = await _context.Matriculados.FindAsync(id);
            if (matriculado == null)
            {
                return NotFound();
            }
            return View(matriculado);
        }

        // POST: Matriculadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstudiante,IdAsignatura,IdPrimaryKey")] Matriculado matriculado)
        {
            if (id != matriculado.IdEstudiante)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matriculado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatriculadoExists(matriculado.IdEstudiante))
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
            return View(matriculado);
        }

        // GET: Matriculadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Matriculados == null)
            {
                return NotFound();
            }

            var matriculado = await _context.Matriculados
                .FirstOrDefaultAsync(m => m.IdEstudiante == id);
            if (matriculado == null)
            {
                return NotFound();
            }

            return View(matriculado);
        }

        // POST: Matriculadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Matriculados == null)
            {
                return Problem("Entity set 'DbSistemaCftContext.Matriculados'  is null.");
            }
            var matriculado = await _context.Matriculados.FindAsync(id);
            if (matriculado != null)
            {
                _context.Matriculados.Remove(matriculado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatriculadoExists(int id)
        {
          return (_context.Matriculados?.Any(e => e.IdEstudiante == id)).GetValueOrDefault();
        }
    }
}
