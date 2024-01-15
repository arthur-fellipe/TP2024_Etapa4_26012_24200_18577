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
    public class FaturasController : Controller
    {
        private readonly AlojamentoEstudantilContext _context;

        public FaturasController(AlojamentoEstudantilContext context)
        {
            _context = context;
        }

        // GET: Faturas
        public async Task<IActionResult> Index()
        {
            var alojamentoEstudantilContext = _context.Faturas.Include(f => f.ContratoC).Include(f => f.TipoFaturaTf);
            return View(await alojamentoEstudantilContext.ToListAsync());
        }

        // GET: Faturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fatura = await _context.Faturas
                .Include(f => f.ContratoC)
                .Include(f => f.TipoFaturaTf)
                .FirstOrDefaultAsync(m => m.Fid == id);
            if (fatura == null)
            {
                return NotFound();
            }

            return View(fatura);
        }

        // GET: Faturas/Create
        public IActionResult Create()
        {
            ViewData["ContratoCid"] = new SelectList(_context.Contratos, "Cid", "Cid");
            ViewData["TipoFaturaTfid"] = new SelectList(_context.TipoFaturas, "Tfid", "Tfid");
            return View();
        }

        // POST: Faturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Fid,DataVencimento,ValorTotal,Descricao,DataFatura,TipoFaturaTfid,ContratoCid")] Fatura fatura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fatura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContratoCid"] = new SelectList(_context.Contratos, "Cid", "Cid", fatura.ContratoCid);
            ViewData["TipoFaturaTfid"] = new SelectList(_context.TipoFaturas, "Tfid", "Tfid", fatura.TipoFaturaTfid);
            return View(fatura);
        }

        // GET: Faturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fatura = await _context.Faturas.FindAsync(id);
            if (fatura == null)
            {
                return NotFound();
            }
            ViewData["ContratoCid"] = new SelectList(_context.Contratos, "Cid", "Cid", fatura.ContratoCid);
            ViewData["TipoFaturaTfid"] = new SelectList(_context.TipoFaturas, "Tfid", "Tfid", fatura.TipoFaturaTfid);
            return View(fatura);
        }

        // POST: Faturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Fid,DataVencimento,ValorTotal,Descricao,DataFatura,TipoFaturaTfid,ContratoCid")] Fatura fatura)
        {
            if (id != fatura.Fid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fatura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaturaExists(fatura.Fid))
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
            ViewData["ContratoCid"] = new SelectList(_context.Contratos, "Cid", "Cid", fatura.ContratoCid);
            ViewData["TipoFaturaTfid"] = new SelectList(_context.TipoFaturas, "Tfid", "Tfid", fatura.TipoFaturaTfid);
            return View(fatura);
        }

        // GET: Faturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fatura = await _context.Faturas
                .Include(f => f.ContratoC)
                .Include(f => f.TipoFaturaTf)
                .FirstOrDefaultAsync(m => m.Fid == id);
            if (fatura == null)
            {
                return NotFound();
            }

            return View(fatura);
        }

        // POST: Faturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fatura = await _context.Faturas.FindAsync(id);
            if (fatura != null)
            {
                _context.Faturas.Remove(fatura);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FaturaExists(int id)
        {
            return _context.Faturas.Any(e => e.Fid == id);
        }
    }
}
