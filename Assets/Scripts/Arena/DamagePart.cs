using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Arena
{
    [CreateAssetMenu(fileName ="DamagePart",menuName ="ScriptableObjects/Arena/DamagePart")]
    public class DamagePart:ScriptableObject
    {
        
        [SerializeField] float points;
        [SerializeField] string type;

        public float Points { get => points; }
        public string Type { get => type; }

    }
}
