using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace ModelLoaderSystem
{
    [CreateAssetMenu(menuName = "Object Loader/Readers/File")]
    public class FileReadProcessor : ReadContentProcessor
    {
        public string rootFolder;
        public string fileName;

        public override string GetData(string label)
        {
            return SafeReadAllText(label,fileName);
        }


        private string SafeReadAllText(string label, string fileName)
        {
            string fpath = Path.Combine(Application.persistentDataPath, rootFolder, label, fileName);
            if (!File.Exists(fpath))
                return null;

            return File.ReadAllText(fpath);
        }
    }
}
