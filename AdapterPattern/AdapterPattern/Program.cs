using System;

namespace AdapterPattern
{
    class Program
    {
        /// <summary>
        /// Main is the 'client' for the demo
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            Console.WriteLine("Adapter pattern demo starting");

            ITarget target = new Adapter(new Adaptee());

            //Invoke the adapted method
            Console.WriteLine(target.GetRequest());

        }
    }

    public interface ITarget
    {
        string GetRequest();
    }

    /// <summary>
    /// A class with some useful functionality but for some reason is not compatible with our client
    /// </summary>
    public class Adaptee
    {
        public string GetSpecificRequest()
        {
            return "Specific request";
        }
    }

    public class Adapter: ITarget
    {
        private readonly Adaptee _adaptee;

        public Adapter(Adaptee adaptee)
        {
            this._adaptee = adaptee;
        }

        public string GetRequest()
        {
            return $"This is '{this._adaptee.GetSpecificRequest()}'";
        }
    }
}
