using System;
class HelloWorld
{
    static void Main()
    {
        double x;
        double y;
        Console.WriteLine("Программа принимает на вход две координаты: x, y\nЗатем программа высчитывает, принадлежит ли точка (x, y)\n" +
            " окружности с центром в точке (0, 0) и радиусом = 1");
        Console.Write("Введите x: ");
        x = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введите y: ");
        y = Convert.ToDouble(Console.ReadLine());

        if (x * x + y * y <= 1)
        {
            Console.WriteLine($"Точка x={x}, y={y} принадлежит области");
        }
        else
        {
            Console.WriteLine($"Точка x={x}, y={y} не принадлежит области");
        }
    }
}
