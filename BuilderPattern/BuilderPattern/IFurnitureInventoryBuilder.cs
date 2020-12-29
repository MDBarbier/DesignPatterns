using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public interface IFurnitureInventoryBuilder
    {
        IFurnitureInventoryBuilder AddTitle();

        IFurnitureInventoryBuilder AddDimensions();

        IFurnitureInventoryBuilder AddLogistics(DateTime date);

        //In a less generic scenario this might be delegated to the concrete builder class
        InventoryReport GetDailyReport();
    }
}
