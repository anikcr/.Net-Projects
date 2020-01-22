using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectV.Models;

namespace ProjectV.Controllers
{
    public class AccountController : Controller
    {
        private readonly AdmissionDbContext _context;

        public AccountController(AdmissionDbContext context)
        {
            _context = context;
        }

        // GET: Marks
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentAccount.ToListAsync());
        }

        // GET: Marks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var StudentAccount = await _context.StudentAccount
                .SingleOrDefaultAsync(m => m.Id == id);
            if (StudentAccount == null)
            {
                return NotFound();
            }

            return View(StudentAccount);
        }

        // GET: Marks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Marks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Rollno,SClass,Year,Studentid")] StudentAccount StudentAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(StudentAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(StudentAccount);
        }


        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Rollno,SClass,Year,Studentid")] StudentAccount StudentAccount)
        {
            if (id != StudentAccount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(StudentAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentAccountExists(StudentAccount.Id))
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
            return View(StudentAccount);
        }



        // GET: Marks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var StudentAccount = await _context.StudentAccount
                .SingleOrDefaultAsync(m => m.Id == id);
            if (StudentAccount == null)
            {
                return NotFound();
            }

            return View(StudentAccount);
        }

        // POST: Marks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var StudentAccount = await _context.StudentAccount.SingleOrDefaultAsync(m => m.Id == id);
            _context.StudentAccount.Remove(StudentAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentAccountExists(int id)
        {
            return _context.StudentAccount.Any(e => e.Id == id);
        }
    }
}
