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
    public class TipoResidenciumsController : Controller
    {
        private readonly AlojamentoEstudantilContext _context;

        public TipoResidenciumsController(AlojamentoEstudantilContext context)
        {
            _context = context;
        }

        // GET: TipoResidenciums
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoResidencia.ToListAsync());
        }

        // GET: TipoResidenciums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoResidencium = await _context.TipoResidencia
                .FirstOrDefaultAsync(m => m.Trid == id);
            if (tipoResidencium == null)
            {
                return NotFound();
            }

            return View(tipoResidencium);
        }

        // GET: TipoResidenciums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoResidenciums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Trid,Tipologia,NumCasasBanho")] TipoResidencium tipoResidencium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoResidencium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoResidencium);
        }

        // GET: TipoResidenciums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoResidencium = await _context.TipoResidencia.FindAsync(id);
            if (tipoResidencium == null)
            {
                return NotFound();
            }
            return View(tipoResidencium);
        }

        // POST: TipoResidenciums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Trid,Tipologia,NumCasasBanho")] TipoResidencium tipoResidencium)
        {
            if (id != tipoResidencium.Trid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoResidencium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoResidenciumExists(tipoResidencium.Trid))
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
            return View(tipoResidencium);
        }

        // GET: TipoResidenciums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoResidencium = await _context.TipoResidencia
                .FirstOrDefaultAsync(m => m.Trid == id);
            if (tipoResidencium == null)
            {
                return NotFound();
            }

            return View(tipoResidencium);
        }

        // POST: TipoResidenciums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoResidencium = await _context.TipoResidencia.FindAsync(id);
            if (tipoResidencium != null)
            {
                _context.TipoResidencia.Remove(tipoResidencium);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoResidenciumExists(int id)
        {
            return _context.TipoResidencia.Any(e => e.Trid == id);
        }
    }
}
