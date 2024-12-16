using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BuildingSystem
{
    public class BuildingManager : MonoBehaviour
    {
        public UnityEvent<FurniturePlacementData> onPlaced;
        public UnityEvent<GameObject> onRemoved;

        [SerializeField] private List<FurnitureBuildModifier> modifiers = new List<FurnitureBuildModifier>();

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Place(Vector3 position, GameObject furniture)
        {
            Place(position, Quaternion.identity, furniture);
        }

        public void Place(Vector3 position, Quaternion orientation, GameObject furniture)
        {
            FurniturePlacementData data = new FurniturePlacementData(position, orientation, furniture);

            for (int i = 0;i<modifiers.Count;i++)
            {
                if (!modifiers[i].Modify(data,out data))
                {
                    return;
                }
            }

            data.furniture = Instantiate(furniture, data.position, data.orientation);


            if (onPlaced != null)
            {
                onPlaced.Invoke(data);
            }
        }
    }
}