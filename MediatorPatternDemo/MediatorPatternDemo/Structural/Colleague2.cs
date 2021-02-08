using System;

namespace MediatorPatternDemo.Structural
{
    public class Colleague2 : Colleague
    {
        public override void HandleNotification(string message)
        {
            Console.WriteLine($"{nameof(Colleague2)} received notification message: {message}");
        }
    }
}
