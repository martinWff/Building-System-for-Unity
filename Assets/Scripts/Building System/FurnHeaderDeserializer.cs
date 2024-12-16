using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingSystem
{
    public abstract class FurnHeaderDeserializer : ScriptableObject
    {
        public abstract FurnitureHeaderData Deserialize(string content);
    }

    public struct FurnitureHeaderData
    {
        public string title;
        public string description;
    }
}
