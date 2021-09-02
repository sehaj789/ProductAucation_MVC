using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductAucation_MVC.Data;
using ProductAucation_MVC.Models;

namespace ProductAucation_MVC.Controllers
{
    [Authorize]
    public class Place_BidController : Controller
    {
        private readonly ProductAucationDbContext _context;

        public Place_BidController(ProductAucationDbContext context)
        {
            _context = context;
        }

        // GET: Place_Bid
        public async Task<IActionResult> Index()
        {
            var productAucationDbContext = _context.Place_Bid.Include(p => p.Product);
            return View(await productAucationDbContext.ToListAsync());
        }

        // GET: Place_Bid/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var place_Bid = await _context.Place_Bid
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (place_Bid == null)
            {
                return NotFound();
            }

            return View(place_Bid);
        }

        // GET: Place_Bid/Create
        public IActionResult Create()
        {
            ViewData["Productid"] = new SelectList(_context.Product, "Id", "Name");
            return View();
        }

        // POST: Place_Bid/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Your_Name,Email,Productid,Place_a_Bid")] Place_Bid place_Bid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(place_Bid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Productid"] = new SelectList(_context.Product, "Id", "Name", place_Bid.Productid);
            return View(place_Bid);
        }

        // GET: Place_Bid/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var place_Bid = await _context.Place_Bid.FindAsync(id);
            if (place_Bid == null)
            {
                return NotFound();
            }
            ViewData["Productid"] = new SelectList(_context.Product, "Id", "Name", place_Bid.Productid);
            return View(place_Bid);
        }

        // POST: Place_Bid/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Your_Name,Email,Productid,Place_a_Bid")] Place_Bid place_Bid)
        {
            if (id != place_Bid.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(place_Bid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Place_BidExists(place_Bid.Id))
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
            ViewData["Productid"] = new SelectList(_context.Product, "Id", "Name", place_Bid.Productid);
            return View(place_Bid);
        }

        // GET: Place_Bid/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var place_Bid = await _context.Place_Bid
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (place_Bid == null)
            {
                return NotFound();
            }

            return View(place_Bid);
        }

        // POST: Place_Bid/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var place_Bid = await _context.Place_Bid.FindAsync(id);
            _context.Place_Bid.Remove(place_Bid);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Place_BidExists(int id)
        {
            return _context.Place_Bid.Any(e => e.Id == id);
        }
    }
}
