// This is my first program in C#

using System;
// System is a namespace. 
// When we are `using` it, we gain access to goodies such as Console.

class Hello 
{
    enum Meat { Chicken, Beef, Pepperoni }
    // Enums are lists of Consts, and their raw values are always integer values.

    abstract class Mammal 
    // Abstract classes exist only to serve as bases for derived classes.
    // We can't create an instance of Mammal, but we can make objects whose classes are derived from Mammal.
    {
        protected const bool gotMilk = true;
        protected const bool gotHair = true;
        protected const bool gotFeathers = false;
        // These are fields. 
        // They're just regular old values.
        // Protected means that they're only accessible to their own class and any derived classes.
        // Consts are immutable and must be intialized in the same line they are declared.
        // This is because the compiler directly drops the literal assigned to the const into the Common Intermediate Language code it produces, rather than giving it a reference to the const.
        // If you didn't immediately specify what you were assigning the const to, the compiler would have no idea what to say.

        private int eyeballs = 2;
        // Private fields are only accessible to the class they were defined in.

        public virtual String noise { get; }
        // This is a property. 
        // It is a special method that we can access as if it were a field.
        // Properties have getters and setters, just like in Swift.
        // The `virtual` keyword indicates that this method is allowed to be overridden by base classes.
        // The keyword is needed to indicate this even though the class is abstract.

        protected virtual bool isAGoodBoy { get; }

        public bool canTalkLikePeople
        {
            get { return false; }
        }
        // This method is not marked as virtual. 
        // We must provide an implementation for it.
        // If we want a method with the same signature in a derived class, we have to create a new function.
        // This makes two functions with the same signature. 
        // But the base class's implementation will be hidden by the derived class's.
    }

    class Marsupial: Mammal 
    {
        private const bool gotPouch = true;
    }

    interface Carnivore
    // Interfaces are what C# calls protocols. 
    // They're collections of methods with no implementation.
    // Classes that use them provide their own implementations.
    {
        void eat(Meat meat);
    }

    interface Felid 
    {
        void purr();
    }

    class Cat: Mammal, Carnivore, Felid
    // Classes can inherit from one base class, and multiple interfaces
    {
        private const int legs = 4;

        public override String noise
        {
            get { return "Meow"; }
        }

        public string Name
        {
            get; set;
        }

        public void eat(Meat meat) 
        {
            Console.WriteLine("Yum!");
        }

        public void purr()
        {
            Console.WriteLine("Prrrrrrrrrr");    
        }

        public void greeting()
        {
            Console.WriteLine(noise + ", world!");
        }
    }

    class Dog : Mammal, Carnivore
    {
        private const int legs = 4;

        public override String noise
        {
            get { return "Woof"; }
        }

        public string Name
        {
            get; set;
        }

        sealed protected override bool isAGoodBoy {
            get { return true; }
        }
        // Sealed means the property cannot be overriden by any derived classes of Dog

        public string fetch(string text) 
        {
            return text;
        }

        public void eat(Meat meat)
        {
            Console.WriteLine("Grryum!");
        }
    }

    class Kangaroo: Marsupial {
        private const int legs = 2;

        public override String noise 
        {
            get { return "Dunkaroos"; }
        }

        public new bool canTalkLikePeople 
        {
            get { return false; }
        }
        // Since our kangaroos can say Dunkaroos, we create a new property to specify that they CAN talkLikePeople.
        // this doesn't override the base class's property -- it creates an entirely `new` one.

        private (int, int) position = (0, 0);

        public string Name
        {
            get; set;
        }

        public void leap((int, int) toPosition) 
        {
            position.Item1 += toPosition.Item1;
            position.Item2 += toPosition.Item2;
        }

        public void RevealPosition()
        {
            Console.WriteLine(position);
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

        Dog griff = new Dog();
        Kangaroo joey = new Kangaroo();

        String stick = griff.fetch("Stick");
        Console.WriteLine(stick);

        joey.RevealPosition();
        joey.leap((1,4));
        joey.RevealPosition();
        joey.leap((3,-9));
        joey.RevealPosition();

        griff.eat(Meat.Pepperoni);

        Mammal[] Animals = { joey, fluffy, griff };

        foreach (Mammal animal in Animals) {
            Console.WriteLine(animal.noise);
        }

        Console.WriteLine(xyz);
        Console.WriteLine(abc);

        Console.ReadKey();
        // ReadKey takes in the next input from the user...it also prevents the 
        // console window from closing before the output is visible
    }
}
