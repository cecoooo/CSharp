using System;
using System.Collections.Generic;
using System.Reflection;

namespace Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            Type type = typeof(MyClass);
            Console.WriteLine($"typeof(): {type}");
            Type type1 = Type.GetType("System.Text.StringBuilder");
            Console.WriteLine($"GetType(): {type1}");
            Console.WriteLine($"obj.GetType(): {myClass.GetType()}");
            Console.WriteLine($"FullName: {type.FullName}");
            Console.WriteLine($"Name: {type.Name}");
            Type baseType = type.GetType();
            Console.WriteLine($"BaseType: {baseType}");
            Type[] interfaces = type.GetInterfaces();
            Console.Write("GetInterfaces: ");
            for (int i = 0; i < interfaces.Length; i++)
            {
                Console.Write($"{interfaces[i]}");
                if (i < interfaces.Length - 1) Console.Write("; ");
            }
            Console.WriteLine();
            var myClass2 = Activator.CreateInstance(type1);
            Console.WriteLine(myClass2.GetType());
            FieldInfo field = type.GetField("name");
            Console.WriteLine($"Field: {field}");
            FieldInfo[] fields = type.GetFields();
            Console.Write("All public fields: ");
            for (int i = 0; i < fields.Length; i++)
            {
                Console.Write($"{fields[i]}");
                if (i < fields.Length - 1) Console.Write("; ");
            }
            Console.WriteLine();
            Console.Write("All fields: ");
            FieldInfo[] fieldsAll = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
            List<string> listOfNames = new List<string>();
            List<Type> listOfTypes = new List<Type>();
            for (int i = 0; i < fieldsAll.Length; i++)
            {
                Console.Write($"{fieldsAll[i]}");
                if (i < fieldsAll.Length - 1) Console.Write("; ");
                listOfNames.Add(fieldsAll[i].Name);
                listOfTypes.Add(fieldsAll[i].FieldType);
            }
            Console.WriteLine();
            Console.WriteLine($"Names of fields: {String.Join(", ", listOfNames)}");
            Console.WriteLine($"Types of fields: {String.Join(", ", listOfTypes)}");
            field.SetValue(myClass, "Pesho");
            Console.WriteLine($"Field value: {field.GetValue(myClass)}");
            Console.WriteLine($"Is field public: {field.IsPublic}");
            Console.WriteLine($"Is field protected: {field.IsFamily}");
            ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic);
            Console.Write("Constructors: ");
            for (int i = 0; i < constructors.Length; i++)
            {
                Console.Write(constructors[i]);
                if (i < constructors.Length - 1) Console.Write("; ");
            }
            Console.WriteLine();
            ConstructorInfo constructor = type.GetConstructor(new[] { typeof(int), typeof(string) });
            Console.WriteLine($"Constructor: {constructor}");
            ParameterInfo[] parameters = constructor.GetParameters();
            Console.Write("Parameters info for the constructor: ");
            for (int i = 0; i < parameters.Length; i++)
            {
                Console.Write(parameters[i]);
                if (i < parameters.Length - 1) Console.Write("; ");
            }
            Console.WriteLine();
            var myClass3 = constructor.Invoke(new object[] { 5, "gosho" });
            Console.WriteLine(myClass3.ToString());
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            Console.Write("Methods: ");
            for (int i = 0; i < methods.Length; i++)
            {
                Console.Write(methods[i]);
                if (i < methods.Length - 1) Console.Write("; ");
            }
            Console.WriteLine();
            MethodInfo method = type.GetMethod("ToString");
            Console.WriteLine($"ToString() method info: {method}");
            Console.WriteLine($"-Invoke myClass3.ToString() again-\n{method.Invoke(myClass3, new object[] { })}");
            Console.WriteLine(MyClass.DaysOfWeek.Thursday | MyClass.DaysOfWeek.Sunday);
        }
    }
}
