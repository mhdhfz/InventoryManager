using InventoryManager.Infrastructure;
using InventoryManager.Interfaces;
using InventoryManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities;

namespace InventoryManager.Repositories
{
    public class UnitRepository : IUnit
    {
        private readonly ApplicationDbContext _context;

        public UnitRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Unit Create(Unit unit)
        {
            _context.Units.Add(unit);
            _context.SaveChanges();
            return unit;
        }

        public Unit Delete(Unit unit)
        {
            _context.Units.Attach(unit);
            _context.Entry(unit).State = EntityState.Deleted;
            _context.SaveChanges();

            return unit;
        }

        public List<Unit> GetAllUnits(string sortProperty, SortOrder sortOrder)
        {
            List<Unit> units = _context.Units.ToList();

            if (sortProperty.ToLower() == "name")
            {
                if (sortOrder == SortOrder.Ascending)
                {
                    units = units.OrderBy(n => n.Name).ToList();
                }
                else
                {
                    units = units.OrderByDescending(n => n.Name).ToList();
                }
            }
            else
            {
                if (sortOrder == SortOrder.Ascending)
                {
                    units = units.OrderBy(d => d.Description).ToList();
                }
                else
                {
                    units = units.OrderByDescending(d => d.Description).ToList();
                }
            }
            return units;
        }

        public Unit GetUnit(int id)
        {
            Unit unit = _context.Units.Where(u => u.Id == id).FirstOrDefault();
            return unit;
        }

        public Unit Update(Unit unit)
        {
            _context.Units.Attach(unit);
            _context.Entry(unit).State = EntityState.Modified;
            _context.SaveChanges();
            return unit;
        }
    }
}
