using System;

namespace FlyweightDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Flyweight demo starting");

            /* Intrinsic state = unchanging data
            *  Extrinsic state = object specific data can be passed in
            *  Shared objects act as unchanging model, reused as needed and significantly reducec memory footprint
            *
            *  The flyweight pattern is useful when a large number of objects need to be created and most object state is extrinsic
            */

            var drinkFactory = new DrinkFactory();

            drinkFactory.GetDrink(nameof(Espresso)).Serve(Sizes.Large.ToString());
            drinkFactory.GetDrink(nameof(Beer)).Serve(Sizes.Small.ToString());
            drinkFactory.GetDrink(nameof(Espresso)).Serve(Sizes.Medium.ToString());
            drinkFactory.GetDrink(nameof(Espresso)).Serve(Sizes.Small.ToString());
            drinkFactory.GetDrink(nameof(Beer)).Serve(Sizes.Medium.ToString());
            drinkFactory.GetDrink(nameof(Beer)).Serve(Sizes.Large.ToString());
            drinkFactory.CreateGiveaway().Serve(Sizes.Small.ToString());

            /* In the output, you can see each drink is only created once so the flyweight factory only contains 2 objects but six are "served up" 
             * You will also see the free giveaway drink, this is the behaviour defined in our unshared concrete flyweight.
             */

            drinkFactory.ListDrinks();

            Console.WriteLine("End of flyweight demo");
        }
    }
}
