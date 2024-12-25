using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GLTFast;
using System.IO;
using System;

namespace ModelLoaderSystem
{
    public class ModelLoaderManager : MonoBehaviour
    {
        internal static Dictionary<string, Type> builderNames = new Dictionary<string, Type>();
        internal static Dictionary<Type, Type> builderTypes = new Dictionary<Type, Type>();


        [SerializeField] ModelLoaderProcessor modelLoader;

        [SerializeField] List<ObjectContentProcessor> processors = new List<ObjectContentProcessor>();

        public UnityEvent<ObjectBuilderData> onObjectLoaded;
        public UnityEvent<GameObject> onGameObjectLoaded;

        public string categoryName;

        public ObjectBuilderData LoadObjectData(string label)
        {
            return LoadObjectData(categoryName, label);
        }

        public GameObject LoadObject(string label)
        {
            return LoadObject(categoryName, label);
        }

        public GameObject LoadObject(ObjectBuilderData data)
        {
            GameObject g = new GameObject(data.label, typeof(GltfBoundsAsset));

            if (data != null)
            {
                data.Build(g);
            }

            if (onGameObjectLoaded != null)
            {
                onGameObjectLoaded.Invoke(g);
            }

            return g;
        }


        public ObjectBuilderData LoadObjectData(string category,string label)
        {
            ObjectBuilderData bd = new ObjectBuilderData(label, category);

            if (modelLoader != null)
            {
                ObjectBuildingInstruction instruction = modelLoader.Process(this,category, label);
                if (instruction != null)
                {
                    bd.instructions.Add(instruction);
                }
            }

            for (int i = 0; i < processors.Count; i++)
            {
                ObjectContentProcessor proc = processors[i];

                ObjectBuildingInstruction instruction = proc.Process(this,category, label);
                if (instruction != null)
                {
                    bd.instructions.Add(instruction);
                }

            }

            if (onObjectLoaded != null)
            {
                onObjectLoaded.Invoke(bd);
            }

            return bd;
        }

        public GameObject LoadObject(string category,string label)
        {
            ObjectBuilderData data = LoadObjectData(category,label);

            return LoadObject(data);
        }

        public static void Register(Type type,string codename,Type builder)
        {
            if (builder.IsSubclassOf(typeof(ObjectComponentBuilder)) && type.IsSubclassOf(typeof(Component)))
            {
                UnsafeRegister(type,codename,builder);
            }
        }

        public static void Register<T1, T2>(string codename) where T1 : Component where T2 : ObjectComponentBuilder
        {
            UnsafeRegister(typeof(T1),codename,typeof(T2));
        }

        private static void UnsafeRegister(Type type, string codename, Type builder)
        {
            builderNames[codename] = type;
            builderTypes[type] = builder;
        }
    }
}
