using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModelLoaderSystem
{
    public abstract class ObjectComponentBuilder
    {
        public abstract void Load(Dictionary<string, object> properties);
        public abstract void Build(GameObject furniture);
    }
}
