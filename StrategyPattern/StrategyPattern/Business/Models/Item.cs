namespace StrategyPattern.Business.Models
{
    public class Item
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public ItemType ItemType { get; set; }

        public Item(string code, string name, decimal price, ItemType itemType)
        {
            this.ItemCode = code;
            this.ItemName = name;
            this.ItemPrice = price;
            this.ItemType = ItemType;
        }
    }
}