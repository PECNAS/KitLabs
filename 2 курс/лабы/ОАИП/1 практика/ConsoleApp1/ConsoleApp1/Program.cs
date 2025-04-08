using System;

namespace HelloWorld
{
    public class Animals
    {
        public string name;
        public int age;
        public int weight;
        public int n_legs;

        public void set_name(string value)
        {
            name = value;
        }
        public void set_age(int value)
        {
            age = value;
        }
        public void set_weight(int value)
        {
            weight = value;
        }

        public void set_n_legs(int value)
        {
            n_legs = value;
        }

        public string get_name()
        {
            return name;
        }
        public int get_age()
        {
            return age;
        }
        public int get_weight()
        {
            return weight;
        }

        public int get_n_legs()
        {
            return n_legs;
        }

        public void eat()
        {
            Console.WriteLine($"{name} кушает");
        }

        public void razmnozenie()
        {
            Console.WriteLine("Занимается творением потомства");

        }

        public void move()
        {
            Console.WriteLine("Топает куда-то");

        }

        public void sound()
        {
            Console.WriteLine($"{name} что-то говорит");

        }

        public class Pig : Animals
        {
            public string color;
            public int n_eyes;

            public void set_color(string value)
            {
                color = value;
            }

            public void set_n_eyes(int value)
            {
                n_eyes = value;
            }
            public string get_color()
            {
                return color;
            }
            public int get_n_eyes()
            {
                return n_eyes;
            }

            public void move()
            {
                Console.WriteLine("Бегает");

            }

            public void sound()
            {
                Console.WriteLine("Визжит");

            }

            public void sleep()
            {
                Console.WriteLine("Свинка спит");
            }

            public void stay()
            {
                Console.WriteLine("Стоит на задних лапах");
            }
        }

        class Program
        {
            static void Main()
            {
                Pig radia = new Pig();
                radia.set_name("Peppa");
                radia.age = 1;
                radia.weight = 85;
                radia.n_legs = 4;

                radia.color = "Pink";
                radia.n_eyes = 2;

                Console.Write(radia.name);
                Console.Write(": вес-");
                Console.Write(radia.weight);
                Console.Write(", возраст-");
                Console.Write(radia.age);
                Console.WriteLine(" год");

                radia.sound();
                radia.move();
                radia.eat();
                radia.sleep();
                radia.stay();
                radia.razmnozenie();
            }
        }
    }

}
