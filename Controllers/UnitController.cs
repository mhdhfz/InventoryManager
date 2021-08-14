using InventoryManager.Infrastructure;
using InventoryManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InventoryManager.Interfaces;

namespace InventoryManager.Controllers
{
    public class UnitController : Controller
    {
        private readonly IUnit _unitRepo;

        public UnitController(IUnit unitRepo)
        {
            _unitRepo = unitRepo;
        }

        public IActionResult Index()
        {
            List<Unit> units = _unitRepo.GetAllUnits();
            return View(units);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Unit unit = new Unit();
            return View(unit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Unit unit)
        {
            if (ModelState.IsValid)
            {
                unit = _unitRepo.Create(unit);
                return RedirectToAction(nameof(Index));
            }

            return View(unit);
        }

        public IActionResult Details(int id)
        {
            Unit unit = _unitRepo.GetUnit(id);
            return View(unit);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Unit unit = _unitRepo.GetUnit(id);
            return View(unit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Unit unit)
        {
            if (ModelState.IsValid)
            {
                unit = _unitRepo.Update(unit);
                TempData["Alert"] = "alert alert-success";
                TempData["Message"] = "unit updated successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(unit);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Unit unit = _unitRepo.GetUnit(id);
            return View(unit);
        }

        [HttpPost]
        public IActionResult Delete(Unit unit)
        {
            unit = _unitRepo.Delete(unit);

            TempData["Alert"] = "alert alert-success";
            TempData["Message"] = "unit deleted successfully";
            return RedirectToAction(nameof(Index));
        }

    }
}
