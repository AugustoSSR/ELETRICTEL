using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ELETRICTEL.Data;
using ELETRICTEL.Models;

namespace ELETRICTEL.Controllers
{
    public class RCommercialsController : Controller
    {
        private readonly ELETRICTELContext _context;

        public RCommercialsController(ELETRICTELContext context)
        {
            _context = context;
        }

        // GET: RCommercials
        public async Task<IActionResult> Index()
        {
              return View(await _context.RCommercial.ToListAsync());
        }

        // GET: RCommercials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RCommercial == null)
            {
                return NotFound();
            }

            var rCommercial = await _context.RCommercial
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rCommercial == null)
            {
                return NotFound();
            }

            return View(rCommercial);
        }

        // GET: RCommercials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RCommercials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Role,Mail,Phone,CPF,RG,CreateTime,ChangeTime")] RCommercial rCommercial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rCommercial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rCommercial);
        }

        // GET: RCommercials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RCommercial == null)
            {
                return NotFound();
            }

            var rCommercial = await _context.RCommercial.FindAsync(id);
            if (rCommercial == null)
            {
                return NotFound();
            }
            return View(rCommercial);
        }

        // POST: RCommercials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Role,Mail,Phone,CPF,RG,CreateTime,ChangeTime")] RCommercial rCommercial)
        {
            if (id != rCommercial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rCommercial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RCommercialExists(rCommercial.Id))
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
            return View(rCommercial);
        }

        // GET: RCommercials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RCommercial == null)
            {
                return NotFound();
            }

            var rCommercial = await _context.RCommercial
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rCommercial == null)
            {
                return NotFound();
            }

            return View(rCommercial);
        }

        // POST: RCommercials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RCommercial == null)
            {
                return Problem("Entity set 'ELETRICTELContext.RCommercial'  is null.");
            }
            var rCommercial = await _context.RCommercial.FindAsync(id);
            if (rCommercial != null)
            {
                _context.RCommercial.Remove(rCommercial);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RCommercialExists(int id)
        {
          return _context.RCommercial.Any(e => e.Id == id);
        }
    }
}
