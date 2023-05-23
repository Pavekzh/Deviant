using System.Collections;
using UnityEngine;

namespace Arena
{
    [RequireComponent(typeof(Rigidbody))]
    public class StraightTrajectoryProjectile : ProjectileController
    {
        [SerializeField] private float speed;
        [SerializeField] private bool useTrigger = false;

        protected new Rigidbody rigidbody;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        public override void Shoot()
        {
            rigidbody.velocity = (Target - transform.position).normalized * speed;
        }

        private void OnCollisionEnter(Collision collision)
        {
            GameObject.Destroy(gameObject);
        }

        public void OnTriggerEnter(Collider other)
        {
            if(useTrigger)
                GameObject.Destroy(gameObject);
        }
    }
}