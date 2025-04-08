/******************************************************************************

                            Online C# Compiler.
                Code, Compile, Run and Debug C# program online.
Write your code in this editor and press "Run" button to execute it.

*******************************************************************************/

using System;
class HelloWorld {
  static void Main() {
    double x;
    double y;
    
    x = Convert.ToDouble(Console.ReadLine());
    y = Convert.ToDouble(Console.ReadLine());
    
    if (x > -1 && x < 1 && y > -1 && y < 1) {
        Console.WriteLine($"Точка x={x}, y={y} принадлежит области");
    } else {
        Console.WriteLine($"Точка x={x}, y={y} не принадлежит области");
    }
  }
}
