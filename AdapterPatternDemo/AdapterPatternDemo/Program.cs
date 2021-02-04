using System;

namespace AdapterPatternDemo
{
    class Program
    {
        static IAdapter adapterToUse;

        /// <summary>
        /// Adapter pattern
        /// 
        /// The adapter pattern solves the problem of incompatible interfaces
        /// 
        /// It uses polymorphism to achieve loose coupling and testability
        /// 
        /// -Object adapters hold an instance of the adaptee, implement or inherit the adapter type and use composition and single inheritance
        /// -Class adapters inherit from the adaptee, and the interface. This means they require multiple inheritance (not possible in c#). 
        ///  A variant implements the adapter interface instead of inheriting from it to make it c# compatible.
        ///  
        /// C# mostly uses object adapters, as it prefers composition over inheritance.
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            Console.WriteLine("Welcome to the adapter pattern demo");
            Console.WriteLine("");

            #region logic to choose service without adapter
            int serviceToUse = 1; //this parameter would be passed in or derived somehow
            string data;

            if (serviceToUse == 1)
            {
                var service = new Service1();
                data = service.GetData();
            }
            else if (serviceToUse == 2)
            {
                var service = new Service2();
                data = service.GetData();
            }
            else
            {
                throw new Exception("Unknown service");
            }

            #endregion

            #region Logic to choose service with adapter (object adapter) pattern

            ///Calls an external service's GetData method defined by the adapter injected
            string GetDataFromService(IAdapter adapter)
            {
                return adapter.GetData();
            }

            data = GetDataFromService(new Adapter2()); //This would be received via DI in reality

            Console.WriteLine("Data received from service: " + data);
            Console.WriteLine("");

            #endregion

            #region Class adapter pattern

            ///Calls an external service's GetData method defined by the adapter injected
            var adapter3 = new Adapter3(); 
            var data3 = adapter3.GetData();
            Console.WriteLine($"Data3: {data3}");
            Console.WriteLine("");

            #endregion

            Console.WriteLine("End of the adapter pattern demo");
        }
    }
}
