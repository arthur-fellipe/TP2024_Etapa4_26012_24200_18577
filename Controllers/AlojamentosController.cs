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
    public class AlojamentosController : Controller
    {
        private readonly AlojamentoEstudantilContext _context;

        public AlojamentosController(AlojamentoEstudantilContext context)
        {
            _context = context;
        }

        // GET: Alojamentos
        public async Task<IActionResult> Index()
        {
            var alojamentoEstudantilContext = _context.Alojamentos.Include(a => a.CondicoesContratuaisCc).Include(a => a.MoradaM).Include(a => a.TipoAlojamentoTa).Include(a => a.TipoResidenciaTr).Include(a => a.UtilizadorU);
            return View(await alojamentoEstudantilContext.ToListAsync());
        }

        // GET: Alojamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alojamento = await _context.Alojamentos
                .Include(a => a.CondicoesContratuaisCc)
                .Include(a => a.MoradaM)
                .Include(a => a.TipoAlojamentoTa)
                .Include(a => a.TipoResidenciaTr)
                .Include(a => a.UtilizadorU)
                .FirstOrDefaultAsync(m => m.Aid == id);
            if (alojamento == null)
            {
                return NotFound();
            }

            return View(alojamento);
        }

        // GET: Alojamentos/Create
        public IActionResult Create()
        {
            ViewData["CondicoesContratuaisCcid"] = new SelectList(_context.CondicoesContratuais, "Ccid", "Ccid");
            ViewData["MoradaMid"] = new SelectList(_context.Morada, "Mid", "Mid");
            ViewData["TipoAlojamentoTaid"] = new SelectList(_context.TipoAlojamentos, "Taid", "Taid");
            ViewData["TipoResidenciaTrid"] = new SelectList(_context.TipoResidencia, "Trid", "Trid");
            ViewData["UtilizadorUid"] = new SelectList(_context.Utilizadors, "Uid", "Uid");
            return View();
        }

        // POST: Alojamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Aid,Descricao,LinkFotos,LinkVideos,MoradaMid,CondicoesContratuaisCcid,TipoAlojamentoTaid,TipoResidenciaTrid,UtilizadorUid")] Alojamento alojamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alojamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CondicoesContratuaisCcid"] = new SelectList(_context.CondicoesContratuais, "Ccid", "Ccid", alojamento.CondicoesContratuaisCcid);
            ViewData["MoradaMid"] = new SelectList(_context.Morada, "Mid", "Mid", alojamento.MoradaMid);
            ViewData["TipoAlojamentoTaid"] = new SelectList(_context.TipoAlojamentos, "Taid", "Taid", alojamento.TipoAlojamentoTaid);
            ViewData["TipoResidenciaTrid"] = new SelectList(_context.TipoResidencia, "Trid", "Trid", alojamento.TipoResidenciaTrid);
            ViewData["UtilizadorUid"] = new SelectList(_context.Utilizadors, "Uid", "Uid", alojamento.UtilizadorUid);
            return View(alojamento);
        }

        // GET: Alojamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alojamento = await _context.Alojamentos.FindAsync(id);
            if (alojamento == null)
            {
                return NotFound();
            }
            ViewData["CondicoesContratuaisCcid"] = new SelectList(_context.CondicoesContratuais, "Ccid", "Ccid", alojamento.CondicoesContratuaisCcid);
            ViewData["MoradaMid"] = new SelectList(_context.Morada, "Mid", "Mid", alojamento.MoradaMid);
            ViewData["TipoAlojamentoTaid"] = new SelectList(_context.TipoAlojamentos, "Taid", "Taid", alojamento.TipoAlojamentoTaid);
            ViewData["TipoResidenciaTrid"] = new SelectList(_context.TipoResidencia, "Trid", "Trid", alojamento.TipoResidenciaTrid);
            ViewData["UtilizadorUid"] = new SelectList(_context.Utilizadors, "Uid", "Uid", alojamento.UtilizadorUid);
            return View(alojamento);
        }

        // POST: Alojamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Aid,Descricao,LinkFotos,LinkVideos,MoradaMid,CondicoesContratuaisCcid,TipoAlojamentoTaid,TipoResidenciaTrid,UtilizadorUid")] Alojamento alojamento)
        {
            if (id != alojamento.Aid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alojamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlojamentoExists(alojamento.Aid))
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
            ViewData["CondicoesContratuaisCcid"] = new SelectList(_context.CondicoesContratuais, "Ccid", "Ccid", alojamento.CondicoesContratuaisCcid);
            ViewData["MoradaMid"] = new SelectList(_context.Morada, "Mid", "Mid", alojamento.MoradaMid);
            ViewData["TipoAlojamentoTaid"] = new SelectList(_context.TipoAlojamentos, "Taid", "Taid", alojamento.TipoAlojamentoTaid);
            ViewData["TipoResidenciaTrid"] = new SelectList(_context.TipoResidencia, "Trid", "Trid", alojamento.TipoResidenciaTrid);
            ViewData["UtilizadorUid"] = new SelectList(_context.Utilizadors, "Uid", "Uid", alojamento.UtilizadorUid);
            return View(alojamento);
        }

        // GET: Alojamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alojamento = await _context.Alojamentos
                .Include(a => a.CondicoesContratuaisCc)
                .Include(a => a.MoradaM)
                .Include(a => a.TipoAlojamentoTa)
                .Include(a => a.TipoResidenciaTr)
                .Include(a => a.UtilizadorU)
                .FirstOrDefaultAsync(m => m.Aid == id);
            if (alojamento == null)
            {
                return NotFound();
            }

            return View(alojamento);
        }

        // POST: Alojamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alojamento = await _context.Alojamentos.FindAsync(id);
            if (alojamento != null)
            {
                _context.Alojamentos.Remove(alojamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlojamentoExists(int id)
        {
            return _context.Alojamentos.Any(e => e.Aid == id);
        }
    }
}
