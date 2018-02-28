// This is my first program in C#

using System;
// System is a namespace. 
// When we -use- it, we gain access to goodies such as Console

class Hello 
{
    class Cat
    {
        private const int legs = 4;

        private string noise = "Meow";

        public string Name
        {
            get; set;
        }

        public void greeting()
        {
            Console.WriteLine(noise + ", world!");
        }
    }

    // Hello doesn't have to have the same name as our file, but it's good style
    static void Main() 
    {
        // This looks a heck of a lot like Java, huh?
        Console.WriteLine("Hello, world!");
        // Note that we use PascalCase, not camelCase, and end statements with ;
        Console.WriteLine("Press any key to exit, world!");

        Cat fluffy = new Cat();

        fluffy.greeting();
        fluffy.Name = "Fluffy";

        Console.WriteLine("My name is " + fluffy.Name + ".");

        double xyz = 10.23d + 11.0d;
        decimal abc = 1.2345m + 10;

        Console.WriteLine(xyz);
        Console.WriteLine(abc);

        Console.ReadKey();
        // ReadKey takes in the next input from the user...it also prevents the 
        // console window from closing before the output is visible
    }
}
