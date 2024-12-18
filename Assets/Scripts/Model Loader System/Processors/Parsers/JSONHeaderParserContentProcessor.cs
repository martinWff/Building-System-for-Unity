using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace ModelLoaderSystem
{
    [CreateAssetMenu(menuName = "Object Loader/Parsers/Header (JSON)")]
    public class JSONHeaderParserContentProcessor : HeaderParserContentProcessor
    {
        public override ObjectHeaderData Parse(string content)
        {
            return JsonConvert.DeserializeObject<ObjectHeaderData>(content);
        }
    }
}
