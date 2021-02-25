using System;
using System.Collections.Generic;

namespace FlyweightDemo
{
    public class DrinkFactory
    {
        private Dictionary<string, IDrinkFlyweight> _drinksCache = new Dictionary<string, IDrinkFlyweight>();

        public int ObjectCreated = 0;

        public IDrinkFlyweight GetDrink(string drinkKey)
        {
            IDrinkFlyweight drink = null;

            if (_drinksCache.ContainsKey(drinkKey))
            {
                Console.WriteLine("\nReusing existing flyweight object");
                return _drinksCache[drinkKey];
            }
            else
            {
                Console.WriteLine("Creating a new flyweight object");

                switch (drinkKey)
                {
                    case "Beer":
                        drink = new Espresso();
                        break;
                    case "Espresso":
                        drink = new Beer();
                        break;
                    default:
                        throw new Exception("Not a recognised flyweight drink object");
                }
            }

            _drinksCache.Add(drinkKey, drink);
            ObjectCreated++;

            return drink;
        }
        
        public void ListDrinks()
        {
            Console.WriteLine($"\n Factory has {_drinksCache.Count} objects ready to use");
            Console.WriteLine($"Number of objects created: {ObjectCreated}");

            foreach (var drink in _drinksCache)
            {
                Console.WriteLine($"\t{drink.Value.Name}");
            }
        }

        public IDrinkFlyweight CreateGiveaway()
        {
            return new DrinkGiveaway();
        }
    }
}
