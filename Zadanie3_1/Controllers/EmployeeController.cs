using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using Zadanie3_1.Data;
using Zadanie3_1.Models;

namespace Zadanie3_1.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context) { 
        
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var employees = await _context.Employees.ToListAsync();

            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task< IActionResult>Edit(int? id)
        {
            if (id == null || id <= 0) 
            { 
            return BadRequest();
            }
            var employeeinDb = await _context.Employees.FirstOrDefaultAsync(e => e.id == id);

            if (employeeinDb == null)
            {
                return NotFound();
         
            }

            return View(employeeinDb);
        }

        public async Task<IActionResult> Delete(int? id) {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            var employeeinDb = await _context.Employees.FirstOrDefaultAsync(e => e.id == id);

            if (employeeinDb == null)
            {
                return NotFound();

            }

            _context.Employees.Remove(employeeinDb);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (!ModelState.IsValid) { return View(employee); }
                
            

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
     
    }
}
