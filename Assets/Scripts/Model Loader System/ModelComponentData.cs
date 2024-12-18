using System.Collections.Generic;
using System;

namespace ModelLoaderSystem
{
    public class ModelComponentData
    {
        public string componentType;
        public Dictionary<string, object> properties;
    }

    public class ModelComponentBuildData
    {
        public Type componentType;
        public Dictionary<string, object> properties;
    }
}
