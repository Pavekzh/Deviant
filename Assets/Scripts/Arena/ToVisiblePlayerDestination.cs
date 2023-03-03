using System.Collections;
using UnityEngine;

namespace Arena
{
    public class ToVisiblePlayerDestination : DestinationProvider
    {
        [SerializeField] float minRange = 5;
        [SerializeField] float sightWidth = 0.5f;
        [SerializeField] LayerMask obstaclesLayerMask;

        public override bool GetDestination(out Vector3 destination)
        {
            destination = Player.Player.Instance.transform.position;
            float distance = Vector3.Distance(destination, transform.position);                
            if(distance < minRange)
            {
                Ray rayToDestination = new Ray(transform.position, destination - transform.position);
                if (!Physics.SphereCast(rayToDestination, sightWidth / 2, distance, obstaclesLayerMask.value))
                {
                    return false;
                }
            }
            return true;
        }

        public void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, minRange);
        }
    }
}