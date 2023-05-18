using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.UI;

namespace Assets.Scripts.Arena
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private FillingBar healthBar;
        [SerializeField] private float maxHP;
        [SerializeField] private float hp;
        [SerializeField] List<DamageModificator> modificators;

        public float HP { get => hp; }
        public float MaxHP { get => maxHP; }
        public List<DamageModificator> Modificators { get => modificators; }

        public void TakeDamage(Damage damage)
        {
            foreach (DamageModificator modificator in modificators)
            {
                modificator.Modificate(damage);
            }
            hp = hp - damage.AllDamage;

            if (healthBar != null)
                healthBar.UpdateFilling(HP / MaxHP);

            CheckDeath(hp);
        }

        private void CheckDeath(float hp)
        {
            if (Mathf.Approximately(hp, 0) || hp < 0)
            {
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}