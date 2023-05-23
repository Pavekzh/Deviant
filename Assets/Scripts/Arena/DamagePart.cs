using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Arena
{

    [Serializable]
    public struct DamagePart
    {
        public float Points;
        public string Type;

        public DamagePart(float Points, string Type)
        {
            this.Points = Points;
            this.Type = Type;
        }
    }
}
