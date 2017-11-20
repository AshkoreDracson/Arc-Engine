using System.Collections.Generic;
using System.Linq;

namespace ArcEngine
{
    public class GameObject
    {
        private static ulong curID;

        public ulong ID { get; }
        public string Name { get; set; }
        public bool Enabled { get; set; } = true;

        public Transform transform { get; private set; }

        private List<Component> _components = new List<Component>();

        public GameObject() : this("GameObject") { }
        public GameObject(string name)
        {
            ID = curID++;
            Name = name;

            transform = AddComponent<Transform>();
        }

        public T AddComponent<T>() where T : Component, new()
        {
            T comp = new T();
            _components.Add(comp);
            return comp;
        }
        public T GetComponent<T>() where T : Component => _components.FirstOrDefault(comp => comp is T) as T;
        public T[] GetComponents<T>() where T : Component => (T[])_components.Where(comp => comp is T).ToArray();
        public void RemoveComponent<T>() where T : Component => _components.RemoveAll(comp => comp is T);
    }
}