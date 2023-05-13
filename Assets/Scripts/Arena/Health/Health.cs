using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Arena
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float hp;
        [SerializeField] List<DamageModificator> modificators;

        public float HP { get => hp; }
        public List<DamageModificator> Modificators { get => modificators; }

        public void TakeDamage(Damage damage)
        {
            foreach(DamageModificator modificator in modificators)
            {
                modificator.Modificate(damage);
            }
            hp = hp - damage.AllDamage;
        }
    }
}
