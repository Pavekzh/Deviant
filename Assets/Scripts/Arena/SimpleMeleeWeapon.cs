using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

namespace Assets.Scripts.Arena
{
    class SimpleMeleeWeapon:MeleeWeapon
    {
        [SerializeField] float attackTime = 1f;

        private new Collider collider;

        public override event Action Attacked;

        private Collider Collider
        {
            get
            {
                if (collider == null)
                    collider = gameObject.GetComponent<Collider>();

                return collider;
            }
        }

        private void Awake()
        {
            Collider.enabled = false;
        }

        public override void Attack()
        {
            Attacked?.Invoke();
            Collider.enabled = true;
            StartCoroutine(DisableTimer(attackTime));

        }

        private IEnumerator DisableTimer(float time)
        {
            yield return new WaitForSeconds(time);
            Collider.enabled = false;
        }
    }
}
