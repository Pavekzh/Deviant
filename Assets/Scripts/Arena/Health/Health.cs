using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.UI;
using System;

namespace Assets.Scripts.Arena
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private FillingBar healthBar;
        [SerializeField] private float maxHP;
        [SerializeField] private float hp;
        [SerializeField] List<DamageModificator> modificators;


        private DeathHandler deathHandler;

        public event Action TakedDamage;
        public bool Alive { get; private set; } = true;
        public float HP { get => hp; }
        public float MaxHP { get => maxHP; }
        public List<DamageModificator> Modificators { get => modificators; }

        private void Start()
        {
            deathHandler = GetComponent<DeathHandler>();
            if(deathHandler==null)
            {
                Debug.LogError("Health can`t work without DeathHandler component");
            }
        }
        public void TakeDamage(Damage damage)
        {
            if (Alive)
            {
                foreach (DamageModificator modificator in modificators)
                {
                    modificator.Modificate(damage);
                }
                hp = hp - damage.AllDamage;


                if (healthBar != null)
                    healthBar.UpdateFilling(HP / MaxHP);

                TakedDamage?.Invoke();
                CheckDeath(hp);
            }
        }

        private void CheckDeath(float hp)
        {
            if (Mathf.Approximately(hp, 0) || hp < 0)
            {
                Alive = false;
                deathHandler.HandleDeath();
            }
        }
    }
}
