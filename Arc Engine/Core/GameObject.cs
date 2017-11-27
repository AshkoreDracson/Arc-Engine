using System.Collections.Generic;
using System.Linq;

namespace ArcEngine
{
    public class GameObject
    {
        public static IEnumerable<GameObject> All => _gameObjects;
        public static IEnumerable<GameObject> Root => _gameObjects.Where(go => go.transform.parent == null);

        private static readonly List<GameObject> _gameObjects = new List<GameObject>();
        private static ulong curID;

        public ulong ID { get; }
        public string Name { get; set; }
        public bool Enabled { get; set; } = true;
        public int Layer { get; set; } = ArcEngine.Layer.Get("Default");

        public Transform transform { get; }

        private readonly List<Component> _components = new List<Component>();

        public GameObject() : this("GameObject") { }
        public GameObject(string name)
        {
            ID = curID++;
            Name = name;

            transform = AddComponent<Transform>();

            _gameObjects.Add(this);
        }

        ~GameObject()
        {
            _gameObjects.Remove(this);
        }

        public T AddComponent<T>() where T : Component, new()
        {
            T comp = new T { gameObject = this };
            _components.Add(comp);
            return comp;
        }
        public T GetComponent<T>() where T : Component => _components.FirstOrDefault(comp => comp is T) as T;
        public T[] GetComponents<T>() where T : Component => (T[])_components.Where(comp => comp is T).ToArray();
        public List<Component> GetComponents() => _components;
        public IEnumerable<Component> GetComponentsEnumerable() => _components;
        public void RemoveComponent<T>() where T : Component => _components.RemoveAll(comp => comp is T);
    }
}