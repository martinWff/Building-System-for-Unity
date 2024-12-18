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


        public ObjectBuilderData LoadObjectData(string label)
        {
            ObjectBuilderData bd = new ObjectBuilderData(label);
            
            if (modelLoader != null)
            {
                ObjectBuildingInstruction instruction = modelLoader.Process(this, label);
                if (instruction != null)
                {
                    bd.instructions.Add(instruction);
                }
            }

            for (int i = 0;i<processors.Count;i++)
            {
                ObjectContentProcessor proc = processors[i];

                ObjectBuildingInstruction instruction = proc.Process(this,label);
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

        public GameObject LoadObject(string label)
        {
            ObjectBuilderData data = LoadObjectData(label);

            return LoadObject(data);
        }

        public GameObject LoadObject(ObjectBuilderData data)
        {
            GameObject g = new GameObject(data.label, typeof(GltfBoundsAsset));

            if (data != null)
            {
                BuildObject(data, g);
            }

            if (onGameObjectLoaded != null)
            {
                onGameObjectLoaded.Invoke(g);
            }

            return g;
        }


        private void BuildObject(ObjectBuilderData bd,GameObject g)
        {
            for (int i = 0;i<bd.instructions.Count;i++)
            {
                bd.instructions[i].Step(g);
            }
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

        public class ObjectBuilderData
        {
            public readonly string label;
            public readonly List<ObjectBuildingInstruction> instructions = new List<ObjectBuildingInstruction>();

            internal ObjectBuilderData(string lbl)
            {
                label = lbl;
            }

        }
    }
}
