using System;
using System.Collections;
using System.Collections.Generic;

namespace PackingAndUnpacking
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var service = new PackingUnpackingService();
            service.MethodExecute();

            Console.WriteLine("Занесите телефон в базу");
            Console.WriteLine("Введите, чей телефон заносится");
            var author = Console.ReadLine(); // danya | anya

            if (author == "danya")
            {
                var phone = new DanyaPhone();
                SaveToDatabase(phone);

            }
            else if (author == "anya")
            {
                var phone = new AnyaPhone();
                SaveToDatabase(phone);

            }
            else if (author == "kolya") // new author
            {
                var phone = new Phone<string>();
                SaveToDatabase(phone);

            }
            //...


            //Принимаем на вход строку символов
            //Проверить с помощью is, что введенная строка - это int
            //Преобразовать с помощью as в int и вывести результат число * 100
            Console.WriteLine("Введите строку");
            var stroka = GetStringFromConsole();
            if (stroka is int)
            {
                // тип пер1 = пер2 as тип
                int? per1 = stroka as int?;
            }
        }
    

        private List<string> str = new List<string>();

        private static void SaveToDatabase<T>(Phone<T> phone)
        {
            if (phone.GetType() == typeof(DanyaPhone))
            {
               //сохранять будем айдишник инт
            }
            else if (phone.GetType() == typeof(AnyaPhone))
            {
                //сохранять будем айдишник guid
            }
            else if (phone.GetType() == typeof(Phone<string>))
            {
                //сохранять айдишник string
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private static object GetStringFromConsole()
        {
            object result = Console.ReadLine();
            return result;
        }
        private static object GetIntFromConsole()
        {
            var result = Convert.ToInt32(Console.ReadLine());
            return result;
        }
    }
}
