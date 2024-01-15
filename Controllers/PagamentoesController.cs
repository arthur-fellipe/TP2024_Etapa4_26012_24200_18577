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
    public class PagamentoesController : Controller
    {
        private readonly AlojamentoEstudantilContext _context;

        public PagamentoesController(AlojamentoEstudantilContext context)
        {
            _context = context;
        }

        // GET: Pagamentoes
        public async Task<IActionResult> Index()
        {
            var alojamentoEstudantilContext = _context.Pagamentos.Include(p => p.MeioPagamentoMp);
            return View(await alojamentoEstudantilContext.ToListAsync());
        }

        // GET: Pagamentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamentos
                .Include(p => p.MeioPagamentoMp)
                .FirstOrDefaultAsync(m => m.Pid == id);
            if (pagamento == null)
            {
                return NotFound();
            }

            return View(pagamento);
        }

        // GET: Pagamentoes/Create
        public IActionResult Create()
        {
            ViewData["MeioPagamentoMpid"] = new SelectList(_context.MeioPagamentos, "Mpid", "Mpid");
            return View();
        }

        // POST: Pagamentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pid,DataPagamento,MeioPagamentoMpid")] Pagamento pagamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MeioPagamentoMpid"] = new SelectList(_context.MeioPagamentos, "Mpid", "Mpid", pagamento.MeioPagamentoMpid);
            return View(pagamento);
        }

        // GET: Pagamentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamentos.FindAsync(id);
            if (pagamento == null)
            {
                return NotFound();
            }
            ViewData["MeioPagamentoMpid"] = new SelectList(_context.MeioPagamentos, "Mpid", "Mpid", pagamento.MeioPagamentoMpid);
            return View(pagamento);
        }

        // POST: Pagamentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Pid,DataPagamento,MeioPagamentoMpid")] Pagamento pagamento)
        {
            if (id != pagamento.Pid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagamentoExists(pagamento.Pid))
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
            ViewData["MeioPagamentoMpid"] = new SelectList(_context.MeioPagamentos, "Mpid", "Mpid", pagamento.MeioPagamentoMpid);
            return View(pagamento);
        }

        // GET: Pagamentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamentos
                .Include(p => p.MeioPagamentoMp)
                .FirstOrDefaultAsync(m => m.Pid == id);
            if (pagamento == null)
            {
                return NotFound();
            }

            return View(pagamento);
        }

        // POST: Pagamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pagamento = await _context.Pagamentos.FindAsync(id);
            if (pagamento != null)
            {
                _context.Pagamentos.Remove(pagamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagamentoExists(int id)
        {
            return _context.Pagamentos.Any(e => e.Pid == id);
        }
    }
}
