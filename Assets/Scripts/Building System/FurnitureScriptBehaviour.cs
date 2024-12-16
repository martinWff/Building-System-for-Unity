using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingSystem
{
    public class FurnitureScriptBehaviour : MonoBehaviour
    {
        [SerializeField] FurnitureScriptProcessor scriptProcessor;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public FurnitureScriptProcessor GetProcessor()
        {
            return scriptProcessor;
        }

        public void LoadProcessor(FurnitureScriptProcessor processor)
        {
            this.scriptProcessor = processor;

            scriptProcessor.Setup();
        }

        private void OnDestroy()
        {
            if (scriptProcessor != null)
            {

                Destroy(scriptProcessor);
                scriptProcessor = null;
            }
        }
    }
}
