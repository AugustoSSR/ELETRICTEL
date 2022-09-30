using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ELETRICTEL.Data;
using ELETRICTEL.Models;
using ELETRICTEL.Filters;

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
                _context.Types.Add(types);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
                    types.ChangeTime = DateTime.Now;
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
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypesExists(int id)
        {
          return _context.Types.Any(e => e.Id == id);
        }
    }
}
