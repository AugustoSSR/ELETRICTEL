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
    public class CompanyController : Controller
    {
        private readonly ELETRICTELContext _context;

        public CompanyController(ELETRICTELContext context)
        {
            _context = context;
        }

        // GET: Company
        public async Task<IActionResult> Index()
        {
              return View(await _context.Company.ToListAsync());
        }

        // GET: Company/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Company == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Company/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Razao,Fantasia,CNPJ,Street,StreetNumber,StreetCep,StreetState,StreetCity,CreateTime")] Company company)
        {
            if (ModelState.IsValid)
            {
                _context.Add(company);
                await _context.SaveChangesAsync();
                TempData["MensagemSucesso"] = $"A empresa {company.Razao} foi criada com sucesso.";
                return RedirectToAction(nameof(Index));
            }
            TempData["MensagemErro"] = "Aconteceu alguma coisa, fale com o administrador.";
            return View(company);
        }

        // GET: Company/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Company == null)
            {
                return NotFound();
            }

            var company = await _context.Company.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Company/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Razao,Fantasia,CNPJ,Street,StreetNumber,StreetCep,StreetState,StreetCity,CreateTime")] Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["MensagemSucesso"] = $"A empresa {company.Razao} foi editada com sucesso.";
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
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
            TempData["MensagemErro"] = "Aconteceu alguma coisa, tente novamente ou fale com o administrador.";
            return View(company);
        }

        // GET: Company/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Company == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Company == null)
            {
                return Problem("Entity set 'ELETRICTELContext.Company'  is null.");
            }
            var company = await _context.Company.FindAsync(id);
            if (company != null)
            {
                _context.Company.Remove(company);
            }
            
            await _context.SaveChangesAsync();
            TempData["MensagemSucesso"] = "A empresa foi deletada com sucesso.";
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
          return _context.Company.Any(e => e.Id == id);
        }
    }
}
