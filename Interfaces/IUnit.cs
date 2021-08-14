using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManager.Interfaces
{
    public interface IUnit
    {
        List<Unit> GetAllUnits();

        Unit GetUnit(int id);

        Unit Create(Unit unit);

        Unit Update(Unit unit);

        Unit Delete(Unit unit);
    }
}
