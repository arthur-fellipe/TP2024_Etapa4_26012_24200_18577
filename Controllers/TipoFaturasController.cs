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
    public class TipoFaturasController : Controller
    {
        private readonly AlojamentoEstudantilContext _context;

        public TipoFaturasController(AlojamentoEstudantilContext context)
        {
            _context = context;
        }

        // GET: TipoFaturas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoFaturas.ToListAsync());
        }

        // GET: TipoFaturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoFatura = await _context.TipoFaturas
                .FirstOrDefaultAsync(m => m.Tfid == id);
            if (tipoFatura == null)
            {
                return NotFound();
            }

            return View(tipoFatura);
        }

        // GET: TipoFaturas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoFaturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tfid,DescricaoTipoFatura")] TipoFatura tipoFatura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoFatura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoFatura);
        }

        // GET: TipoFaturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoFatura = await _context.TipoFaturas.FindAsync(id);
            if (tipoFatura == null)
            {
                return NotFound();
            }
            return View(tipoFatura);
        }

        // POST: TipoFaturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Tfid,DescricaoTipoFatura")] TipoFatura tipoFatura)
        {
            if (id != tipoFatura.Tfid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoFatura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoFaturaExists(tipoFatura.Tfid))
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
            return View(tipoFatura);
        }

        // GET: TipoFaturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoFatura = await _context.TipoFaturas
                .FirstOrDefaultAsync(m => m.Tfid == id);
            if (tipoFatura == null)
            {
                return NotFound();
            }

            return View(tipoFatura);
        }

        // POST: TipoFaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoFatura = await _context.TipoFaturas.FindAsync(id);
            if (tipoFatura != null)
            {
                _context.TipoFaturas.Remove(tipoFatura);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoFaturaExists(int id)
        {
            return _context.TipoFaturas.Any(e => e.Tfid == id);
        }
    }
}
