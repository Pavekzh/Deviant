using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Arena
{
    public class EnemyMeleeAttack : MonoBehaviour
    {

        [SerializeField] private float attackRange;
        [SerializeField] private float timeCooldown = 0.1f;
        [SerializeField] private LayerMask obstacleLayerMask;
        [SerializeField] private MeleeWeapon weapon;
        private GameObject player;


        private void Start()
        {
            player = Player.Player.Instance.gameObject;
            StartCoroutine(EnemyAttack());
        }

        IEnumerator EnemyAttack()
        {
            while (true)
            {
                float DistanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

                if (DistanceToPlayer < attackRange)
                {
                    Ray RayToPlayer = new Ray(transform.position, player.transform.position - transform.position);
                    if (!Physics.Raycast(RayToPlayer, DistanceToPlayer, obstacleLayerMask))
                        Attack();
                }
                yield return new WaitForSeconds(timeCooldown);
            }
        }

        private void Attack()
        {
            weapon.Attack();
        }

        public void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }

    }

}
