using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{

    [SerializeField] private float attackRange;
    [SerializeField] private int damage;
    [SerializeField] private float timeCooldown=0.1f;
    [SerializeField] private LayerMask obstacleLayerMask;
    private GameObject player;

    void Awake()
    {
        player = Player.Player.Instance.gameObject;
    }

    private void Start()
    {
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
        Debug.Log("attack:" + damage);
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}
