using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena
{
    public class EnemyFactory 
    {
        public void CreateEnemy(GameObject enemy,Vector3 position)
        {
            GameObject.Instantiate(enemy, position, Quaternion.identity);
        }
    }
}
