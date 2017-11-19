using System.Collections.Generic;

namespace ArcEngine
{
    public class GameObject
    {
        private static ulong curID = 0;

        public ulong ID { get; }
        public string Name { get; set; }
        public bool Enabled { get; set; } = true;

        private List<Component> _components = new List<Component>();

        public GameObject() : this("GameObject") { }
        public GameObject(string name)
        {
            ID = curID++;
            Name = name;
        }
    }
}