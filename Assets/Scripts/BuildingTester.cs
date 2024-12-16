using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BuildingSystem;


public class BuildingTester : MonoBehaviour
{
    public BuildingManager manager;
    public FurnitureLoaderManager furnLoader;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(nameof(Light));
        FurnitureLoaderManager.Register<Light>("Light",new LightningFurnitureComponentBuilder());
        furnLoader.LoadFurniture("Door");

        furnLoader.LoadFurniture("Table");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
