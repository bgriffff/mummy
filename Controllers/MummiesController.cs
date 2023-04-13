using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mummy.Models;
using mummy.Models.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace mummy.Controllers
{
    public class MummiesController : Controller
    {
        private readonly intex2Context _context;

        public MummiesController(intex2Context context)
        {
            _context = context;
        }

        // GET: Mummies
        public async Task<IActionResult> Index(int pageNum = 1)
        {
            int pageSize = 100;

            var x = new MummyViewModel
            {
                Mummy = _context.Mummies
                .OrderBy(application => application.Id)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumMummies = _context.Mummies.Count(),
                    MummiesPerPage = pageSize,
                    CurrentPage = pageNum
                }

            };

            return View(x);
        }

        // GET: Mummies/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Mummies == null)
            {
                return NotFound();
            }

            var mummy = await _context.Mummies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mummy == null)
            {
                return NotFound();
            }

            return View(mummy);
        }

        [Authorize(Roles = "Admin, Researcher")]
        // GET: Mummies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mummies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Location,HeadDirection,Sex,HairColor,BurialNumber,AgeAtDeath,StructureValue,ColorValue,TextileValue,FieldNotes,Length,Photo,Id")] Mummy mummy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mummy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mummy);
        }

        [Authorize(Roles = "Admin, Researcher")]
        // GET: Mummies/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Mummies == null)
            {
                return NotFound();
            }

            var mummy = await _context.Mummies.FindAsync(id);
            if (mummy == null)
            {
                return NotFound();
            }
            return View(mummy);
        }

        // POST: Mummies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Location,HeadDirection,Sex,HairColor,BurialNumber,AgeAtDeath,StructureValue,ColorValue,TextileValue,FieldNotes,Length,Photo,Id")] Mummy mummy)
        {
            if (id != mummy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mummy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MummyExists(mummy.Id))
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
            return View(mummy);
        }

        [Authorize(Roles = "Admin, Researcher")]
        // GET: Mummies/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Mummies == null)
            {
                return NotFound();
            }

            var mummy = await _context.Mummies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mummy == null)
            {
                return NotFound();
            }

            return View(mummy);
        }

        // POST: Mummies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Mummies == null)
            {
                return Problem("Entity set 'intex2Context.Mummies'  is null.");
            }
            var mummy = await _context.Mummies.FindAsync(id);
            if (mummy != null)
            {
                _context.Mummies.Remove(mummy);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MummyExists(long id)
        {
            return (_context.Mummies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
