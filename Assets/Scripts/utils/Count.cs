using System;
using System.Collections;
using UnityEngine;

namespace utils
{
    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count(int min, int max)
        {
            this.minimum = min;
            this.maximum = max;
        }
    }
}
