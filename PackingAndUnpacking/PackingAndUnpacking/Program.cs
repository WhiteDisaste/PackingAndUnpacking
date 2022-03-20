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
    }
}
