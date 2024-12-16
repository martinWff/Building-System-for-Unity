using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingSystem
{
    public class LightningFurnitureComponentBuilder : FurnitureComponentBuilder
    {
        private LightType lightType;
        private float spotAngle;
        private float intensity;
        private float range;
        private Color color;

        public override void Load(Dictionary<string, object> properties)
        {
            object v;
            if (properties.TryGetValue("type",out v))
            {
                SetLightType((LightType)System.Enum.Parse(typeof(LightType), (string)v,true));
            }
            if (properties.TryGetValue("spotAngle", out v))
            {
                SetSpotAngle((float)v);
            }
            if (properties.TryGetValue("intensity", out v))
            {
                SetIntensity((float)v);
            }
            if (properties.TryGetValue("range", out v))
            {
                SetRange((float)v);
            }
            if (properties.TryGetValue("color", out v))
            {
                object[] arr = (object[])v;
                SetColor(new Color((float)(double)arr[0], (float)(double)arr[1], (float)(double)arr[2]));
            }
        }

        public void SetLightType(LightType tp)
        {
            lightType = tp;
        }

        public void SetSpotAngle(float v)
        {
            spotAngle = v;
        }

        public void SetIntensity(float v)
        {
            intensity = v;
        }

        public void SetRange(float v)
        {
            range = v;
        }

        public void SetColor(Color c)
        {
            color = c;
        }

        public override void Build(GameObject furniture)
        {
            Light l = furniture.AddComponent<Light>();
            l.type = lightType;
            l.spotAngle = spotAngle;
            l.intensity = intensity;
            l.range = range;
            l.color = color;
        }
    }
}
