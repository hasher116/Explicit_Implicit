using System;

namespace Explicit_Implicit
{
    class Program
    {
        static void Main(string[] args)
        {
            ////////////////////////////////// преобразование простых объектов 
            
            byte q = 5, w = 6;
            int r = q + w; // неявное (implicit) преобразование простых типов. из byte в int, который больше

            int a = 5, b = 6;
            byte c = (byte) (a + b); // явное (explicit) преобразование простых типов. из int в byte, который меньше

            ////////////////////////////////// преобразование объектов класса

            Employee employee = new Employee("Andrew", "GGDSK");
            Person person = employee;
            person.Name = "Vasya";
            Console.WriteLine($"{person.Name}, {employee.Name}");

            Person person2 = new Employee("Hasher116", "GGDSK"); // восходящее преобразование (Upcasting). Сотрудник employee является person-ой.
                                                                 // Но персона не обязательно будет являться employee

            Employee employee2 = new Employee("Igor", "BMZ");
            Person person3 = employee;
            Employee employee3 = (Employee) person3; // Не каждая person-а является employee, поэтому используем нисходящее (Downcasting) и явное преобразование

            Person person4 = new Client("Petr", "Prior"); // пример
            Client client = (Client) person4;
            Object obj = person4;
            Console.WriteLine("\n");
            ((Client)obj).Display();
            Console.WriteLine(((Client)obj).Bank);

            Object obj2 = new Employee("Bill", "Microsoft"); // ошибка. Билл является сотрудником. При попытке узнать банк через явное преобразование - логичная ошибка
            //string bank = ((Client)obj2).Bank;

            Person hash = new Person("Hash"); // ошибка
            //Employee empHash = (Employee) hash;

            ////////////////////////////////// способы преобразования
            // 1 cпособ. as

            Person person5 = new Person("Tom");
            Employee emp2 = person5 as Employee;
            if (emp2 == null)
            {
                Console.WriteLine("emp2 = null");
            }
            else
            {
                Console.WriteLine("emp2 = person");
                Console.WriteLine($"{emp2.Name}, {emp2.Company}");
            }

            // 2 способ. Обработка исключений

            Person person6 = new Person("TomTom");
            try
            {
                Employee emp3 = (Employee)person6;
                Console.WriteLine($"{emp3.Name}, {emp3.Company}");
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // 3 способ. is

            Person person7 = new Person("TomTomTom");
            if(person7 is Employee)
            {
                Employee emp4 = (Employee)person7;
                Console.WriteLine(emp4.Company);
            }
            else
            {
                Console.WriteLine("Преобразование недопустимо");
            }
        }
    }
}
