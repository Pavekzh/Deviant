using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets.Scripts.Arena
{
   
    public enum ModificatorType
    {
        Absolute,
        Percent
    }
    [CreateAssetMenu(fileName = "Armour", menuName = "ScriptableObject/Health/ArmourPart")]
    class Armour :  DamageModifacatorPart
    {
        [SerializeField] float points;
        [SerializeField] string damageType;
        [SerializeField] ModificatorType modificatorType;
        public override string DamageType { get => damageType; }
        public float Points { get => points; }
        public ModificatorType ModificatorType { get => modificatorType; }

        public override void Modificate(ref DamagePart damage)
        {
            if(this.DamageType != damage.Type)
                return;
           
            if(modificatorType == ModificatorType.Absolute)
            {
                damage.Points = damage.Points - this.Points;
            }
            else if (modificatorType == ModificatorType.Percent)
            {
                damage.Points = damage.Points - (damage.Points * (this.Points / 100));
            }
        }
    }
}
