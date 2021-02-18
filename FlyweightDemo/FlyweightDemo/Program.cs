using System;
using System.Collections.Generic;

namespace FlyweightDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Flyweight demo starting");

            //Intrinsic state = unchanging data
            //Extrinsic state = object specific data can be passed in
            //Shared objects act as unchanging model, reused as needed and significantly reducec memory footprint

            //The flyweight pattern is useful when a large number of objects need to be created and most object state is extrinsic

            var drinkFactory = new DrinkFactory();

            drinkFactory.GetDrink(nameof(Espresso)).Serve(Sizes.Large.ToString());
            drinkFactory.GetDrink(nameof(Beer)).Serve(Sizes.Small.ToString());
            drinkFactory.GetDrink(nameof(Espresso)).Serve(Sizes.Medium.ToString());
            drinkFactory.GetDrink(nameof(Espresso)).Serve(Sizes.Small.ToString());
            drinkFactory.GetDrink(nameof(Beer)).Serve(Sizes.Medium.ToString());
            drinkFactory.GetDrink(nameof(Beer)).Serve(Sizes.Large.ToString());

            //In the output, you can see each drink is only created once so the flyweight factory only contains 2 objects but six are "served up"

            drinkFactory.ListDrinks();

            Console.WriteLine("End of flyweight demo");
        }
    }

    public enum Sizes
    {
        Small,Medium,Large
    }

    public class Espresso : IDrinkFlyweight
    {
        private string _name;
        private IEnumerable<string> _ingredients;

        public string Name { get { return _name; } }

        public Espresso()
        {
            _name = nameof(Espresso);
            _ingredients = new List<string>() { "hot water", "coffee beans" };
        }

        public void Serve(string size)
        {
            Console.WriteLine($"- {size} {_name} with {string.Join(", ", _ingredients)}");
        }
    }

    public class Beer : IDrinkFlyweight
    {
        private string _name;
        private IEnumerable<string> _ingredients;
        public string Name { get { return _name; } }

        public Beer()
        {
            _name = nameof(Beer);
            _ingredients = new List<string>() { "water", "hops", "yeast" };
        }

        public void Serve(string size)
        {
            Console.WriteLine($"- {size} {_name} with {string.Join(", ", _ingredients)}");
        }
    }

    public interface IDrinkFlyweight
    {
        //Intrinsic state - shared/readonly
        public string Name { get; }

        //Extrinsic state
        public void Serve(string size);
    }

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
    }
}
