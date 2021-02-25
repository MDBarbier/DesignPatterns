using System;

namespace FlyweightDemo
{
    //Unshared concrete flyweight
    public class DrinkGiveaway : IDrinkFlyweight
    {

        //All state - unshareable intrinsic state. This doesn't help with memory but can help with edge cases.
        public string Name { get {return _randomDrink.Name;} }
        private IDrinkFlyweight[] _eligibleDrinks = new IDrinkFlyweight[]
        {
            new Espresso(),
            new Beer()
        };

        private IDrinkFlyweight _randomDrink;
        private string _size;

        public DrinkGiveaway()
        {
            var randomIndex = new Random().Next(0, 2);
            _randomDrink = _eligibleDrinks[randomIndex];
        }

        //Extrinsic state
        public void Serve(string size)
        {
            _size = size;
            Console.WriteLine($"Free giveaway!");
            Console.WriteLine($"- {size} {_randomDrink.Name} coming up!");
        }

    }
}
