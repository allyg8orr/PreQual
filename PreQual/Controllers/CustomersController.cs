using System;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PreQual.Models;

namespace PreQual.Controllers
{
    public class CustomersController : Controller
    {
        private readonly PreQualContext _context;

        public CustomersController(PreQualContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customer.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.ID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Forename,Surname,DOB,Income,Result")] Customer customer)
        {
            //just figuring out their age
            var today = DateTime.Today;
            var age = today.Year - customer.DOB.Year; //how many years
            if (customer.DOB.Date > today.AddYears(-age)) age--; //if they have had their bday this year or not
            if (ModelState.IsValid)
            {
                //if they're under 18 they don't get a card
                if (age < 18)
                {
                    customer.Result = "No credit cards are available";
                }
                else
                {
                    //more than 30000 = barclaycard
                    if(customer.Income > 30000)
                    {
                        customer.Result = "Barclaycard";
                    }
                    //otherwise vanquis
                    else
                    {
                        customer.Result = "Vanquis";
                    }
                }
                _context.Add(customer);
                await _context.SaveChangesAsync();
                //now to go to the results page
                return RedirectToAction(nameof(Results));
            }
            return View(customer);
        }
        
        public ActionResult Results()
        {
            //getting the latest entry in the database
            var customer = _context.Customer.OrderByDescending(m => m.ID).First();
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Forename,Surname,DOB,Income,Result")] Customer customer)
        {
            if (id != customer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.ID))
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.ID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.ID == id);
        }
    }
}
