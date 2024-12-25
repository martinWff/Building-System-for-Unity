using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModelLoaderSystem
{
    public abstract class ReadContentProcessor : ObjectContentProcessor
    {
        public sealed override ObjectBuildingInstruction Process(ModelLoaderManager loader, string category, string label)
        {
            return new ReadContentObjectInstruction(GetData(category,label));
        }

        public abstract string GetData(string category, string label);


        public class ReadContentObjectInstruction : ObjectBuildingInstruction
        {
            public string content;
            public ReadContentObjectInstruction(string content)
            {
                this.content = content;
            }

            public override void Step(GameObject obj)
            {
                
            }
        }
    }

}
