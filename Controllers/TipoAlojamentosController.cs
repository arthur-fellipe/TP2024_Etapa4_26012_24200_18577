using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP2024_Etapa4_26012_24200_18577.Models;

namespace TP2024_Etapa4_26012_24200_18577.Controllers
{
    public class TipoAlojamentosController : Controller
    {
        private readonly AlojamentoEstudantilContext _context;

        public TipoAlojamentosController(AlojamentoEstudantilContext context)
        {
            _context = context;
        }

        // GET: TipoAlojamentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoAlojamentos.ToListAsync());
        }

        // GET: TipoAlojamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAlojamento = await _context.TipoAlojamentos
                .FirstOrDefaultAsync(m => m.Taid == id);
            if (tipoAlojamento == null)
            {
                return NotFound();
            }

            return View(tipoAlojamento);
        }

        // GET: TipoAlojamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoAlojamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Taid,DescricaoTipoAlojamento")] TipoAlojamento tipoAlojamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoAlojamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoAlojamento);
        }

        // GET: TipoAlojamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAlojamento = await _context.TipoAlojamentos.FindAsync(id);
            if (tipoAlojamento == null)
            {
                return NotFound();
            }
            return View(tipoAlojamento);
        }

        // POST: TipoAlojamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Taid,DescricaoTipoAlojamento")] TipoAlojamento tipoAlojamento)
        {
            if (id != tipoAlojamento.Taid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoAlojamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoAlojamentoExists(tipoAlojamento.Taid))
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
            return View(tipoAlojamento);
        }

        // GET: TipoAlojamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAlojamento = await _context.TipoAlojamentos
                .FirstOrDefaultAsync(m => m.Taid == id);
            if (tipoAlojamento == null)
            {
                return NotFound();
            }

            return View(tipoAlojamento);
        }

        // POST: TipoAlojamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoAlojamento = await _context.TipoAlojamentos.FindAsync(id);
            if (tipoAlojamento != null)
            {
                _context.TipoAlojamentos.Remove(tipoAlojamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoAlojamentoExists(int id)
        {
            return _context.TipoAlojamentos.Any(e => e.Taid == id);
        }
    }
}
