using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace BuildingSystem
{
    [CreateAssetMenu(menuName = "Building System/Furn Header Deserializers/Json")]
    public class JsonFurnHeaderDeserializer : FurnHeaderDeserializer
    {
        public override FurnitureHeaderData Deserialize(string content)
        {
            return JsonConvert.DeserializeObject<FurnitureHeaderData>(content);
        }
    }
}
