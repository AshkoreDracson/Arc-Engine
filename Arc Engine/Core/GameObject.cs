using System.Collections.Generic;
using System.Linq;

namespace ArcEngine
{
    public class GameObject
    {
        public static IEnumerable<GameObject> All => _gameObjects;
        public static IEnumerable<GameObject> Root => _gameObjects.Where(go => go.Transform.Parent == null);

        private static readonly List<GameObject> _gameObjects = new List<GameObject>();
        private static ulong curID;

        public ulong ID { get; }
        public string Name { get; set; }
        public bool Enabled { get; set; } = true;
        public int Layer { get; set; } = ArcEngine.Layer.Get("Default");
        public string Tag { get; set; }

        public Transform Transform { get; }

        private readonly List<Component> _components = new List<Component>();

        public GameObject() : this("GameObject") { }
        public GameObject(string name)
        {
            ID = curID++;
            Name = name;
            Transform = AddComponent<Transform>();

            _gameObjects.Add(this);
        }

        ~GameObject()
        {
            _gameObjects.Remove(this);
        }

        public T AddComponent<T>() where T : Component, new()
        {
            T comp = new T { GameObject = this };
            _components.Add(comp);
            return comp;
        }
        public T GetComponent<T>() where T : Component => _components.FirstOrDefault(comp => comp is T) as T;
        public T[] GetComponents<T>() where T : Component => (T[])_components.Where(comp => comp is T).ToArray();
        public List<Component> GetComponents() => _components;
        public IEnumerable<Component> GetComponentsEnumerable() => _components;
        public void RemoveComponent<T>() where T : Component => _components.RemoveAll(comp => comp is T);

        public static GameObject Find(string name) => _gameObjects.FirstOrDefault(go => go.Name == name);
        public static GameObject FindByTag(string tag) => _gameObjects.FirstOrDefault(go => go.Tag == tag);
        public static IEnumerable<GameObject> FindGameObjectsByTag(string tag) => _gameObjects.Where(go => go.Tag == tag);
    }
}