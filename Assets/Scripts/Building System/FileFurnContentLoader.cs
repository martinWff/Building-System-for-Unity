using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace BuildingSystem
{
    [CreateAssetMenu(menuName = "Building System/Content Loaders/File Loader")]
    public class FileFurnContentLoader : FurnitureContentLoader
    {
        [SerializeField] string rootFolder = "Furnitures";
        [SerializeField] string modelName = "model.gltf";
        [SerializeField] string scriptName = "script.lua";
        [SerializeField] string propertiesName = "properties.json";
        [SerializeField] string headerName = "header.json";

        public override string GetHeader(string label)
        {
            return File.ReadAllText(Path.Combine(Application.persistentDataPath, rootFolder, label, headerName));
        }

        public override string GetModelUrl(string label)
        {
            return "file://" + Path.Combine(Application.persistentDataPath,rootFolder,label, modelName);
        }

        public override string GetProperties(string label)
        {
            return SafeReadAllText(label, propertiesName);
        }

        public override string GetScript(string label)
        {
            return SafeReadAllText(label, scriptName);
        }

        private string SafeReadAllText(string label,string fileName)
        {
            string fpath = Path.Combine(Application.persistentDataPath, rootFolder, label, fileName);
            if (!File.Exists(fpath))
                return null;

            return File.ReadAllText(fpath);
        }
    }
}
