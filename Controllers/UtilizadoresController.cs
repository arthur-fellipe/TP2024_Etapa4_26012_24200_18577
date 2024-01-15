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
    public class UtilizadoresController : Controller
    {
        private readonly AlojamentoEstudantilContext _context;

        public UtilizadoresController(AlojamentoEstudantilContext context)
        {
            _context = context;
        }

        // GET: Utilizadores
        public async Task<IActionResult> Index()
        {
            var alojamentoEstudantilContext = _context.Utilizadors.Include(u => u.MoradaM).Include(u => u.TipoUtilizadorTu);
            return View(await alojamentoEstudantilContext.ToListAsync());
        }

        // GET: Utilizadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizadors
                .Include(u => u.MoradaM)
                .Include(u => u.TipoUtilizadorTu)
                .FirstOrDefaultAsync(m => m.Uid == id);
            if (utilizador == null)
            {
                return NotFound();
            }

            return View(utilizador);
        }

        // GET: Utilizadores/Create
        public IActionResult Create()
        {
            ViewData["MoradaMid"] = new SelectList(_context.Morada, "Mid", "Mid");
            ViewData["TipoUtilizadorTuid"] = new SelectList(_context.TipoUtilizadors, "Tuid", "Tuid");
            return View();
        }

        // POST: Utilizadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Uid,Nome,Iban,LinkIrs,DataNascimento,MoradaMid,TipoUtilizadorTuid")] Utilizador utilizador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utilizador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MoradaMid"] = new SelectList(_context.Morada, "Mid", "Mid", utilizador.MoradaMid);
            ViewData["TipoUtilizadorTuid"] = new SelectList(_context.TipoUtilizadors, "Tuid", "Tuid", utilizador.TipoUtilizadorTuid);
            return View(utilizador);
        }

        // GET: Utilizadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizadors.FindAsync(id);
            if (utilizador == null)
            {
                return NotFound();
            }
            ViewData["MoradaMid"] = new SelectList(_context.Morada, "Mid", "Mid", utilizador.MoradaMid);
            ViewData["TipoUtilizadorTuid"] = new SelectList(_context.TipoUtilizadors, "Tuid", "Tuid", utilizador.TipoUtilizadorTuid);
            return View(utilizador);
        }

        // POST: Utilizadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Uid,Nome,Iban,LinkIrs,DataNascimento,MoradaMid,TipoUtilizadorTuid")] Utilizador utilizador)
        {
            if (id != utilizador.Uid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilizador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilizadorExists(utilizador.Uid))
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
            ViewData["MoradaMid"] = new SelectList(_context.Morada, "Mid", "Mid", utilizador.MoradaMid);
            ViewData["TipoUtilizadorTuid"] = new SelectList(_context.TipoUtilizadors, "Tuid", "Tuid", utilizador.TipoUtilizadorTuid);
            return View(utilizador);
        }

        // GET: Utilizadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizadors
                .Include(u => u.MoradaM)
                .Include(u => u.TipoUtilizadorTu)
                .FirstOrDefaultAsync(m => m.Uid == id);
            if (utilizador == null)
            {
                return NotFound();
            }

            return View(utilizador);
        }

        // POST: Utilizadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var utilizador = await _context.Utilizadors.FindAsync(id);
            if (utilizador != null)
            {
                _context.Utilizadors.Remove(utilizador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilizadorExists(int id)
        {
            return _context.Utilizadors.Any(e => e.Uid == id);
        }
    }
}
