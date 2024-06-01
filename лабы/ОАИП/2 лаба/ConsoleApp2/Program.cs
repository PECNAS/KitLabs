using System;
class HelloWorld
{
    static void Main()
    {
        Console.WriteLine("Программа позволяет вам проверить свои знания\nи пройти небольшой тест на знание математики.\n\n" +
            "Вам задается вопрос. В ответе необходимо ввести букву варианта ответа");

        int points = 0;

        Console.WriteLine("2+2=?\nа)4\nб)5\nв)3");
        Console.Write("Ваш ответ: ");
        string answ = Console.ReadLine();
        if (answ == "а") points++;
        else if (answ != "а" && answ != "б" && answ != "в") Console.WriteLine("Такого варианта ответа не существует");

        Console.WriteLine("6-8*(-1)=?\nа)2\nб)14\nв)4");
        Console.Write("Ваш ответ: ");
        answ = Console.ReadLine();
        if (answ == "б") points++;
        else if (answ != "а" && answ != "б" && answ != "в") Console.WriteLine("Такого варианта ответа не существует");

        Console.WriteLine("8*8-8=?\nа)4\nб)0\nв)56");
        Console.Write("Ваш ответ: ");
        answ = Console.ReadLine();
        if (answ == "в") points++;
        else if (answ != "а" && answ != "б" && answ != "в") Console.WriteLine("Такого варианта ответа не существует");

        Console.WriteLine("7^5=?\nа)49\nб)16 807\nв)2 401");
        Console.Write("Ваш ответ: ");
        answ = Console.ReadLine();
        if (answ == "б") points++;
        else if (answ != "а" && answ != "б" && answ != "в") Console.WriteLine("Такого варианта ответа не существует");

        Console.WriteLine("!9=?\nа)362 880\nб)3\nв)0");
        Console.Write("Ваш ответ: ");
        answ = Console.ReadLine();
        if (answ == "а") points++;
        else if (answ != "а" && answ != "б" && answ != "в") Console.WriteLine("Такого варианта ответа не существует");


        if (points == 1) Console.WriteLine($"Вы набрали {points} балл");
        if (points == 2 || points == 3 || points == 4) Console.WriteLine($"Вы набрали {points} балла");
        else Console.WriteLine($"Вы набрали {points} баллов");
    }
}