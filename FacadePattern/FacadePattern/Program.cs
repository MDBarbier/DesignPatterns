using FacadePattern.Facade;
using System;

namespace FacadePattern
{
    /// <summary>
    /// We as the client are accessing multiple services hidden 
    /// </summary>
    class Program
    {
        static void Main()
        {
            FacadeClass fc = new FacadeClass();

            int userId = 1234;
            var userName = fc.GetUserNameById(userId);
            fc.SendNotification(userName, userId);

            Console.WriteLine(userName);
        }
    }
}
