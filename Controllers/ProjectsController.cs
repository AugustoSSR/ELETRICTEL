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
    public class ProjectsController : Controller
    {
        private readonly ELETRICTELContext _context;

        public ProjectsController(ELETRICTELContext context)
        {
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            var eLETRICTELContext = _context.Projects.Include(p => p.Company).Include(p => p.RCommercial).Include(p => p.RResponsible).Include(p => p.Status).Include(p => p.Types);
            return View(await eLETRICTELContext.ToListAsync());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var projects = await _context.Projects
                .Include(p => p.Company)
                .Include(p => p.RCommercial)
                .Include(p => p.RResponsible)
                .Include(p => p.Status)
                .Include(p => p.Types)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projects == null)
            {
                return NotFound();
            }

            return View(projects);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Razao");
            ViewData["RCommercialId"] = new SelectList(_context.RCommercial, "Id", "Name");
            ViewData["RResponsibleId"] = new SelectList(_context.RResponsible, "Id", "Name");
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Name");
            ViewData["TypesId"] = new SelectList(_context.Types, "Id", "Name");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,TypesId,StatusId,CompanyId,Location,ProjectKM,ProjectPostes,ProjectART,ProjectStreetART,EnginnersId,RCommercialId,RResponsibleId,Protocol,ProtocolTime,ApprovedTime,CreateTime,ChangeTime")] Projects projects)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projects);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Razao", projects.CompanyId);
            ViewData["RCommercialId"] = new SelectList(_context.RCommercial, "Id", "Name", projects.RCommercialId);
            ViewData["RResponsibleId"] = new SelectList(_context.RResponsible, "Id", "Name", projects.RResponsibleId);
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Name", projects.StatusId);
            ViewData["TypesId"] = new SelectList(_context.Types, "Id", "Name", projects.TypesId);
            return View(projects);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var projects = await _context.Projects.FindAsync(id);
            if (projects == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Razao", projects.CompanyId);
            ViewData["RCommercialId"] = new SelectList(_context.RCommercial, "Id", "Name", projects.RCommercialId);
            ViewData["RResponsibleId"] = new SelectList(_context.RResponsible, "Id", "Name", projects.RResponsibleId);
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Name", projects.StatusId);
            ViewData["TypesId"] = new SelectList(_context.Types, "Id", "Name", projects.TypesId);
            return View(projects);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,TypesId,StatusId,CompanyId,Location,ProjectKM,ProjectPostes,ProjectART,ProjectStreetART,EnginnersId,RCommercialId,RResponsibleId,Protocol,ProtocolTime,ApprovedTime,CreateTime,ChangeTime")] Projects projects)
        {
            if (id != projects.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projects);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectsExists(projects.Id))
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
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Razao", projects.CompanyId);
            ViewData["RCommercialId"] = new SelectList(_context.RCommercial, "Id", "Name", projects.RCommercialId);
            ViewData["RResponsibleId"] = new SelectList(_context.RResponsible, "Id", "Name", projects.RResponsibleId);
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Name", projects.StatusId);
            ViewData["TypesId"] = new SelectList(_context.Types, "Id", "Name", projects.TypesId);
            return View(projects);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var projects = await _context.Projects
                .Include(p => p.Company)
                .Include(p => p.RCommercial)
                .Include(p => p.RResponsible)
                .Include(p => p.Status)
                .Include(p => p.Types)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projects == null)
            {
                return NotFound();
            }

            return View(projects);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Projects == null)
            {
                return Problem("Entity set 'ELETRICTELContext.Projects'  is null.");
            }
            var projects = await _context.Projects.FindAsync(id);
            if (projects != null)
            {
                _context.Projects.Remove(projects);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectsExists(int id)
        {
          return _context.Projects.Any(e => e.Id == id);
        }
    }
}
