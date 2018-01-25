using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ArcEngine
{
    public abstract class GlobalScript
    {
        public virtual int Order => 0;

        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void Draw() { }

        internal static IEnumerable<T> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class
        {
            List<T> objects = new List<T>();
            foreach (Type type in
                Assembly.GetEntryAssembly().GetTypes()
                    .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
            {
                objects.Add((T)Activator.CreateInstance(type, constructorArgs));
            }
            return objects;
        }

        public void print(object o)
        {
            Console.WriteLine(o);
        }
    }
}