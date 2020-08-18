using SingletonPattern_RightWay.Classes;
using System;
using System.Threading.Tasks;

namespace SingletonPattern_RightWay
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting lazy singleton demo");

            var data = new string[] { "1", "2", "3", "4", "5" };

            Parallel.ForEach(data, (a) => {
                Console.WriteLine("Run " + a);
                SingletonClass singleton = SingletonClass.Instance;
            });

            Console.WriteLine("Finished lazy singleton demo");
        }
    }
}
