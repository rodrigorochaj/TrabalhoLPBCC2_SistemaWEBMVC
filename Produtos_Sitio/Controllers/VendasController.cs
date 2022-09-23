using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;
using Produtos_Sitio.Migrations;
using Produtos_Sitio.Models;

namespace Produtos_Sitio.Controllers
{
    public class VendasController : Controller
    {
        private readonly Contexto _context;

        public VendasController(Contexto context)
        {
            _context = context;
        }

        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Vendas.Include(v => v.cliente).Include(v => v.produto);
            return View(await contexto.ToListAsync());
        }

        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vendas == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas
                .Include(v => v.cliente)
                .Include(v => v.produto)
                .FirstOrDefaultAsync(m => m.id == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Vendas/Create
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

            ViewData["clienteid"] = new SelectList(_context.Clientes, "id", "nome");
            ViewData["produtoid"] = new SelectList(_context.Produtos, "id", "descricao");
            return View();
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,clienteid,produtoid,data,quantidade,Total,pago")] Venda venda)
        {
            Produto produto = _context.Produtos.First(model => model.id == venda.produtoid);
            if (ModelState.IsValid && (produto.quantidade - venda.quantidade) >= 0)
            {
                produto.quantidade -= venda.quantidade;
                _context.Add(venda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            } 
            else if((produto.quantidade - venda.quantidade) < 0)
            {
                ModelState.AddModelError("", "Não há estoque suficiente.");
                return View();
            }
            ViewData["clienteid"] = new SelectList(_context.Clientes, "id", "nome", venda.clienteid);
            ViewData["produtoid"] = new SelectList(_context.Produtos, "id", "descricao", venda.produtoid);
            return View(venda);
        }


        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vendas == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }
            ViewData["clienteid"] = new SelectList(_context.Clientes, "id", "endereco", venda.clienteid);
            ViewData["produtoid"] = new SelectList(_context.Produtos, "id", "descricao", venda.produtoid);
            return View(venda);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,clienteid,produtoid,data,quantidade,Total,pago")] Venda venda)
        {
            if (id != venda.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.id))
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
            ViewData["clienteid"] = new SelectList(_context.Clientes, "id", "endereco", venda.clienteid);
            ViewData["produtoid"] = new SelectList(_context.Produtos, "id", "descricao", venda.produtoid);
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vendas == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas
                .Include(v => v.cliente)
                .Include(v => v.produto)
                .FirstOrDefaultAsync(m => m.id == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vendas == null)
            {
                return Problem("Entity set 'Contexto.Vendas'  is null.");
            }
            var venda = await _context.Vendas.FindAsync(id);
            if (venda != null)
            {
                _context.Vendas.Remove(venda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
          return _context.Vendas.Any(e => e.id == id);
        }

    }
}
