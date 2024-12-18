using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModelLoaderSystem {
    public abstract class PropertiesParserContentProcessor : ParserContentProcessor<List<ModelComponentData>>
    {

        protected sealed override void OnStep(object v, GameObject g)
        {
            List<ObjectComponentBuilder> builders = (List<ObjectComponentBuilder>)v;
            for (int i = 0;i<builders.Count;i++)
            {
                builders[i].Build(g);
            }
        }

        protected override object GetData(List<ModelComponentData> v)
        {
            return InitProperties(v);
        }

        private List<ObjectComponentBuilder> InitProperties(List<ModelComponentData> properties)
        {
            List<ObjectComponentBuilder> list = new List<ObjectComponentBuilder>();
            for (int i = 0; i < properties.Count; i++)
            {
                ObjectComponentBuilder fcb = InitComponentProperties(properties[i]);
                if (fcb != null)
                {
                    list.Add(fcb);
                }
            }

            return list;
        }

        private ObjectComponentBuilder InitComponentProperties(ModelComponentData componentData)
        {
            if (componentData.componentType == null)
                return null;

            if (ModelLoaderManager.builderNames.TryGetValue(componentData.componentType, out System.Type tp))
            {
                if (ModelLoaderManager.builderTypes.TryGetValue(tp, out System.Type ftp))
                {
                    ObjectComponentBuilder fcb = (ObjectComponentBuilder)System.Activator.CreateInstance(ftp);
                    fcb.Load(componentData.properties);

                    return fcb;
                }
            }

            return null;
        }
    }
}
