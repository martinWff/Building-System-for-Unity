using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ModelLoaderSystem
{
    public class ObjectBuilderData
    {
        public readonly string label;
        public readonly string category;
        internal readonly List<ObjectBuildingInstruction> instructions = new List<ObjectBuildingInstruction>();

        public UnityEvent<GameObject> onGameObjectLoaded;

        internal ObjectBuilderData(string lbl,string category)
        {
            label = lbl;
            this.category = category;
        }

        internal void Build(GameObject g)
        {
            for (int i = 0; i < instructions.Count; i++)
            {
                instructions[i].Step(g);
            }

            if (onGameObjectLoaded != null)
            {
                onGameObjectLoaded.Invoke(g);
            }
        }

    }
}
