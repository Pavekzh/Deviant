using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Arena
{
    [CreateAssetMenu(fileName = "Damage", menuName = "ScriptableObject/Damage/Damage")]
    public class Damage:ScriptableObject,ICloneable
    {
        [SerializeField] List<DamagePart> damageParts;

        public List<DamagePart> DamageParts { get => damageParts; }

        public float AllDamage
        {
            get
            {
                float points = 0;
                foreach(DamagePart part in damageParts)
                {
                    points += part.Points;
                }
                return points;
            }
        }

        public object Clone()
        {
            Damage cloned = (Damage)(this.MemberwiseClone());
            cloned.damageParts = new List<DamagePart>();

            foreach(DamagePart part in this.damageParts)
            {
                cloned.damageParts.Add(part);
            }
            return cloned;
        }
    }
}
