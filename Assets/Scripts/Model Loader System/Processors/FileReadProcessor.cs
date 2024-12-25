using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace ModelLoaderSystem
{
    [CreateAssetMenu(menuName = "Object Loader/Readers/File")]
    public class FileReadProcessor : ReadContentProcessor
    {
        public string fileName;

        public override string GetData(string category,string label)
        {
            return SafeReadAllText(category,label,fileName);
        }


        private string SafeReadAllText(string category,string label, string fileName)
        {
            string fpath = Path.Combine(Application.persistentDataPath, category, label, fileName);
            if (!File.Exists(fpath))
                return null;

            return File.ReadAllText(fpath);
        }
    }
}
