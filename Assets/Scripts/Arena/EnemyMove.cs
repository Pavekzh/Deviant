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
        [SerializeField] float rotationSpeed = 2;

        Vector3 destination;
        bool needMove;

        void Start()
        {
            needMove = destinationProvider.GetDestination(out destination);
            StartCoroutine(FindDestination());
        }


        private void Update()
        {
            needMove = destinationProvider.GetDestination(out destination);
            if (!needMove)
            {
                Vector3 position = new Vector3(transform.position.x, 0, transform.position.z);
                Vector3 target = new Vector3(destination.x, 0, destination.z);

                Quaternion targetRotation = Quaternion.LookRotation(target - position);

                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }
            

        }

        private IEnumerator FindDestination()
        {
            while (true)
            {


                if (needMove)
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
