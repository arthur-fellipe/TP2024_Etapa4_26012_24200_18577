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
    public class DocumentoUtilizadoresController : Controller
    {
        private readonly AlojamentoEstudantilContext _context;

        public DocumentoUtilizadoresController(AlojamentoEstudantilContext context)
        {
            _context = context;
        }

        // GET: DocumentoUtilizadores
        public async Task<IActionResult> Index()
        {
            var alojamentoEstudantilContext = _context.DocumentoUtilizadors.Include(d => d.TipoDocumentoTd).Include(d => d.UtilizadorU);
            return View(await alojamentoEstudantilContext.ToListAsync());
        }

        // GET: DocumentoUtilizadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentoUtilizador = await _context.DocumentoUtilizadors
                .Include(d => d.TipoDocumentoTd)
                .Include(d => d.UtilizadorU)
                .FirstOrDefaultAsync(m => m.Duid == id);
            if (documentoUtilizador == null)
            {
                return NotFound();
            }

            return View(documentoUtilizador);
        }

        // GET: DocumentoUtilizadores/Create
        public IActionResult Create()
        {
            ViewData["TipoDocumentoTdid"] = new SelectList(_context.TipoDocumentos, "Tdid", "Tdid");
            ViewData["UtilizadorUid"] = new SelectList(_context.Utilizadors, "Uid", "Uid");
            return View();
        }

        // POST: DocumentoUtilizadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Duid,NumDocumento,TipoDocumentoTdid,UtilizadorUid")] DocumentoUtilizador documentoUtilizador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documentoUtilizador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoDocumentoTdid"] = new SelectList(_context.TipoDocumentos, "Tdid", "Tdid", documentoUtilizador.TipoDocumentoTdid);
            ViewData["UtilizadorUid"] = new SelectList(_context.Utilizadors, "Uid", "Uid", documentoUtilizador.UtilizadorUid);
            return View(documentoUtilizador);
        }

        // GET: DocumentoUtilizadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentoUtilizador = await _context.DocumentoUtilizadors.FindAsync(id);
            if (documentoUtilizador == null)
            {
                return NotFound();
            }
            ViewData["TipoDocumentoTdid"] = new SelectList(_context.TipoDocumentos, "Tdid", "Tdid", documentoUtilizador.TipoDocumentoTdid);
            ViewData["UtilizadorUid"] = new SelectList(_context.Utilizadors, "Uid", "Uid", documentoUtilizador.UtilizadorUid);
            return View(documentoUtilizador);
        }

        // POST: DocumentoUtilizadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Duid,NumDocumento,TipoDocumentoTdid,UtilizadorUid")] DocumentoUtilizador documentoUtilizador)
        {
            if (id != documentoUtilizador.Duid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documentoUtilizador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentoUtilizadorExists(documentoUtilizador.Duid))
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
            ViewData["TipoDocumentoTdid"] = new SelectList(_context.TipoDocumentos, "Tdid", "Tdid", documentoUtilizador.TipoDocumentoTdid);
            ViewData["UtilizadorUid"] = new SelectList(_context.Utilizadors, "Uid", "Uid", documentoUtilizador.UtilizadorUid);
            return View(documentoUtilizador);
        }

        // GET: DocumentoUtilizadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentoUtilizador = await _context.DocumentoUtilizadors
                .Include(d => d.TipoDocumentoTd)
                .Include(d => d.UtilizadorU)
                .FirstOrDefaultAsync(m => m.Duid == id);
            if (documentoUtilizador == null)
            {
                return NotFound();
            }

            return View(documentoUtilizador);
        }

        // POST: DocumentoUtilizadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var documentoUtilizador = await _context.DocumentoUtilizadors.FindAsync(id);
            if (documentoUtilizador != null)
            {
                _context.DocumentoUtilizadors.Remove(documentoUtilizador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentoUtilizadorExists(int id)
        {
            return _context.DocumentoUtilizadors.Any(e => e.Duid == id);
        }
    }
}
