using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class DailyReportBuilder : IFurnitureInventoryBuilder
    {
        private InventoryReport _inventoryReport;
        private IEnumerable<FurnitureItem> _items;

        public DailyReportBuilder(IEnumerable<FurnitureItem> items)
        {
            Reset();
            _items = items;
        }

        public IFurnitureInventoryBuilder AddDimensions()
        {
            _inventoryReport.DimensionsSection = string.Join(Environment.NewLine, _items.Select(a =>
                $"Product: {a.Name} \n" +
                $"Price: {a.Price}\n" +
                $"Height: {a.Height} x Width: {a.Width}\n" +
                $"Weight: {a.Weight}\n"));
            return this;
        }

        public IFurnitureInventoryBuilder AddLogistics(DateTime date)
        {
            _inventoryReport.LogisticsSection = $"Report generated on {date}";
            return this;
        }

        public IFurnitureInventoryBuilder AddTitle()
        {
            _inventoryReport.TitleSection = $"----- Daily Inventory report; Created by {nameof(DailyReportBuilder)}-----\n\n";
            return this;
        }

        public InventoryReport GetDailyReport()
        {
            var report = _inventoryReport;
            Reset();
            return report;
        }

        public void Reset()
        {
            _inventoryReport = new InventoryReport();
        }        
    }
}
