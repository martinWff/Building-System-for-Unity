using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModelLoaderSystem
{
    public class ModelScriptBehaviour : MonoBehaviour
    {
        [SerializeField] ModelScriptProcessor scriptProcessor;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public ModelScriptProcessor GetProcessor()
        {
            return scriptProcessor;
        }

        public void LoadProcessor(ModelScriptProcessor processor)
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
