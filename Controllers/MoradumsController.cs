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
    public class MoradumsController : Controller
    {
        private readonly AlojamentoEstudantilContext _context;

        public MoradumsController(AlojamentoEstudantilContext context)
        {
            _context = context;
        }

        // GET: Moradums
        public async Task<IActionResult> Index()
        {
            var alojamentoEstudantilContext = _context.Morada.Include(m => m.CodigoPostalCp);
            return View(await alojamentoEstudantilContext.ToListAsync());
        }

        // GET: Moradums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moradum = await _context.Morada
                .Include(m => m.CodigoPostalCp)
                .FirstOrDefaultAsync(m => m.Mid == id);
            if (moradum == null)
            {
                return NotFound();
            }

            return View(moradum);
        }

        // GET: Moradums/Create
        public IActionResult Create()
        {
            ViewData["CodigoPostalCpid"] = new SelectList(_context.CodigoPostals, "Cpid", "Cpid");
            return View();
        }

        // POST: Moradums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mid,Rua,NumPorta,Complemento,CodigoPostalCpid")] Moradum moradum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moradum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoPostalCpid"] = new SelectList(_context.CodigoPostals, "Cpid", "Cpid", moradum.CodigoPostalCpid);
            return View(moradum);
        }

        // GET: Moradums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moradum = await _context.Morada.FindAsync(id);
            if (moradum == null)
            {
                return NotFound();
            }
            ViewData["CodigoPostalCpid"] = new SelectList(_context.CodigoPostals, "Cpid", "Cpid", moradum.CodigoPostalCpid);
            return View(moradum);
        }

        // POST: Moradums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Mid,Rua,NumPorta,Complemento,CodigoPostalCpid")] Moradum moradum)
        {
            if (id != moradum.Mid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moradum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoradumExists(moradum.Mid))
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
            ViewData["CodigoPostalCpid"] = new SelectList(_context.CodigoPostals, "Cpid", "Cpid", moradum.CodigoPostalCpid);
            return View(moradum);
        }

        // GET: Moradums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moradum = await _context.Morada
                .Include(m => m.CodigoPostalCp)
                .FirstOrDefaultAsync(m => m.Mid == id);
            if (moradum == null)
            {
                return NotFound();
            }

            return View(moradum);
        }

        // POST: Moradums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moradum = await _context.Morada.FindAsync(id);
            if (moradum != null)
            {
                _context.Morada.Remove(moradum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoradumExists(int id)
        {
            return _context.Morada.Any(e => e.Mid == id);
        }
    }
}
