using System;

namespace PrototypePattern
{
    class Program
    {
        /// <summary>
        /// This pattern is a creational pattern, and creates objects based on an existing prototype
        /// 
        /// It is useful when object creation, composition and representation needs to be seperate from a given system
        /// 
        /// Works well with Object Pool pattern (especially if manager class used as below)
        /// </summary>        
        static void Main()
        {
            Console.WriteLine("Welcome to the Prototype Pattern demo");

            //The prototype manager is a simple way to hold the instantiated prototype instances
            PrototypeManager pm = new PrototypeManager();

            var address = new Address() { LineOne = "10 Main St", LineTwo = "Oldtown", LineThree = "Southampton", PostCode = "SO1 1BA" };
            pm["p"] = new Person("Matt", 38, address);

            Console.WriteLine("\n\nOriginal:");
            pm["p"].Debug();

            //Perform the shallow copy
            pm["p2"] = (Person)pm["p"].ShallowCopy();
            
            //Change part of the reference type "Address"
            address.LineOne = "1 Main Street";

            //Change a value type
            var temp = (Person)pm["p"];
            temp.Name = "Dave";

            //Check what our objects look like
            Console.WriteLine("\n\nCompare p and pm2:");
            pm["p2"].Debug();
            pm["p"].Debug();

            //Output: Both orders have the amended address of "1 Main Street" because the reference type has been shared between the objects, 
            //although note the value type has not changed for both

            //Now we create another copy this time using a deep clone
            pm["p3"] = (Person)pm["p"].DeepCopy();

            //Change part of the reference type "Address"
            address.LineOne = "22 Main Street";

            //Change a value type
            var temp2 = (Person) pm["p"];
            temp2.Name = "Bob";

            //Check what our objects look like
            Console.WriteLine("\n\nCompare p and p3:");
            pm["p3"].Debug();
            pm["p"].Debug();

            //Output: Both orders have the amended address of "1 Main Street" because the reference type has been shared between the objects, 
            //although note the value type has not changed for both

        }
    }
}
