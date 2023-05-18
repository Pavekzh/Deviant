using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Arena
{
    [CreateAssetMenu(fileName = "Weakness", menuName = "ScriptableObject/Health/WeaknessPart")]
    public class Weakness :  DamageModifacatorPart
    {
        [SerializeField] float points;
        [SerializeField] string damageType;
        public float Points { get => points; }
        public override string DamageType { get => damageType; }

        public override void Modificate(DamagePart damage)
        {
            if (this.DamageType != damage.Type)
                return;
            
          damage.Points = damage.Points + (damage.Points * (this.Points / 100));
        }
    }
}
