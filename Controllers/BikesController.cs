using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using Vroom.Data;
using Vroom.Models;

namespace Vroom.Controllers
{
    public class BikesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public BikesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Bikes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Bike.Include(b => b.Currency).Include(b => b.Make).Include(b => b.Model);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Bikes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bike = await _context.Bike
                .Include(b => b.Currency)
                .Include(b => b.Make)
                .Include(b => b.Model)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bike == null)
            {
                return NotFound();
            }

            return View(bike);
        }

        // GET: Bikes/Create
        public IActionResult Create()
        {
            ViewData["CurrencyId"] = new SelectList(_context.Currency, "Id", "Name");
            ViewData["MakeId"] = new SelectList(_context.Make, "Id", "Name");
            ViewData["ModelId"] = new SelectList(_context.Model, "Id", "Name");
            return View();
        }

        // POST: Bikes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MakeId,ModelId,Year,Mileage,Features,SellerName,SellerEmail,SellerPhone,Price,CurrencyId,Image")] Bike bike)
        {
            //if (ModelState.IsValid)
            //{
            if (bike.Image != null)

            {
                string AbsolutePath = "C:\\Program Files\\installed apps\\Linux comanned\\crzylearning\\DotNet Apps\\Vroom\\wwwroot";
                string RelativePath = "/Images/Bikes";
                RelativePath += Guid.NewGuid().ToString() + "_" + bike.Image.FileName;
                AbsolutePath += RelativePath;
                bike.ImagePath = RelativePath;

                string ServerFolder = Path.Combine(_webHostEnvironment.WebRootPath, AbsolutePath);

                await bike.Image.CopyToAsync(new FileStream(ServerFolder,FileMode.Create));

            }

            _context.Add(bike);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            ViewData["CurrencyId"] = new SelectList(_context.Currency, "Id", "Name", bike.CurrencyId);
            ViewData["MakeId"] = new SelectList(_context.Make, "Id", "Name", bike.MakeId);
            ViewData["ModelId"] = new SelectList(_context.Model, "Id", "Name", bike.ModelId);
            return View(bike);
        }

        // GET: Bikes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bike = await _context.Bike.FindAsync(id);
            if (bike == null)
            {
                return NotFound();
            }
            ViewData["CurrencyId"] = new SelectList(_context.Currency, "Id", "Name", bike.CurrencyId);
            ViewData["MakeId"] = new SelectList(_context.Make, "Id", "Name", bike.MakeId);
            ViewData["ModelId"] = new SelectList(_context.Model, "Id", "Name", bike.ModelId);
            return View(bike);
        }

        // POST: Bikes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MakeId,ModelId,Year,Mileage,Features,SellerName,SellerEmail,SellerPhone,Price,CurrencyId,ImagePath")] Bike bike)
        {
            if (id != bike.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {
                    _context.Update(bike);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BikeExists(bike.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
           // }
            ViewData["CurrencyId"] = new SelectList(_context.Currency, "Id", "Name", bike.CurrencyId);
            ViewData["MakeId"] = new SelectList(_context.Make, "Id", "Name", bike.MakeId);
            ViewData["ModelId"] = new SelectList(_context.Model, "Id", "Name", bike.ModelId);
            return View(bike);
        }

        // GET: Bikes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bike = await _context.Bike
                .Include(b => b.Currency)
                .Include(b => b.Make)
                .Include(b => b.Model)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bike == null)
            {
                return NotFound();
            }

            return View(bike);
        }

        // POST: Bikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bike = await _context.Bike.FindAsync(id);
            if (bike != null)
            {
                _context.Bike.Remove(bike);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BikeExists(int id)
        {
            return _context.Bike.Any(e => e.Id == id);
        }
    }
}
