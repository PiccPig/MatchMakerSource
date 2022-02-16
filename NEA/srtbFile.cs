using System;
using System.Collections.Generic;
using System.Text;

namespace NEA
{
    class srtbFile
    {
        public unityObjectValuesContainer unityObjectValuesContainer { get; set; }
        public largeStringValuesContainer largeStringValuesContainer { get; set; }
        public int clipInfoCount { get; set; }
    }

    class unityObjectValuesContainer
    {
        public values[] values { get; set; }
    }

    class values
    {
        public string key { get; set; }
        public string jsonKey { get; set; }
        public string fullType { get; set; }
    }

    class largeStringValuesContainer
    {
        public values2[] values { get; set; }
    }

    class values2
    {
        public string key { get; set; }
        public string val { get; set; }
        public int loadedGenerationId { get; set; }
    }
}
