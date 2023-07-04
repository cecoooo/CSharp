using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class SingletonContainer : ISingletonContainer
    {
        private Dictionary<string, int> _capitals = new Dictionary<string, int>();
        private static SingletonContainer instance = new SingletonContainer();
        public static SingletonContainer Instance => instance;

        public SingletonContainer() 
        {
            Console.WriteLine("Initializing singleton object");
            var elements = File.ReadAllLines("C:\\Users\\User\\Desktop\\capitals.txt");
            for (int i = 0; i < elements.Length; i+=2)
            {
                _capitals[elements[i]] = int.Parse(elements[i+1]);
            }
        }

        int ISingletonContainer.GatPopulation(string name)
        {
            return _capitals[name];
        }
    }
}
