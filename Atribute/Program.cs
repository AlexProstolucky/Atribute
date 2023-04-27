using System;
using System.Reflection;
using static System.Console;
//using System.Attribute //Дозволяє створювати користувацькі атрибути
namespace Атрибути
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class CoderAttribute : Attribute
    {
        string _name = "Олексій";
        DateTime _date = DateTime.Now;
        public CoderAttribute() { }
        public CoderAttribute(string name, string date)
        {
            try
            {
                _name = name;
                _date = Convert.ToDateTime(date);
            }
            catch (Exception виняток)
            {
                WriteLine(виняток.Message);
            }
        }
        public override string ToString()
        {
            return $"Кодер: {_name}, дата: {_date}";
        }
    }
    [Coder]
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        [Coder("Олексій", "2021-05-6")]
        public void IncreaseWages(double wage)
        {
            Salary += wage;
        }
    }
    class Програма
    {
        static void Main(string[] аргументи)
        {
            WriteLine("\tАтрибути класа:");
            foreach (var attr in typeof(Employee).GetCustomAttributes())
            {
                WriteLine(attr);
            }
            WriteLine("\n\tАтрибути учасників класа:");
            foreach (MemberInfo info in typeof(Employee).GetMembers())
            {
                foreach (var attr in info.GetCustomAttributes(true))
                {
                    WriteLine(attr);
                }
            }
            Console.ReadKey();
        }
    }
}
