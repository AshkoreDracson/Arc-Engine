using System;
using System.Collections.Generic;
using System.Linq;

namespace ArcEngine
{
    public static class Layer
    {
        private static Dictionary<int, string> layerNames = new Dictionary<int, string>();

        static Layer()
        {
            Register("Default", 0);
        }

        public static int Get(string name)
        {
            return layerNames.FirstOrDefault(o => o.Value == name).Key;
        }

        public static void Register(string name, int layerIndex)
        {
            if (layerNames.ContainsValue(name))
                throw new Exception("There is already a layer with this name!");

            layerIndex = layerIndex.Clamp(0, 32);
            layerIndex = 1 << layerIndex;

            if (layerNames.ContainsKey(layerIndex))
                layerNames[layerIndex] = name;
            else
                layerNames.Add(layerIndex, name);
        }

        public static void Unregister(string name)
        {
            if (layerNames.ContainsValue(name))
                layerNames.Remove(layerNames.First(o => o.Value == name).Key);
        }
    }
}