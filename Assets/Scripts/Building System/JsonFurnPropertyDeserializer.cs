using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;


namespace BuildingSystem
{
    [CreateAssetMenu(menuName ="Building System/Furn Property Deserializers/Json")]
    public class JsonFurnPropertyDeserializer : FurnPropertyDeserializer
    {
        public override List<FurnitureComponentData> Deserialize(string content,Dictionary<string,System.Type> buildersTypes)
        {
            List<FurnitureComponentData> list = new List<FurnitureComponentData>();
            JArray arr = JArray.Parse(content);

            for (int i = 0; i < arr.Count; i++)
            {
                list.Add(DeserializeComponent(arr[i].ToObject<JObject>(),buildersTypes));
            }

            return list;
        }

        private FurnitureComponentData DeserializeComponent(JObject element, Dictionary<string, System.Type> buildersTypes)
        {
            FurnitureComponentData fcd = new FurnitureComponentData();

            string _type = element.GetValue("type").ToObject<string>();
            fcd.componentType = buildersTypes[_type];

            JObject propertiesJSON = element.GetValue("properties").ToObject<JObject>();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (JProperty p in propertiesJSON.Properties())
            {
                dictionary.Add(p.Name, DeserializePart(p.Value));
            }

            fcd.properties = dictionary;

            return fcd;
        }

        private object DeserializePart(JToken tkn)
        {
            if (tkn.Type == JTokenType.Array)
            {
                JArray jArr = (JArray)tkn;
                object[] arr = new object[jArr.Count];
                for (int i = 0;i<jArr.Count;i++)
                {
                    arr[i] = DeserializePart(jArr[i]);
                }
                return arr;
            } else if (tkn.Type == JTokenType.Object)
            {
                JObject jObj = (JObject)tkn;
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                foreach (JProperty p in jObj.Properties())
                {
                    dictionary.Add(p.Name,DeserializePart(p.Value));
                }
                return dictionary;
            } else
            {
                return tkn.ToObject<object>();
            }
        }
    }
}
