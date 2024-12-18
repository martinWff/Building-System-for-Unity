using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ModelLoaderSystem;


public class BuildingTester : MonoBehaviour
{
    public ModelLoaderManager furnLoader;

    // Start is called before the first frame update
    void Start()
    {
        ModelLoaderManager.Register<Light, LightningObjectComponentBuilder>("Light");
      //  furnLoader.LoadFurniture("Door");
       // furnLoader.LoadFurniture("Table");
        ObjectBuilderData obd = furnLoader.LoadObjectData("Door");
        
        Debug.Log(obd.label);

        furnLoader.LoadObject(obd);

        furnLoader.LoadObject("Table");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
