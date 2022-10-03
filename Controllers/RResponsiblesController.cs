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
    public class RResponsiblesController : Controller
    {
        private readonly ELETRICTELContext _context;

        public RResponsiblesController(ELETRICTELContext context)
        {
            _context = context;
        }

        // GET: RResponsibles
        public async Task<IActionResult> Index()
        {
              return View(await _context.RResponsible.ToListAsync());
        }

        // GET: RResponsibles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RResponsible == null)
            {
                return NotFound();
            }

            var rResponsible = await _context.RResponsible
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rResponsible == null)
            {
                return NotFound();
            }

            return View(rResponsible);
        }

        // GET: RResponsibles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RResponsibles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Role,Mail,Phone,CPF,RG,CreateTime")] RResponsible rResponsible)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rResponsible);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rResponsible);
        }

        // GET: RResponsibles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RResponsible == null)
            {
                return NotFound();
            }

            var rResponsible = await _context.RResponsible.FindAsync(id);
            if (rResponsible == null)
            {
                return NotFound();
            }
            return View(rResponsible);
        }

        // POST: RResponsibles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Role,Mail,Phone,CPF,RG,CreateTime")] RResponsible rResponsible)
        {
            if (id != rResponsible.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rResponsible);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RResponsibleExists(rResponsible.Id))
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
            return View(rResponsible);
        }

        // GET: RResponsibles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RResponsible == null)
            {
                return NotFound();
            }

            var rResponsible = await _context.RResponsible
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rResponsible == null)
            {
                return NotFound();
            }

            return View(rResponsible);
        }

        // POST: RResponsibles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RResponsible == null)
            {
                return Problem("Entity set 'ELETRICTELContext.RResponsible'  is null.");
            }
            var rResponsible = await _context.RResponsible.FindAsync(id);
            if (rResponsible != null)
            {
                _context.RResponsible.Remove(rResponsible);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RResponsibleExists(int id)
        {
          return _context.RResponsible.Any(e => e.Id == id);
        }
    }
}
