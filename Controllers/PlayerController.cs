using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Parcial.Data;
using Parcial.Models;

namespace Parcial.Controllers
{
    public class PlayerController : Controller
    {
        private readonly AppDbContext _context;

        // Constructor que recibe el contexto de la base de datos
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
        public IActionResult Create([Bind("Name,Age,Position")] Player player)
        {
            if (ModelState.IsValid)
            {
                _context.Add(player);  // Agregar el jugador al contexto
                _context.SaveChanges();  // Guardar los cambios en la base de datos
                return RedirectToAction(nameof(Index));  // Redirigir a la acción Index
            }
            return View(player);  // Si no es válido, volver al formulario con los datos ingresados
        }

        // Acción para asociar un jugador a un equipo
        public IActionResult AssignPlayerToTeam(int playerId, int teamId)
        {
            var assignment = new Assignment { PlayerId = playerId, TeamId = teamId };

            // Verificar si el jugador ya está asignado a este equipo
            var existingAssignment = _context.Assignments
                .FirstOrDefault(a => a.PlayerId == playerId && a.TeamId == teamId);

            if (existingAssignment == null)
            {
                _context.Assignments.Add(assignment);  // Agregar la nueva asociación
                _context.SaveChanges();  // Guardar los cambios en la base de datos
            }

            return RedirectToAction(nameof(Index));  // Redirigir a la acción Index
        }
    }
}
