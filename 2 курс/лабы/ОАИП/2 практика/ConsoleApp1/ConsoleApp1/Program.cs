using Microsoft.VisualBasic.FileIO;
using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace Test
{
    class Client
    {
        private string surname;
        private string name;
        private string service_type;

        public Client(string surname, string name, string service_type)
        {
            this.surname = surname;
            this.name = name;
            this.service_type = service_type;
        }

        public string Surname { get { return this.surname; } set { this.surname = value; } }
        public string Name { get { return this.name; } set { this.name = value; } }
        public string Service_type { get { return this.service_type; } set { this.service_type = value; } }

        public string get_data_for_print()
        {
            return $"Фамилия, Имя: {this.surname} {this.name}. Услуга: {this.service_type}";
        }

        public string get_fullname()
        {
            return $"{this.surname} {this.name}";
        }
    }

    class Salon<T>
    {
        public int c_length;
        public Client[] c_data = new Client[0];

        public void push_back(Client value)
        {
            c_length++;
            Client[] temp = new Client[c_length]; // создаем временную локальную переменную

            for (int i = 0; i < c_length - 1; i++)
            {
                temp[i] = c_data[i];
            }

            temp[c_length - 1] = value;

            this.c_data = temp;


        }

        public string delete_last()
        {
            this.c_length--;
            Client temp = c_data[c_length];
            this.c_data[c_length] = null; // зануляем элемент, который удаляем. Он будет переназначен новым добавленным или удален деструктором

            return temp.get_fullname();
        }

        public void print_all()
        {
            for (int i = 0; i < this.c_length; i++)
            {
                Console.WriteLine($"{i + 1}: {this.c_data[i].get_data_for_print()}");
            }
        }

        public void print_length()
        {
            Console.WriteLine($"Количество объектов в контейнере: {this.c_length}");
        }

        public void clear()
        {
            this.c_data = new Client[0];
            this.c_length = 0;
        }

        public Client this[int i] => c_data[i]; // перегрузка оператора индексации

        ~Salon()
        {
            this.clear();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Salon<Client> container = new Salon<Client>();
            string ans = "-1";

            Console.WriteLine("Здравствуйте!\nПеред вами небольшое меню управления клиентами нашего салона\n" +
                "Для добавления клиента нажмите 1\nДля удаление последнего добавленного клиента нажмите 2\n" +
                "Для вывода на экран информации обо всех клиентах нажмите 3\nДля вывода количества всех клиентов нажмите 4\n" +
                "Для очистики базы клиентов нажмите 5\nДля завершения программы нажмите 0\n\nУдачного пользования!\n\n");

            while (ans != "0")
            {
                Console.Write("Команда: ");
                ans = Console.ReadLine().ToString();

                if (ans == "1")
                {
                    Console.Write("О, новый клиент? Введите его Имя: ");
                    string name = Console.ReadLine();
                    Console.Write("Фамилия: ");
                    string surname = Console.ReadLine();
                    Console.Write("Тип услуги: ");
                    string service_type = Console.ReadLine();

                    container.push_back(new Client(
                                surname = surname,
                                name = name,
                                service_type = service_type)
                            );

                    Console.WriteLine("Новый пользователь успешно добавлен!\n");


                }
                else if (ans == "2")
                {
                    string fullname = container.delete_last();
                    Console.WriteLine($"Пользователь {fullname} успешно удален!\n");

                }
                else if (ans == "3")
                {
                    container.print_all();
                    Console.WriteLine();

                }
                else if (ans == "4")
                {
                    container.print_length();

                }
                else if (ans == "5")
                {
                    Console.WriteLine("Вы уверены, что хотите удалить все данные(Да/Нет)?");
                    if (Console.ReadLine() == "Да")
                    {
                        container.clear();
                        Console.WriteLine("Данные успешно удалены!\n");
                    }
                    else Console.WriteLine("Удаление отменено");

                }
                else if (ans == "0")
                {
                    Console.WriteLine("До встречи!");
                    break;

                }
                else
                {
                    Console.WriteLine("Вы ввели пункт, которого не существует в меню! Пожалуйста, введите цифру от 1 до 5 или 0 для выхода");
                }
            }
        }
    }
}
