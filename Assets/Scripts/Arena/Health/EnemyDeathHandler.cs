using Arena;
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
        }
    }
}