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
    public class EngineersController : Controller
    {
        private readonly ELETRICTELContext _context;

        public EngineersController(ELETRICTELContext context)
        {
            _context = context;
        }

        // GET: Engineers
        public async Task<IActionResult> Index()
        {
              return View(await _context.Engineers.ToListAsync());
        }

        // GET: Engineers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Engineers == null)
            {
                return NotFound();
            }

            var engineers = await _context.Engineers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (engineers == null)
            {
                return NotFound();
            }

            return View(engineers);
        }

        // GET: Engineers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Engineers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CREA,Mail,Phone,CPF,RG,CreateTime,ChangeTime")] Engineers engineers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(engineers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(engineers);
        }

        // GET: Engineers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Engineers == null)
            {
                return NotFound();
            }

            var engineers = await _context.Engineers.FindAsync(id);
            if (engineers == null)
            {
                return NotFound();
            }
            return View(engineers);
        }

        // POST: Engineers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CREA,Mail,Phone,CPF,RG,CreateTime,ChangeTime")] Engineers engineers)
        {
            if (id != engineers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(engineers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EngineersExists(engineers.Id))
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
            return View(engineers);
        }

        // GET: Engineers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Engineers == null)
            {
                return NotFound();
            }

            var engineers = await _context.Engineers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (engineers == null)
            {
                return NotFound();
            }

            return View(engineers);
        }

        // POST: Engineers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Engineers == null)
            {
                return Problem("Entity set 'ELETRICTELContext.Engineers'  is null.");
            }
            var engineers = await _context.Engineers.FindAsync(id);
            if (engineers != null)
            {
                _context.Engineers.Remove(engineers);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EngineersExists(int id)
        {
          return _context.Engineers.Any(e => e.Id == id);
        }
    }
}
