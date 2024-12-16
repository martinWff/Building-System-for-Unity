using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingSystem
{
    public abstract class FurnPropertyDeserializer : ScriptableObject
    {
        public abstract List<FurnitureComponentData> Deserialize(string content, Dictionary<string, System.Type> buildersTypes);
    }
}
