using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Arena
{
    public abstract class  DamageModifacatorPart : ScriptableObject 
    {
        public abstract string DamageType { get; }
        public abstract void Modificate(ref DamagePart damage);
    }
}
