using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Parcial.Data;
using Parcial.Models;

namespace Parcial.Controllers
{
    public class PlayerController : Controller
    {
        private readonly AppDbContext _context;

        public PlayerController(AppDbContext context)
        {
            _context = context;
        }

        // Acción GET para cargar el formulario
        public IActionResult Create()
        {
            return View();
        }

        // Acción POST para guardar los datos del formulario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,age,Position")] Player player)
        {
            if (ModelState.IsValid)
            {
                _context.Add(player);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(player);
        }
    }
}