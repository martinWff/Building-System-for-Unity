using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace ModelLoaderSystem
{
    [CreateAssetMenu(menuName = "Object Loader/Content Loaders/Model (File)")]
    public class ModelLoaderProcessor : ObjectContentProcessor
    {
        public string rootFolder;
        public string modelName = "Model.gltf";
        public string protocol = "file://";

        public override ObjectBuildingInstruction Process(ModelLoaderManager loader, string label)
        {
            return new ModelLoadingInstruction(GetUrl(label));
        }

        public virtual string GetUrl(string label)
        {
            return protocol + Path.Combine(Application.persistentDataPath, rootFolder,label, modelName);
        }


        public class ModelLoadingInstruction : ObjectBuildingInstruction
        {
            public string url;

            public ModelLoadingInstruction(string url)
            {
                this.url = url;
            }

            public override void Step(GameObject obj)
            {
                GLTFast.GltfAsset asset = obj.GetComponent<GLTFast.GltfAsset>();
                asset.Url = url;
            }
        }
    }
}
