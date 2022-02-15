using System;
using System.Collections.Generic;
using System.Text;

namespace NEA
{
    class srtbFile
    {
        public unityObjectValuesContainer unityobjectvaluescontainer { get; set; }
        public largeStringValuesContainer largestringvaluescontainer { get; set; }
        public int ClipInfoCount { get; set; }
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
