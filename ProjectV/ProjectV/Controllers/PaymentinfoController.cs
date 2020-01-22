using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using groupa4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectV.Models;

namespace ProjectV.Controllers
{
    public class PaymentinfoController : Controller
    {
        private readonly AdmissionDbContext _context;

        public PaymentinfoController(AdmissionDbContext context)
        {
            _context = context;
        }

        // GET: Marks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Paymentinfo.ToListAsync());
        }

        // GET: Marks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Paymentinfo = await _context.Paymentinfo
                .SingleOrDefaultAsync(m => m.Id == id);
            if (Paymentinfo == null)
            {
                return NotFound();
            }

            return View(Paymentinfo);
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
        public async Task<IActionResult> Create([Bind("Id,name,roll,rollid,totalammount,due")] Paymentinfo Paymentinfo)
        {
            if (ModelState.IsValid)
            {
                Paymentinfo b = new Paymentinfo {


                    name=Paymentinfo.name,
                    roll=Paymentinfo.roll,
                    rollid= Paymentinfo.rollid,
                    totalammount= Paymentinfo.totalammount,
                    Due= 500- Paymentinfo.totalammount


                };
                _context.Add(b);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Paymentinfo);
        }

        // GET: Marks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Paymentinfo = await _context.Paymentinfo.SingleOrDefaultAsync(m => m.Id == id);
            if (Paymentinfo == null)
            {
                return NotFound();
            }
            return View(Paymentinfo);
        }

        // POST: Marks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,roll,rollid,totalammount,due")] Paymentinfo Paymentinfo)
        {
            if (id != Paymentinfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Paymentinfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentinfoExists(Paymentinfo.Id))
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
            return View(Paymentinfo);
        }

        // GET: Marks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Paymentinfo = await _context.Paymentinfo
                .SingleOrDefaultAsync(m => m.Id == id);
            if (Paymentinfo == null)
            {
                return NotFound();
            }

            return View(Paymentinfo);
        }

        // POST: Marks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Paymentinfo = await _context.Paymentinfo.SingleOrDefaultAsync(m => m.Id == id);
            _context.Paymentinfo.Remove(Paymentinfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentinfoExists(int id)
        {
            return _context.Paymentinfo.Any(e => e.Id == id);
        }
    }
}
