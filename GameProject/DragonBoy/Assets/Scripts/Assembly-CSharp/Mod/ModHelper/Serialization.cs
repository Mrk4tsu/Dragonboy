using System.Collections.Generic;
using UnityEngine;

namespace Mod.ModHelper
{
    [System.Serializable]
    internal class Serialization<T>
    {
        [SerializeField]
        List<T> target;
        public List<T> ToList() { return target; }

        public Serialization(List<T> target)
        {
            this.target = target;
        }
    }
}
