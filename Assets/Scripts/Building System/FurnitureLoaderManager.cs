using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GLTFast;
using System.IO;
using System;

namespace BuildingSystem
{
    public class FurnitureLoaderManager : MonoBehaviour
    {
        private static Dictionary<Type, FurnitureComponentBuilder> builders = new Dictionary<Type, FurnitureComponentBuilder>();
        private static Dictionary<string, Type> buildersNames = new Dictionary<string, Type>();

        public FurnitureScriptProcessor scriptProcessor;

        public FurnitureContentLoader contentLoader;

        public FurnPropertyDeserializer propertyDeserializer;

        public FurnHeaderDeserializer headerDeserializer;

        public GameObject LoadFurniture(string label)
        {
            GameObject g = new GameObject(label,typeof(GltfBoundsAsset),typeof(Furniture));
            GltfAsset asset = g.GetComponent<GltfAsset>();
            asset.Url = contentLoader.GetModelUrl(label);

            LoadHeader(label, g);
            LoadProperties(label,g);

            if (scriptProcessor != null)
            {
                LoadScript(label,g);
            }

            return g;
        }

        private void LoadProperties(string label,GameObject g)
        {
            string properties = contentLoader.GetProperties(label);
            if (string.IsNullOrEmpty(properties))
                return;

            List<FurnitureComponentData> list = Deserialize(properties);
            if (list != null && list.Count > 0)
            {
                InitProperties(g, list);
            }
        }

        private void LoadHeader(string label,GameObject g)
        {
            Furniture f = g.GetComponent<Furniture>();
            string properties = contentLoader.GetHeader(label);

            FurnitureHeaderData data = headerDeserializer.Deserialize(properties);
            f.title = data.title;
            f.description = data.description;
        }

        private FurnitureScriptProcessor LoadScript(string label,GameObject g)
        {
            string _script = contentLoader.GetScript(label);
            if (string.IsNullOrEmpty(_script))
                return null;

            FurnitureScriptProcessor proc = Instantiate(scriptProcessor);

            proc._Init(_script);

            FurnitureScriptBehaviour bhv = g.AddComponent<FurnitureScriptBehaviour>();

            bhv.LoadProcessor(proc);

            return proc;
        }

        private void InitProperties(GameObject g,List<FurnitureComponentData> properties)
        {
            for (int i = 0;i<properties.Count;i++)
            {
                InitComponentProperties(g,properties[i]);
            }
        }

        private void InitComponentProperties(GameObject g, FurnitureComponentData componentData)
        {
            if (componentData.componentType == null)
                return;

            if (builders.TryGetValue(componentData.componentType, out FurnitureComponentBuilder fcb))
            {
                fcb.Load(componentData.properties);
                fcb.Build(g);
            }
        }

        public static void Register(Type type,string codename,FurnitureComponentBuilder builder)
        {
            if (type.IsSubclassOf(typeof(Component)))
            {
                UnsafeRegister(type,codename,builder);
            }
        }

        public static void Register<T>(string codename, FurnitureComponentBuilder builder) where T : Component
        {
            UnsafeRegister(typeof(T),codename,builder);
        }

        private static void UnsafeRegister(Type type, string codename, FurnitureComponentBuilder builder)
        {
            builders[type] = builder;
            buildersNames[codename] = type;
        }

        private List<FurnitureComponentData> Deserialize(string content)
        {
            return propertyDeserializer.Deserialize(content,buildersNames);
        }


        [Serializable]
        public struct FurnitureData
        {
            public readonly int id;
            public readonly string name;
            public readonly Dictionary<string,object> properties;
            public readonly string script;

            public FurnitureData(int id,string name, Dictionary<string, object> properties,string script)
            {
                this.id = id;
                this.name = name;
                this.properties = properties;
                this.script = script;

            }
        }


        
    }
}
