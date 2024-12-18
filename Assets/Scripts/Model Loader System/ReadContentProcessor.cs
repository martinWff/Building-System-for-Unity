using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModelLoaderSystem
{
    public abstract class ReadContentProcessor : ObjectContentProcessor
    {
        public sealed override ObjectBuildingInstruction Process(ModelLoaderManager loader, string label)
        {
            return new ReadContentObjectInstruction(GetData(label));
        }

        public abstract string GetData(string label);


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
