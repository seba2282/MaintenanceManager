using Microsoft.AspNetCore.Mvc;
using MaintenanceManager.Data;
using MaintenanceManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaintenanceManager.Controllers
{
    [Authorize]
    public class MaintenanceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MaintenanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var maintenanceTasks = _context.MaintenanceTasks.Include(m => m.Machine);
            return View(await maintenanceTasks.ToListAsync());
        }

        public IActionResult Schedule()
        {
            ViewBag.Machines = new SelectList(_context.Machines, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Schedule(MaintenanceTask task)
        {
            if (ModelState.IsValid)
            {
                _context.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Machines = new SelectList(_context.Machines, "Id", "Name", task.MachineId);
            return View(task);
        }
    }
}
