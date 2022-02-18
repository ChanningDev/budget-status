using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BudgetStatus.Data;
using BudgetStatus.Models;
using Microsoft.AspNetCore.Http;

namespace BudgetStatus.Controllers
{
    public class BdgfixmonthsController : Controller
    {
        private readonly SalesDbContext _context;


        public BdgfixmonthsController(SalesDbContext context)
        {
            _context = context;
        }

        // GET INDEX
        [HttpGet]
        public async Task<IActionResult> Index(int? SearchYear)
        {

            if (SearchYear == null)
            {
                SearchYear = DateTime.Now.Year;
            }

            ViewData["CurrentYear"] = SearchYear;
            ViewData["Byear"] = new SelectList(_context.Bdgfixmonth.Select(y => y.Byear).Distinct());
            

            var budgets = from s in _context.Bdgfixmonth
                          select s;

            if (SearchYear > 0)
            {
                budgets = budgets.Where(s => s.Byear.Equals(SearchYear)).OrderBy(b =>b.Counter);
            }

            var vm = new BdgfixmonthViewModel();
            
            var data = await budgets.AsNoTracking().ToListAsync();


            vm.Bdgfixmonths = data;
            //ViewBag.returnUrl = Request.Headers["Referer"].ToString();


            return View(vm);

        }



        // GET DETAILS
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var bdgfixmonth = await _context.Bdgfixmonth
                .FirstOrDefaultAsync(m => m.Counter == id);

            if (bdgfixmonth == null)
            {
                return NotFound();
            }

            return View(bdgfixmonth);
        }



        // GET CREATE
        public IActionResult Create()
        { 
            ViewData["Byear"] = new SelectList(_context.Bdgfixmonth.Select(y => y.Byear).Distinct());
            ViewData["Bbudget"] = new SelectList(_context.Bdgfixmonth.Select(y => y.Bbudget).Distinct());
            //ViewData["Bmonth"] = new SelectList(_context.Bdgfixmonth.Select(y => y.Bmonth).Distinct());
            //ViewData["Blongmonth"] = new SelectList(_context.Bdgfixmonth.Select(y => y.Blongmonth).Distinct());
            ViewData["Closed"] = new SelectList(_context.Bdgfixmonth.Select(y => y.Closed).Distinct());
            ViewData["Current"] = new SelectList(_context.Bdgfixmonth.Select(y => y.Current).Distinct());

            return View();
        }

        // POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Counter,Byear,Bbudget,Bmonth,Blongmonth,Closed,Current")] Bdgfixmonth bdgfixmonth)
        {
            if (ModelState.IsValid)
            {
                //Utilizzo il campo creato nella classe parziale
                bdgfixmonth.Bmonth = bdgfixmonth.NumericMonth;

                _context.Add(bdgfixmonth);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(bdgfixmonth);
        }

        // GET EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdgfixmonth = await _context.Bdgfixmonth.FindAsync(id);
            if (bdgfixmonth == null)
            {
                return NotFound();
            }
            ViewData["Byear"] = new SelectList(_context.Bdgfixmonth.Select(y => y.Byear).Distinct(), bdgfixmonth.Byear);
            ViewData["Bbudget"] = new SelectList(_context.Bdgfixmonth.Select(y => y.Bbudget).Distinct(), bdgfixmonth.Bbudget);
            ViewData["Closed"] = new SelectList(_context.Bdgfixmonth.Select(y => y.Closed).Distinct(), bdgfixmonth.Closed);
            ViewData["Current"] = new SelectList(_context.Bdgfixmonth.Select(y => y.Current).Distinct(), bdgfixmonth.Current);

            return View(bdgfixmonth);
        }

        // POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Counter,Byear,Bbudget,Bmonth,Blongmonth,Closed,Current")] Bdgfixmonth bdgfixmonth)
        {
            if (id != bdgfixmonth.Counter)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bdgfixmonth);
                    bdgfixmonth.Bmonth = bdgfixmonth.NumericMonth;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BdgfixmonthExists(bdgfixmonth.Counter))
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
            return View(bdgfixmonth);
        }

        // GET DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdgfixmonth = await _context.Bdgfixmonth
                .FirstOrDefaultAsync(m => m.Counter == id);
            if (bdgfixmonth == null)
            {
                return NotFound();
            }

            return View(bdgfixmonth);
        }

        // POST DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bdgfixmonth = await _context.Bdgfixmonth.FindAsync(id);
            _context.Bdgfixmonth.Remove(bdgfixmonth);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        private bool BdgfixmonthExists(int id)
        {
            return _context.Bdgfixmonth.Any(e => e.Counter == id);
        }
    }
}
