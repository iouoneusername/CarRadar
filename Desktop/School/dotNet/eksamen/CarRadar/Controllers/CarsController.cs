using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRadar.Data;
using CarRadar.Models;
using Microsoft.AspNetCore.Authorization;


namespace CarRadar.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarRadarContext _context;

        public CarsController(CarRadarContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index(string brand, string model, int priceFrom = 0, int priceTo = 10000000, int yearFrom = 0, int yearTo = 2100)
        {

            //GET CARS FROM DB
            var cars = from c in _context.Car select c;

            //IF BRAND IS NOT NULL, SELECT CONTAINS
            if (!string.IsNullOrEmpty(brand))
            {
               cars = cars.Where(s => s.Brand.Contains(brand));
            }

            //IF MODEL IS NOT NULL, SELECT CONTAINS
            if (!string.IsNullOrEmpty(model))
            {
                cars = cars.Where(x => x.Model.Contains(model));
            }

            //WE DEFAULT VALUES FOR PRICE AND YEAR
            cars = cars.Where(x => x.Price >= priceFrom);
            cars = cars.Where(x => x.Price <= priceTo);
            cars = cars.Where(x => x.Year >= yearFrom);
            cars = cars.Where(x => x.Year <= yearTo);

            return View(await cars.ToListAsync());
        }



        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }


        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
//        [Authorize]
//        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,Model,Price,Year,Image,Link")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
//        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Model,Price,Year,Image,Link")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
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
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
//        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Car.FindAsync(id);
            _context.Car.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.Id == id);
        }
    }
}
