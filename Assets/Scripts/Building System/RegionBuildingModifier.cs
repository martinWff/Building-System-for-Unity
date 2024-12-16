using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingSystem
{
    public class RegionBuildingModifier : FurnitureBuildModifier
    {
        public Bounds bounds;

        [Tooltip("When TRUE the player must be outside of bounds")]
        public bool blacklist;

        public override bool Modify(FurniturePlacementData data, out FurniturePlacementData value)
        {
            value = data;

            if (blacklist)
            {
                return !bounds.Contains(data.position);
            } else
            {
                return bounds.Contains(data.position);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireCube(bounds.center, bounds.size);
        }
    }
}
