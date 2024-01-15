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
    public class MeioPagamentosController : Controller
    {
        private readonly AlojamentoEstudantilContext _context;

        public MeioPagamentosController(AlojamentoEstudantilContext context)
        {
            _context = context;
        }

        // GET: MeioPagamentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.MeioPagamentos.ToListAsync());
        }

        // GET: MeioPagamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meioPagamento = await _context.MeioPagamentos
                .FirstOrDefaultAsync(m => m.Mpid == id);
            if (meioPagamento == null)
            {
                return NotFound();
            }

            return View(meioPagamento);
        }

        // GET: MeioPagamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MeioPagamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mpid,DescricaoMeioPagamento")] MeioPagamento meioPagamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meioPagamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meioPagamento);
        }

        // GET: MeioPagamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meioPagamento = await _context.MeioPagamentos.FindAsync(id);
            if (meioPagamento == null)
            {
                return NotFound();
            }
            return View(meioPagamento);
        }

        // POST: MeioPagamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Mpid,DescricaoMeioPagamento")] MeioPagamento meioPagamento)
        {
            if (id != meioPagamento.Mpid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meioPagamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeioPagamentoExists(meioPagamento.Mpid))
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
            return View(meioPagamento);
        }

        // GET: MeioPagamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meioPagamento = await _context.MeioPagamentos
                .FirstOrDefaultAsync(m => m.Mpid == id);
            if (meioPagamento == null)
            {
                return NotFound();
            }

            return View(meioPagamento);
        }

        // POST: MeioPagamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meioPagamento = await _context.MeioPagamentos.FindAsync(id);
            if (meioPagamento != null)
            {
                _context.MeioPagamentos.Remove(meioPagamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeioPagamentoExists(int id)
        {
            return _context.MeioPagamentos.Any(e => e.Mpid == id);
        }
    }
}
