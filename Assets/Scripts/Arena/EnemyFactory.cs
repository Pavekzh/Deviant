using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena
{
    public class EnemyFactory : MonoBehaviour
    {
        public void CreateEnemy(GameObject enemy,Vector3 position)
        {
            Instantiate(enemy, position, Quaternion.identity);
        }
    }
}
