using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModelLoaderSystem
{
    [CreateAssetMenu(menuName ="Object Loader/Parsers/Properties (JSON)")]
    public class JSONPropertiesParserContentProcessor : PropertiesParserContentProcessor
    {
        public override List<ModelComponentData> Parse(string content)
        {
            List<ModelComponentData> list = new List<ModelComponentData>();
            JArray arr = JArray.Parse(content);

            for (int i = 0; i < arr.Count; i++)
            {
                list.Add(DeserializeComponent(arr[i].ToObject<JObject>()));
            }

            return list;
        }

        private ModelComponentData DeserializeComponent(JObject element)
        {
            ModelComponentData fcd = new ModelComponentData();

            fcd.componentType = element.GetValue("type").ToObject<string>();

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
                for (int i = 0; i < jArr.Count; i++)
                {
                    arr[i] = DeserializePart(jArr[i]);
                }
                return arr;
            }
            else if (tkn.Type == JTokenType.Object)
            {
                JObject jObj = (JObject)tkn;
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                foreach (JProperty p in jObj.Properties())
                {
                    dictionary.Add(p.Name, DeserializePart(p.Value));
                }
                return dictionary;
            }
            else
            {
                return tkn.ToObject<object>();
            }
        }
    }
}
