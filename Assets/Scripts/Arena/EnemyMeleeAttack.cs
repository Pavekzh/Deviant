using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{

    [SerializeField] private float AttackRange;
    [SerializeField] private int Damage;
    [SerializeField] private float TimeCoolDawn=0.1f;
    [SerializeField] private LayerMask ObstacleLayerMask;
    private GameObject Player;

    void Awake()
    {
       Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        StartCoroutine(EnemyAttack());
    }
    IEnumerator EnemyAttack()
    {
        while (true)
        {
            float DistanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);

            if (DistanceToPlayer < AttackRange)
            {
                Ray RayToPlayer = new Ray(transform.position, Player.transform.position - transform.position);
                if (!Physics.Raycast(RayToPlayer, DistanceToPlayer, ObstacleLayerMask))
                    Attack();
            }
            yield return new WaitForSeconds(TimeCoolDawn);
        }
    }
    private void Attack()
    {
        Debug.Log("attack:" + Damage);
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }

}
