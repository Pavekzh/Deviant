using UnityEngine;
using System.Collections;

namespace Arena
{
    public class EnemyShooting:MonoBehaviour
    {
        [SerializeField] private ShootingModule shootingModule;
        [SerializeField] private float responseTime = 0.1f;
        [SerializeField] private float range = 6;
        [SerializeField] private Vector3 weaponOffset;
        [SerializeField] LayerMask obstaclesLayerMask;

        bool isShooting = false;
        Vector3 weaponPosition { get => transform.position + weaponOffset; }

        private void Start()
        {
            StartCoroutine(CheckTarget());
        }

        IEnumerator CheckTarget()
        {
            while (true)
            {                
                yield return new WaitForSeconds(responseTime);
                Vector3 target = Player.Player.Instance.transform.position;
                float distance = Vector3.Distance(target, weaponPosition);
                if (distance < range)
                {
                    Ray rayToDestination = new Ray(weaponPosition, target - weaponPosition);
                    if (!Physics.Raycast(rayToDestination, distance, obstaclesLayerMask.value))
                    {
                        shootingModule.Target = target;
                        if (!isShooting)
                        {
                            isShooting = true;
                            shootingModule.StartShooting();
                        }
                        continue;
                    }


                }
                if (isShooting)
                {

                    shootingModule.StopShooting();
                    isShooting = false;
                }

            }
        }
    }
}
