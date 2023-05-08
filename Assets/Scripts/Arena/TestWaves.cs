using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena
{
    public class TestWaves : MonoBehaviour
    {
        private WaveSystem waveSpawner;
        private void Start()
        {
            waveSpawner = GameObject.Find("WaveController").GetComponent<WaveSystem>();
        }

        private void OnDestroy()
        {
            waveSpawner.EnemyIsDead();
        }
    }
}
