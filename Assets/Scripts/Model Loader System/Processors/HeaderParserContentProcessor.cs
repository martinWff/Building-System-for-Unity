using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModelLoaderSystem
{
    public abstract class HeaderParserContentProcessor : ParserContentProcessor<ObjectHeaderData>
    {
        protected override void OnStep(object v, GameObject g)
        {
            ObjectHeaderData d = (ObjectHeaderData)v;
            ModelObjectData f = g.AddComponent<ModelObjectData>();
            f.title = d.title;
            f.description = d.description;
        }
    }
}
