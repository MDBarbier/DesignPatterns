using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    public class Person :  PersonPrototype
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }

        public Person(string name, int age, Address address)
        {
            Name = name;
            Age = age;
            Address = address;
        }

        public override void Debug()
        {
            Console.WriteLine("-----Person data------");
            Console.WriteLine($"Name: {this.Name}");
            Console.WriteLine($"Age: {this.Age}");
            Console.WriteLine($"FirstLine: {this.Address.LineOne}");
            Console.WriteLine($"SecondLine: {this.Address.LineTwo}");
            Console.WriteLine($"ThirdLine: {this.Address.LineThree}");
            Console.WriteLine($"Postcode: {this.Address.PostCode}");
        }

        public override PersonPrototype ShallowCopy()
        {
            return (PersonPrototype)this.MemberwiseClone();
        }

        public override PersonPrototype DeepCopy()
        {
            var temp = (Person)this.ShallowCopy();
            temp.Address = new Address() { LineOne = this.Address.LineOne, LineTwo = this.Address.LineTwo, LineThree = this.Address.LineThree, PostCode = this.Address.PostCode };

            return temp;
        }

    }
}
