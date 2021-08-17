using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities;

namespace InventoryManager.Interfaces
{
    public interface IUnit
    {
        List<Unit> GetAllUnits(string sortProperty, SortOrder sortOrder);

        Unit GetUnit(int id);

        Unit Create(Unit unit);

        Unit Update(Unit unit);

        Unit Delete(Unit unit);
    }
}
