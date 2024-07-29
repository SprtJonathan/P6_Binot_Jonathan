using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P6_Binot_Jonathan.Data;

namespace P6_Binot_Jonathan.Controllers
{
    public class ProblemesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProblemesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Problemes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Problemes.Include(p => p.Produit).Include(p => p.Statut).Include(p => p.Systeme).Include(p => p.Version);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Problemes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problemes = await _context.Problemes
                .Include(p => p.Produit)
                .Include(p => p.Statut)
                .Include(p => p.Systeme)
                .Include(p => p.Version)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (problemes == null)
            {
                return NotFound();
            }

            return View(problemes);
        }

        // GET: Problemes/Create
        public IActionResult Create()
        {
            ViewData["IdProduit"] = new SelectList(_context.Produits, "Id", "Nom");
            ViewData["IdStatut"] = new SelectList(_context.Statuts, "Id", "Nom");
            ViewData["IdSysteme"] = new SelectList(_context.Systemes, "Id", "Nom");
            ViewData["IdVersion"] = new SelectList(_context.Versions, "Id", "Nom");
            return View();
        }

        // POST: Problemes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdProduit,IdVersion,IdSysteme,DateCreation,DateResolution,IdStatut,Problème,Resolution")] Problemes problemes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(problemes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProduit"] = new SelectList(_context.Produits, "Id", "Nom", problemes.IdProduit);
            ViewData["IdStatut"] = new SelectList(_context.Statuts, "Id", "Nom", problemes.IdStatut);
            ViewData["IdSysteme"] = new SelectList(_context.Systemes, "Id", "Nom", problemes.IdSysteme);
            ViewData["IdVersion"] = new SelectList(_context.Versions, "Id", "Nom", problemes.IdVersion);
            return View(problemes);
        }

        // GET: Problemes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problemes = await _context.Problemes.FindAsync(id);
            if (problemes == null)
            {
                return NotFound();
            }
            ViewData["IdProduit"] = new SelectList(_context.Produits, "Id", "Nom", problemes.IdProduit);
            ViewData["IdStatut"] = new SelectList(_context.Statuts, "Id", "Nom", problemes.IdStatut);
            ViewData["IdSysteme"] = new SelectList(_context.Systemes, "Id", "Nom", problemes.IdSysteme);
            ViewData["IdVersion"] = new SelectList(_context.Versions, "Id", "Nom", problemes.IdVersion);
            return View(problemes);
        }

        // POST: Problemes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdProduit,IdVersion,IdSysteme,DateCreation,DateResolution,IdStatut,Problème,Resolution")] Problemes problemes)
        {
            if (id != problemes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(problemes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProblemesExists(problemes.Id))
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
            ViewData["IdProduit"] = new SelectList(_context.Produits, "Id", "Nom", problemes.IdProduit);
            ViewData["IdStatut"] = new SelectList(_context.Statuts, "Id", "Nom", problemes.IdStatut);
            ViewData["IdSysteme"] = new SelectList(_context.Systemes, "Id", "Nom", problemes.IdSysteme);
            ViewData["IdVersion"] = new SelectList(_context.Versions, "Id", "Nom", problemes.IdVersion);
            return View(problemes);
        }

        // GET: Problemes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problemes = await _context.Problemes
                .Include(p => p.Produit)
                .Include(p => p.Statut)
                .Include(p => p.Systeme)
                .Include(p => p.Version)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (problemes == null)
            {
                return NotFound();
            }

            return View(problemes);
        }

        // POST: Problemes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var problemes = await _context.Problemes.FindAsync(id);
            if (problemes != null)
            {
                _context.Problemes.Remove(problemes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProblemesExists(int id)
        {
            return _context.Problemes.Any(e => e.Id == id);
        }
    }
}
