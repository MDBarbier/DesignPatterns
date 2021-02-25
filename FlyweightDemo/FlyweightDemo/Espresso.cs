using System;
using System.Collections.Generic;

namespace FlyweightDemo
{
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
}
