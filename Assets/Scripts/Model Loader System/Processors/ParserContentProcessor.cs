using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModelLoaderSystem
{
    public abstract class ParserContentProcessor<T> : ObjectContentProcessor
    {
        public ReadContentProcessor reader;

        public sealed override ObjectBuildingInstruction Process(ModelLoaderManager loader, string category, string label)
        {
            string txt = reader.GetData(category,label);
            if (string.IsNullOrEmpty(txt))
                return null;
            T value = Parse(txt);

            

            return new FormatedObjectInstruction(GetData(value),OnStep);
        }

        public abstract T Parse(string content);

        protected abstract void OnStep(object v,GameObject g);

        protected virtual object GetData(T v)
        {
            return v;
        }


        public class FormatedObjectInstruction : ObjectBuildingInstruction {

            public object value;
            public System.Action<object,GameObject> onStep;

            public FormatedObjectInstruction(object v,System.Action<object,GameObject> fn)
            {
                this.value = v;
                onStep = fn;
            }

            public override void Step(GameObject obj)
            {
                if (onStep != null)
                {
                    onStep(value,obj);
                }
            }
        }
    }
}
