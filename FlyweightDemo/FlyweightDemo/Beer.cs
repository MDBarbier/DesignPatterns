using System;
using System.Collections.Generic;

namespace FlyweightDemo
{
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
}
