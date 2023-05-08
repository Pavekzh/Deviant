using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena
{
    public class WaveFactory : MonoBehaviour
    {
        private EnemyFactory enemy;
        public WaveFactory(EnemyFactory enemy)
        {
            this.enemy = enemy;
        }

        public void CreateWave(WaveData data,SpawnSettings position)
        {
            foreach (EnemySettings enemyToSpawn in data.Enemies)
            {
                enemy.CreateEnemy(enemyToSpawn.Enemy,position.RandomSpawner());
            }
        }
    }
}
