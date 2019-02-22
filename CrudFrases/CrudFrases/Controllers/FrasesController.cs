using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudFrases.Data;
using CrudFrases.Models;

namespace CrudFrases.Controllers
{
    public class FrasesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FrasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Frases
        public async Task<IActionResult> Index()
        {
            return View(await _context.Frases.ToListAsync());
        }

        // GET: Frases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frase = await _context.Frases
                .FirstOrDefaultAsync(m => m.Id == id);
            if (frase == null)
            {
                return NotFound();
            }

            return View(frase);
        }

        // GET: Frases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Frases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Valor")] Frase frase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(frase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(frase);
        }

        // GET: Frases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frase = await _context.Frases.FindAsync(id);
            if (frase == null)
            {
                return NotFound();
            }
            return View(frase);
        }

        // POST: Frases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Valor")] Frase frase)
        {
            if (id != frase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(frase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FraseExists(frase.Id))
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
            return View(frase);
        }

        // GET: Frases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frase = await _context.Frases
                .FirstOrDefaultAsync(m => m.Id == id);
            if (frase == null)
            {
                return NotFound();
            }

            return View(frase);
        }

        // POST: Frases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var frase = await _context.Frases.FindAsync(id);
            _context.Frases.Remove(frase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FraseExists(int id)
        {
            return _context.Frases.Any(e => e.Id == id);
        }
    }
}
