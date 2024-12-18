using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModelLoaderSystem
{
    public abstract class ObjectBuildingInstruction
    {
        public abstract void Step(GameObject obj);
    }
}
