using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModelLoaderSystem
{
    [CreateAssetMenu(menuName = "Object Loader/Content Loaders/Scripts")]
    public class ScriptLoaderProcessor : ObjectContentProcessor
    {
        public ReadContentProcessor reader;
        public ModelScriptProcessor processor;

        public override ObjectBuildingInstruction Process(ModelLoaderManager loader, string label)
        {

            return new ScriptBuildingInstruction(processor,reader.GetData(label));
        }

        public class ScriptBuildingInstruction : ObjectBuildingInstruction
        {
            public ModelScriptProcessor processor;
            public string scriptText;

            public ScriptBuildingInstruction(ModelScriptProcessor proc,string script)
            {
                this.processor = proc;
                this.scriptText = script;
            }

            public override void Step(GameObject obj)
            {
                if (string.IsNullOrEmpty(scriptText))
                    return;

                ModelScriptBehaviour bhv = obj.AddComponent<ModelScriptBehaviour>();
                ModelScriptProcessor proc = Instantiate(processor);
                proc._Init(scriptText);
                bhv.LoadProcessor(proc);
            }
        }
    }
}
