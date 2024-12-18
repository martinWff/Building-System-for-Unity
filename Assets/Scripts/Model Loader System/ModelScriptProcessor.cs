using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModelLoaderSystem
{
    public abstract class ModelScriptProcessor : ScriptableObject
    {
        protected string scriptText;

        internal void _Init(string content)
        {
            scriptText = content;
            Init();
        }
        protected abstract void Init();
        public abstract void Setup();

        public abstract void Tick();
    }
}
