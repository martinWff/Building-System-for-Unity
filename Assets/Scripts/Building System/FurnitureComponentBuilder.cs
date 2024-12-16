using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingSystem
{
    public abstract class FurnitureComponentBuilder
    {
        public abstract void Load(Dictionary<string, object> properties);
        public abstract void Build(GameObject furniture);
    }
}
