using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ELETRICTEL.Data;
using ELETRICTEL.Filters;
using ELETRICTEL.Models;

namespace ELETRICTEL.Controllers
{
    [PaginaParaUsuarioLogado]
    public class TypesController : Controller
    {
        private readonly ELETRICTELContext _context;

        public TypesController(ELETRICTELContext context)
        {
            _context = context;
        }

        // GET: Types
        public async Task<IActionResult> Index()
        {
              return View(await _context.Types.ToListAsync());
        }

        // GET: Types/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Types == null)
            {
                return NotFound();
            }

            var types = await _context.Types
                .FirstOrDefaultAsync(m => m.Id == id);
            if (types == null)
            {
                return NotFound();
            }

            return View(types);
        }

        // GET: Types/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Types/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Types types)
        {
            if (ModelState.IsValid)
            {
                TempData["MensagemSucesso"] = $"O tipos {types.Name} foi criado com sucesso.";
                _context.Types.Add(types);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            TempData["MensagemErro"] = "Aconteceu alguma coisa, fale com o administrador.";
            return View(types);
        }

        // GET: Types/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Types == null)
            {
                return NotFound();
            }

            var types = await _context.Types.FindAsync(id);
            if (types == null)
            {
                return NotFound();
            }
            return View(types);
        }

        // POST: Types/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Types types)
        {
            if (id != types.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["MensagemSucesso"] = $"O tipos {types.Name} foi editado com sucesso.";
                    _context.Types.Update(types);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypesExists(types.Id))
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
            TempData["MensagemErro"] = "Aconteceu alguma coisa, fale com o administrador.";
            return View(types);
        }

        // GET: Types/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Types == null)
            {
                return NotFound();
            }

            var types = await _context.Types
                .FirstOrDefaultAsync(m => m.Id == id);
            if (types == null)
            {
                return NotFound();
            }

            return View(types);
        }

        // POST: Types/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Types == null)
            {
                return Problem("Entity set 'ELETRICTELContext.Types'  is null.");
            }
            var types = await _context.Types.FindAsync(id);
            if (types != null)
            {
                _context.Types.Remove(types);
            }

            TempData["MensagemSucesso"] = "O engenheiro foi deletada com sucesso.";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypesExists(int id)
        {
          return _context.Types.Any(e => e.Id == id);
        }
    }
}
