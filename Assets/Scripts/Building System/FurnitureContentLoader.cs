using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingSystem
{
    public abstract class FurnitureContentLoader : ScriptableObject
    {
        public abstract string GetHeader(string label);
        public abstract string GetModelUrl(string label);
        public abstract string GetProperties(string label);
        public abstract string GetScript(string label);
    }
}
