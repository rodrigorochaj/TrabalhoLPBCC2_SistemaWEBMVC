using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Produtos_Sitio.Models;

namespace Produtos_Sitio.Controllers
{
    public class EntregasController : Controller
    {
        private readonly Contexto _context;

        public EntregasController(Contexto context)
        {
            _context = context;
        }

        // GET: Entregas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Entregas.ToListAsync());
        }

        // GET: Entregas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Entregas == null)
            {
                return NotFound();
            }

            var entrega = await _context.Entregas
                .FirstOrDefaultAsync(m => m.id == id);
            if (entrega == null)
            {
                return NotFound();
            }

            return View(entrega);
        }

        // GET: Entregas/Create
        public IActionResult Create()
        {
            var conclusao = Enum.GetValues(typeof(Conclusao))
                .Cast<Conclusao>()
                .Select(e => new SelectListItem
                {
                    Value = e.ToString(),
                    Text = e.ToString()
                });

            ViewBag.bagConclusao = conclusao;
            return View();
        }

        // POST: Entregas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,data_entrega,entregue")] Entrega entrega)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entrega);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entrega);
        }

        // GET: Entregas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Entregas == null)
            {
                return NotFound();
            }

            var entrega = await _context.Entregas.FindAsync(id);
            if (entrega == null)
            {
                return NotFound();
            }
            return View(entrega);
        }

        // POST: Entregas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,data_entrega,entregue")] Entrega entrega)
        {
            if (id != entrega.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entrega);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntregaExists(entrega.id))
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
            return View(entrega);
        }

        // GET: Entregas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Entregas == null)
            {
                return NotFound();
            }

            var entrega = await _context.Entregas
                .FirstOrDefaultAsync(m => m.id == id);
            if (entrega == null)
            {
                return NotFound();
            }

            return View(entrega);
        }

        // POST: Entregas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Entregas == null)
            {
                return Problem("Entity set 'Contexto.Entregas'  is null.");
            }
            var entrega = await _context.Entregas.FindAsync(id);
            if (entrega != null)
            {
                _context.Entregas.Remove(entrega);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntregaExists(int id)
        {
          return _context.Entregas.Any(e => e.id == id);
        }
    }
}
