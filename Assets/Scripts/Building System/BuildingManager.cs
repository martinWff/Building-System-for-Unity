using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildingManager : MonoBehaviour
{
    public UnityEvent<GameObject> onPlaced;
    public UnityEvent<GameObject> onRemoved;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Place(Vector3 position,GameObject furniture)
    {
        Place(position, Quaternion.identity, furniture);
    }

    public void Place(Vector3 position,Quaternion orientation,GameObject furniture)
    {
        GameObject g = Instantiate(furniture, position, orientation);

        if (onPlaced != null)
        {
            onPlaced.Invoke(g);
        }
    }

    public void Removed(Vector3 position)
    {
        
    }
}
