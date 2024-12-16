using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingSystem
{
    public abstract class FurnitureBuildModifier : MonoBehaviour
    {
        public abstract bool Modify(FurniturePlacementData data,out FurniturePlacementData value);
    }
}
