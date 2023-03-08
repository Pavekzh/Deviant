using System.Collections;
using UnityEngine;

namespace Arena
{
    [RequireComponent(typeof(Rigidbody))]
    public class StraightTrajectoryProjectile : ProjectileController
    {
        [SerializeField] private float speed; 

        protected Rigidbody rigidbody;

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
    }
}