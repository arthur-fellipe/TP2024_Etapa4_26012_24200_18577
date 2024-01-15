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
    public class ForumularioIniciaisController : Controller
    {
        private readonly AlojamentoEstudantilContext _context;

        public ForumularioIniciaisController(AlojamentoEstudantilContext context)
        {
            _context = context;
        }

        // GET: ForumularioIniciais
        public async Task<IActionResult> Index()
        {
            var alojamentoEstudantilContext = _context.ForumularioInicials.Include(f => f.UtilizadorU);
            return View(await alojamentoEstudantilContext.ToListAsync());
        }

        // GET: ForumularioIniciais/Details/5
        public async Task<IActionResult> Details(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forumularioInicial = await _context.ForumularioInicials
                .Include(f => f.UtilizadorU)
                .FirstOrDefaultAsync(m => m.Hora == id);
            if (forumularioInicial == null)
            {
                return NotFound();
            }

            return View(forumularioInicial);
        }

        // GET: ForumularioIniciais/Create
        public IActionResult Create()
        {
            ViewData["UtilizadorUid"] = new SelectList(_context.Utilizadors, "Uid", "Uid");
            return View();
        }

        // POST: ForumularioIniciais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Hora,UtilizadorUid,DataInicio,DataFim,Localidade,RendaMax")] ForumularioInicial forumularioInicial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(forumularioInicial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UtilizadorUid"] = new SelectList(_context.Utilizadors, "Uid", "Uid", forumularioInicial.UtilizadorUid);
            return View(forumularioInicial);
        }

        // GET: ForumularioIniciais/Edit/5
        public async Task<IActionResult> Edit(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forumularioInicial = await _context.ForumularioInicials.FindAsync(id);
            if (forumularioInicial == null)
            {
                return NotFound();
            }
            ViewData["UtilizadorUid"] = new SelectList(_context.Utilizadors, "Uid", "Uid", forumularioInicial.UtilizadorUid);
            return View(forumularioInicial);
        }

        // POST: ForumularioIniciais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DateTime id, [Bind("Hora,UtilizadorUid,DataInicio,DataFim,Localidade,RendaMax")] ForumularioInicial forumularioInicial)
        {
            if (id != forumularioInicial.Hora)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forumularioInicial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForumularioInicialExists(forumularioInicial.Hora))
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
            ViewData["UtilizadorUid"] = new SelectList(_context.Utilizadors, "Uid", "Uid", forumularioInicial.UtilizadorUid);
            return View(forumularioInicial);
        }

        // GET: ForumularioIniciais/Delete/5
        public async Task<IActionResult> Delete(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forumularioInicial = await _context.ForumularioInicials
                .Include(f => f.UtilizadorU)
                .FirstOrDefaultAsync(m => m.Hora == id);
            if (forumularioInicial == null)
            {
                return NotFound();
            }

            return View(forumularioInicial);
        }

        // POST: ForumularioIniciais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(DateTime id)
        {
            var forumularioInicial = await _context.ForumularioInicials.FindAsync(id);
            if (forumularioInicial != null)
            {
                _context.ForumularioInicials.Remove(forumularioInicial);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForumularioInicialExists(DateTime id)
        {
            return _context.ForumularioInicials.Any(e => e.Hora == id);
        }
    }
}
