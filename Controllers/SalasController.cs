using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WMVCADS2023.Models;

namespace WMVCADS2023.Controllers
{
    public class SalasController : Controller
    {
        private readonly Contexto _context;

        public SalasController(Contexto context)
        {
            _context = context;
        }

        // GET: Salas
        public async Task<IActionResult> Index()
        {

            return View(await _context.Salas.ToListAsync());
        }

        // GET: Salas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Salas == null)
            {
                return NotFound();
            }

            var sala = await _context.Salas
                .FirstOrDefaultAsync(m => m.id == id);
            if (sala == null)
            {
                return NotFound();
            }

            return View(sala);
        }

        // GET: Salas/Create
        public IActionResult Create()
        {
            var status = Enum.GetValues(typeof(Situacao))
                 .Cast<Situacao>()
                 .Select(e => new SelectListItem
                 {
                     Value = e.ToString(),
                     Text = e.ToString()
                 });
            ViewBag.status = status; 
            
            return View();
        }

        // POST: Salas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,descricao,monitor,equipamentos,situacao")] Sala sala)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sala);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var status = Enum.GetValues(typeof(Situacao))
                 .Cast<Situacao>()
                 .Select(e => new SelectListItem
                 {
                     Value = e.ToString(),
                     Text = e.ToString()
                 });
            ViewBag.status = status;
            return View(sala);
        }

        // GET: Salas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Salas == null)
            {
                return NotFound();
            }

            var sala = await _context.Salas.FindAsync(id);
            if (sala == null)
            {
                return NotFound();
            }
            var status = Enum.GetValues(typeof(Situacao))
                 .Cast<Situacao>()
                 .Select(e => new SelectListItem
                 {
                     Value = e.ToString(),
                     Text = e.ToString()
                 });
            ViewBag.status = status;
            return View(sala);
        }

        // POST: Salas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,descricao,monitor,equipamentos,situacao")] Sala sala)
        {
            if (id != sala.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sala);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaExists(sala.id))
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
            var status = Enum.GetValues(typeof(Situacao))
                 .Cast<Situacao>()
                 .Select(e => new SelectListItem
                 {
                     Value = e.ToString(),
                     Text = e.ToString()
                 });
            return View(sala);
        }

        // GET: Salas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Salas == null)
            {
                return NotFound();
            }

            var sala = await _context.Salas
                .FirstOrDefaultAsync(m => m.id == id);
            if (sala == null)
            {
                return NotFound();
            }

            return View(sala);
        }

        // POST: Salas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Salas == null)
            {
                return Problem("Entity set 'Contexto.Salas'  is null.");
            }
            var sala = await _context.Salas.FindAsync(id);
            if (sala != null)
            {
                _context.Salas.Remove(sala);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaExists(int id)
        {
          return _context.Salas.Any(e => e.id == id);
        }
    }
}
