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
    public class TipoUtilizadoresController : Controller
    {
        private readonly AlojamentoEstudantilContext _context;

        public TipoUtilizadoresController(AlojamentoEstudantilContext context)
        {
            _context = context;
        }

        // GET: TipoUtilizadores
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoUtilizadors.ToListAsync());
        }

        // GET: TipoUtilizadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoUtilizador = await _context.TipoUtilizadors
                .FirstOrDefaultAsync(m => m.Tuid == id);
            if (tipoUtilizador == null)
            {
                return NotFound();
            }

            return View(tipoUtilizador);
        }

        // GET: TipoUtilizadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoUtilizadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tuid,DescricaoTipoUtilizador")] TipoUtilizador tipoUtilizador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoUtilizador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoUtilizador);
        }

        // GET: TipoUtilizadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoUtilizador = await _context.TipoUtilizadors.FindAsync(id);
            if (tipoUtilizador == null)
            {
                return NotFound();
            }
            return View(tipoUtilizador);
        }

        // POST: TipoUtilizadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Tuid,DescricaoTipoUtilizador")] TipoUtilizador tipoUtilizador)
        {
            if (id != tipoUtilizador.Tuid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoUtilizador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoUtilizadorExists(tipoUtilizador.Tuid))
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
            return View(tipoUtilizador);
        }

        // GET: TipoUtilizadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoUtilizador = await _context.TipoUtilizadors
                .FirstOrDefaultAsync(m => m.Tuid == id);
            if (tipoUtilizador == null)
            {
                return NotFound();
            }

            return View(tipoUtilizador);
        }

        // POST: TipoUtilizadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoUtilizador = await _context.TipoUtilizadors.FindAsync(id);
            if (tipoUtilizador != null)
            {
                _context.TipoUtilizadors.Remove(tipoUtilizador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoUtilizadorExists(int id)
        {
            return _context.TipoUtilizadors.Any(e => e.Tuid == id);
        }
    }
}
