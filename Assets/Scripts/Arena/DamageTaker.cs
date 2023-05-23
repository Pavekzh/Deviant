using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Arena
{
    class DamageTaker:MonoBehaviour
    {
        [SerializeField] LayerMask damagersLayerMask;

        private Health health;

        private Health Health
        {
            get
            {
                if (health == null)
                    health = GetComponent<Health>();

                return health;
            }

        }

        private void TakeDamage(GameObject weapon)
        {
            Damager damager = weapon.GetComponent<Damager>();

            if (damager == null)
                return;

            Health.TakeDamage(damager.Damage.Clone() as Damage);
        }

        private void OnCollisionEnter(Collision collision)
        {
            TakeDamage(collision.gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            TakeDamage(other.gameObject);
        }
    }
}
