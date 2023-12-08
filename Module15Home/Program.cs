using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

class MyClass
{
    public int MyProperty1 { get; set; }
    public string MyProperty2 { get; set; }
}

class Program
{
    static void Main()
    {
        Type consoleType = typeof(Console);
        MethodInfo[] consoleMethods = consoleType.GetMethods();

        Console.WriteLine("Список методов класса Console:");
        foreach (var method in consoleMethods)
        {
            Console.WriteLine(method.Name);
        }

        Console.WriteLine("\n--------------------------------\n");

        MyClass myObject = new MyClass
        {
            MyProperty1 = 42,
            MyProperty2 = "Hello, Reflection!"
        };

        Type myObjectType = myObject.GetType();
        PropertyInfo[] properties = myObjectType.GetProperties();

        Console.WriteLine("Свойства и их значения из экземпляра класса MyClass:");

        foreach (var property in properties)
        {
            object value = property.GetValue(myObject);
            Console.WriteLine($"{property.Name}: {value}");
        }

        Console.WriteLine("\n--------------------------------\n");

        string originalString = "Hello, Reflection!";
        int length = 5;

        Type stringType = typeof(string);
        MethodInfo substringMethod = stringType.GetMethod("Substring", new Type[] { typeof(int) });

        if (substringMethod != null)
        {
            object[] parameters = { length };
            object result = substringMethod.Invoke(originalString, parameters);

            Console.WriteLine($"Подстрока: {result}");
        }

        Console.WriteLine("\n--------------------------------\n");

        Type listType = typeof(List<>);
        ConstructorInfo[] listConstructors = listType.GetConstructors();

        Console.WriteLine("Список конструкторов класса List<T>:");

        foreach (var constructor in listConstructors)
        {
            Console.WriteLine(constructor);
        }
    }
}

