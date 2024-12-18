using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModelLoaderSystem
{
    public abstract class ObjectContentProcessor : ScriptableObject
    {
        public abstract ObjectBuildingInstruction Process(ModelLoaderManager loader,string label);
    }
}
