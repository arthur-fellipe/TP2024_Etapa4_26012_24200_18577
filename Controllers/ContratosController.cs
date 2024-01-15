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
    public class ContratosController : Controller
    {
        private readonly AlojamentoEstudantilContext _context;

        public ContratosController(AlojamentoEstudantilContext context)
        {
            _context = context;
        }

        // GET: Contratos
        public async Task<IActionResult> Index()
        {
            var alojamentoEstudantilContext = _context.Contratos.Include(c => c.AlojamentoA).Include(c => c.UtilizadorU);
            return View(await alojamentoEstudantilContext.ToListAsync());
        }

        // GET: Contratos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contratos
                .Include(c => c.AlojamentoA)
                .Include(c => c.UtilizadorU)
                .FirstOrDefaultAsync(m => m.Cid == id);
            if (contrato == null)
            {
                return NotFound();
            }

            return View(contrato);
        }

        // GET: Contratos/Create
        public IActionResult Create()
        {
            ViewData["AlojamentoAid"] = new SelectList(_context.Alojamentos, "Aid", "Aid");
            ViewData["UtilizadorUid"] = new SelectList(_context.Utilizadors, "Uid", "Uid");
            return View();
        }

        // POST: Contratos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cid,DataAssinatura,TaxaIntermediacaoEstudante,TaxaIntermediacaoProprietario,UtilizadorUid,AlojamentoAid")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contrato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlojamentoAid"] = new SelectList(_context.Alojamentos, "Aid", "Aid", contrato.AlojamentoAid);
            ViewData["UtilizadorUid"] = new SelectList(_context.Utilizadors, "Uid", "Uid", contrato.UtilizadorUid);
            return View(contrato);
        }

        // GET: Contratos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contratos.FindAsync(id);
            if (contrato == null)
            {
                return NotFound();
            }
            ViewData["AlojamentoAid"] = new SelectList(_context.Alojamentos, "Aid", "Aid", contrato.AlojamentoAid);
            ViewData["UtilizadorUid"] = new SelectList(_context.Utilizadors, "Uid", "Uid", contrato.UtilizadorUid);
            return View(contrato);
        }

        // POST: Contratos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cid,DataAssinatura,TaxaIntermediacaoEstudante,TaxaIntermediacaoProprietario,UtilizadorUid,AlojamentoAid")] Contrato contrato)
        {
            if (id != contrato.Cid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contrato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratoExists(contrato.Cid))
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
            ViewData["AlojamentoAid"] = new SelectList(_context.Alojamentos, "Aid", "Aid", contrato.AlojamentoAid);
            ViewData["UtilizadorUid"] = new SelectList(_context.Utilizadors, "Uid", "Uid", contrato.UtilizadorUid);
            return View(contrato);
        }

        // GET: Contratos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contratos
                .Include(c => c.AlojamentoA)
                .Include(c => c.UtilizadorU)
                .FirstOrDefaultAsync(m => m.Cid == id);
            if (contrato == null)
            {
                return NotFound();
            }

            return View(contrato);
        }

        // POST: Contratos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contrato = await _context.Contratos.FindAsync(id);
            if (contrato != null)
            {
                _context.Contratos.Remove(contrato);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratoExists(int id)
        {
            return _context.Contratos.Any(e => e.Cid == id);
        }
    }
}
