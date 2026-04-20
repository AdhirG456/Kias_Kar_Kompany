using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Kias_Kar_Kompany.Data;
using Kias_Kar_Kompany.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Kias_Kar_Kompany.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly Kias_Kar_KompanyContext _context;

        public VehiclesController(Kias_Kar_KompanyContext context)
        {
            _context = context;
        }

        // GET: VehiclesController
        public async Task<IActionResult> Index()
        {
            var vehicle = _context.Vehicle.ToList();
            return View(vehicle);
        }

        // GET: VehiclesController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var vehicle = _context.Vehicle.Find(id);
            if (vehicle == null) return NotFound();
            return View(vehicle);
        }

        // GET: VehiclesController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehiclesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleId, VehicleName, VehicleModel, VehiclePrice, VehicleType, VehicleImageURL")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // GET: VehiclesController/Edit/5
        
        private bool VehicleExists(int id)
        {
            return _context.Vehicle.Any(e => e.VehicleId == id );
        }

       

    }
}
