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
    public class loginController : Controller
    {
        private readonly AdmissionDbContext _context;

        public loginController(AdmissionDbContext context)
        {
            _context = context;
        }
        public IActionResult create()
        {
            return View();
        }

        // GET: login
        public async Task<IActionResult> Index()
        {
            return View(await _context.login.ToListAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> create([Bind("Id,email,password,actor_id")] login login)
        {
            if (ModelState.IsValid)
            {
                _context.Add(login);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(login);
        }

        
        private bool loginExists(int id)
        {
            return _context.login.Any(e => e.Id == id);
        }
    }
}
