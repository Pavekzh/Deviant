using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Arena
{
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] DestinationProvider destinationProvider;
        [SerializeField] NavMeshAgent navAgent;
        [SerializeField] float responseTime = 0.1f;

        void Start()
        {
            StartCoroutine(FindDestination());
        }


        private IEnumerator FindDestination()
        {
            while (true)
            {
                Vector3 destination;
                if (destinationProvider.GetDestination(out destination))
                {
                    navAgent.isStopped = false;
                    navAgent.SetDestination(destination);
                }
                else
                {
                    navAgent.isStopped = true;
                }
                yield return new WaitForSeconds(responseTime);
            }

        }
    }

}
