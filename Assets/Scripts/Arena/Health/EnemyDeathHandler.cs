using Arena;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Arena
{
    public class EnemyDeathHandler : DeathHandler
    {

        public override void HandleDeath()
        {
            Died?.Invoke();
            WaveSystem.Instance.EnemyDead();
            Destroy(gameObject);
            //StartCoroutine(DelayDeath());
        }
        IEnumerator DelayDeath()
        {
            yield return new WaitForSeconds(3);
            Destroy(gameObject);
        }
    }
}