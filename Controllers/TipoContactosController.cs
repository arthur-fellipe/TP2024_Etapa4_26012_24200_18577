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
    public class TipoContactosController : Controller
    {
        private readonly AlojamentoEstudantilContext _context;

        public TipoContactosController(AlojamentoEstudantilContext context)
        {
            _context = context;
        }

        // GET: TipoContactos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoContactos.ToListAsync());
        }

        // GET: TipoContactos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoContacto = await _context.TipoContactos
                .FirstOrDefaultAsync(m => m.Tcid == id);
            if (tipoContacto == null)
            {
                return NotFound();
            }

            return View(tipoContacto);
        }

        // GET: TipoContactos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoContactos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tcid,DescricaoTipoContacto")] TipoContacto tipoContacto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoContacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoContacto);
        }

        // GET: TipoContactos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoContacto = await _context.TipoContactos.FindAsync(id);
            if (tipoContacto == null)
            {
                return NotFound();
            }
            return View(tipoContacto);
        }

        // POST: TipoContactos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Tcid,DescricaoTipoContacto")] TipoContacto tipoContacto)
        {
            if (id != tipoContacto.Tcid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoContacto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoContactoExists(tipoContacto.Tcid))
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
            return View(tipoContacto);
        }

        // GET: TipoContactos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoContacto = await _context.TipoContactos
                .FirstOrDefaultAsync(m => m.Tcid == id);
            if (tipoContacto == null)
            {
                return NotFound();
            }

            return View(tipoContacto);
        }

        // POST: TipoContactos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoContacto = await _context.TipoContactos.FindAsync(id);
            if (tipoContacto != null)
            {
                _context.TipoContactos.Remove(tipoContacto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoContactoExists(int id)
        {
            return _context.TipoContactos.Any(e => e.Tcid == id);
        }
    }
}
