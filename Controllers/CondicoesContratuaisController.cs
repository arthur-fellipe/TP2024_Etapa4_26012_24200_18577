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
    public class CondicoesContratuaisController : Controller
    {
        private readonly AlojamentoEstudantilContext _context;

        public CondicoesContratuaisController(AlojamentoEstudantilContext context)
        {
            _context = context;
        }

        // GET: CondicoesContratuais
        public async Task<IActionResult> Index()
        {
            return View(await _context.CondicoesContratuais.ToListAsync());
        }

        // GET: CondicoesContratuais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var condicoesContratuai = await _context.CondicoesContratuais
                .FirstOrDefaultAsync(m => m.Ccid == id);
            if (condicoesContratuai == null)
            {
                return NotFound();
            }

            return View(condicoesContratuai);
        }

        // GET: CondicoesContratuais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CondicoesContratuais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ccid,ValorRenda,DataInicio,DataFim,DespesasInclusas,VisitasPermitidas,ValorCaucao")] CondicoesContratuai condicoesContratuai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(condicoesContratuai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(condicoesContratuai);
        }

        // GET: CondicoesContratuais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var condicoesContratuai = await _context.CondicoesContratuais.FindAsync(id);
            if (condicoesContratuai == null)
            {
                return NotFound();
            }
            return View(condicoesContratuai);
        }

        // POST: CondicoesContratuais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ccid,ValorRenda,DataInicio,DataFim,DespesasInclusas,VisitasPermitidas,ValorCaucao")] CondicoesContratuai condicoesContratuai)
        {
            if (id != condicoesContratuai.Ccid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(condicoesContratuai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CondicoesContratuaiExists(condicoesContratuai.Ccid))
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
            return View(condicoesContratuai);
        }

        // GET: CondicoesContratuais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var condicoesContratuai = await _context.CondicoesContratuais
                .FirstOrDefaultAsync(m => m.Ccid == id);
            if (condicoesContratuai == null)
            {
                return NotFound();
            }

            return View(condicoesContratuai);
        }

        // POST: CondicoesContratuais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var condicoesContratuai = await _context.CondicoesContratuais.FindAsync(id);
            if (condicoesContratuai != null)
            {
                _context.CondicoesContratuais.Remove(condicoesContratuai);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CondicoesContratuaiExists(int id)
        {
            return _context.CondicoesContratuais.Any(e => e.Ccid == id);
        }
    }
}
