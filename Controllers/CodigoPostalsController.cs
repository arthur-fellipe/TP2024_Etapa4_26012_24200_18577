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
    public class CodigoPostalsController : Controller
    {
        private readonly AlojamentoEstudantilContext _context;

        public CodigoPostalsController(AlojamentoEstudantilContext context)
        {
            _context = context;
        }

        // GET: CodigoPostals
        public async Task<IActionResult> Index()
        {
            return View(await _context.CodigoPostals.ToListAsync());
        }

        // GET: CodigoPostals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codigoPostal = await _context.CodigoPostals
                .FirstOrDefaultAsync(m => m.Cpid == id);
            if (codigoPostal == null)
            {
                return NotFound();
            }

            return View(codigoPostal);
        }

        // GET: CodigoPostals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CodigoPostals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cpid,Cp,Localidade,Pais")] CodigoPostal codigoPostal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(codigoPostal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(codigoPostal);
        }

        // GET: CodigoPostals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codigoPostal = await _context.CodigoPostals.FindAsync(id);
            if (codigoPostal == null)
            {
                return NotFound();
            }
            return View(codigoPostal);
        }

        // POST: CodigoPostals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cpid,Cp,Localidade,Pais")] CodigoPostal codigoPostal)
        {
            if (id != codigoPostal.Cpid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(codigoPostal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CodigoPostalExists(codigoPostal.Cpid))
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
            return View(codigoPostal);
        }

        // GET: CodigoPostals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codigoPostal = await _context.CodigoPostals
                .FirstOrDefaultAsync(m => m.Cpid == id);
            if (codigoPostal == null)
            {
                return NotFound();
            }

            return View(codigoPostal);
        }

        // POST: CodigoPostals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var codigoPostal = await _context.CodigoPostals.FindAsync(id);
            if (codigoPostal != null)
            {
                _context.CodigoPostals.Remove(codigoPostal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CodigoPostalExists(int id)
        {
            return _context.CodigoPostals.Any(e => e.Cpid == id);
        }
    }
}
