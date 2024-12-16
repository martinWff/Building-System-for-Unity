using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingSystem
{
    public struct FurniturePlacementData
    {
        public GameObject furniture;
        public Vector3 position;
        public Quaternion orientation;

        public FurniturePlacementData(Vector3 pos,Quaternion orientation,GameObject furn)
        {
            this.furniture = furn;
            this.orientation = orientation;
            this.position = pos;
        }
    }
}
