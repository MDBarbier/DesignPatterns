using System;

namespace MediatorPatternDemo.Structural
{
    public class Colleague1 : Colleague
    {

        public override void HandleNotification(string message)
        {
            Console.WriteLine($"{nameof(Colleague1)} received notification message: {message}");
        }
    }
}
