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
    public class ProjectDetailsController : Controller
    {
        private readonly ELETRICTELContext _context;

        public ProjectDetailsController(ELETRICTELContext context)
        {
            _context = context;
        }

        // GET: ProjectDetails
        public async Task<IActionResult> Index()
        {
            var eLETRICTELContext = _context.ProjectDetails.Include(p => p.Engineers).Include(p => p.Projects).Include(p => p.RCommercial).Include(p => p.RResponsible);
            return View(await eLETRICTELContext.ToListAsync());
        }

        // GET: ProjectDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProjectDetails == null)
            {
                return NotFound();
            }

            var projectDetails = await _context.ProjectDetails
                .Include(p => p.Engineers)
                .Include(p => p.Projects)
                .Include(p => p.RCommercial)
                .Include(p => p.RResponsible)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectDetails == null)
            {
                return NotFound();
            }

            return View(projectDetails);
        }

        // GET: ProjectDetails/Create
        public IActionResult Create()
        {
            ViewData["EngineersId"] = new SelectList(_context.Engineers, "Id", "Id");
            ViewData["ProjectsId"] = new SelectList(_context.Projects, "Id", "Location");
            ViewData["RCommercialId"] = new SelectList(_context.RCommercial, "Id", "Id");
            ViewData["RResponsibleId"] = new SelectList(_context.RResponsible, "Id", "Id");
            return View();
        }

        // POST: ProjectDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProjectsId,ProjectKM,ProjectPostes,ProjectART,ProjectStreetART,EngineersId,RCommercialId,RResponsibleId,Protocol,ProtocolTime,ApprovedTime,CreateDate")] ProjectDetails projectDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EngineersId"] = new SelectList(_context.Engineers, "Id", "Id", projectDetails.EngineersId);
            ViewData["ProjectsId"] = new SelectList(_context.Projects, "Id", "Location", projectDetails.ProjectsId);
            ViewData["RCommercialId"] = new SelectList(_context.RCommercial, "Id", "Id", projectDetails.RCommercialId);
            ViewData["RResponsibleId"] = new SelectList(_context.RResponsible, "Id", "Id", projectDetails.RResponsibleId);
            return View(projectDetails);
        }

        // GET: ProjectDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProjectDetails == null)
            {
                return NotFound();
            }

            var projectDetails = await _context.ProjectDetails.FindAsync(id);
            if (projectDetails == null)
            {
                return NotFound();
            }
            ViewData["EngineersId"] = new SelectList(_context.Engineers, "Id", "Id", projectDetails.EngineersId);
            ViewData["ProjectsId"] = new SelectList(_context.Projects, "Id", "Location", projectDetails.ProjectsId);
            ViewData["RCommercialId"] = new SelectList(_context.RCommercial, "Id", "Id", projectDetails.RCommercialId);
            ViewData["RResponsibleId"] = new SelectList(_context.RResponsible, "Id", "Id", projectDetails.RResponsibleId);
            return View(projectDetails);
        }

        // POST: ProjectDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectsId,ProjectKM,ProjectPostes,ProjectART,ProjectStreetART,EngineersId,RCommercialId,RResponsibleId,Protocol,ProtocolTime,ApprovedTime,CreateDate")] ProjectDetails projectDetails)
        {
            if (id != projectDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectDetailsExists(projectDetails.Id))
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
            ViewData["EngineersId"] = new SelectList(_context.Engineers, "Id", "Id", projectDetails.EngineersId);
            ViewData["ProjectsId"] = new SelectList(_context.Projects, "Id", "Location", projectDetails.ProjectsId);
            ViewData["RCommercialId"] = new SelectList(_context.RCommercial, "Id", "Id", projectDetails.RCommercialId);
            ViewData["RResponsibleId"] = new SelectList(_context.RResponsible, "Id", "Id", projectDetails.RResponsibleId);
            return View(projectDetails);
        }

        // GET: ProjectDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProjectDetails == null)
            {
                return NotFound();
            }

            var projectDetails = await _context.ProjectDetails
                .Include(p => p.Engineers)
                .Include(p => p.Projects)
                .Include(p => p.RCommercial)
                .Include(p => p.RResponsible)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectDetails == null)
            {
                return NotFound();
            }

            return View(projectDetails);
        }

        // POST: ProjectDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProjectDetails == null)
            {
                return Problem("Entity set 'ELETRICTELContext.ProjectDetails'  is null.");
            }
            var projectDetails = await _context.ProjectDetails.FindAsync(id);
            if (projectDetails != null)
            {
                _context.ProjectDetails.Remove(projectDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectDetailsExists(int id)
        {
          return _context.ProjectDetails.Any(e => e.Id == id);
        }
    }
}
