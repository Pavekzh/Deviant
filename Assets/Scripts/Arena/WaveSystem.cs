using Mono.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using BasicTools;
using UnityEngine;

namespace Arena
{
    public class WaveSystem : Singleton<WaveSystem>
    {   
        [SerializeField] private float timeDelay = 5f;
        [SerializeField] private WaveData[] waves;
        [SerializeField] private SpawnSettings PositionSpawners;
        [SerializeField] private Assets.Scripts.Menu.FinishGamePanelController finishGamePanel;

        private int waveIndex;
        private int amountKilledEnemies;

        private WaveFactory waveFactory;
        private EnemyFactory enemyFactory;
        private WaveData data;

        private void Awake()
        {
            enemyFactory = new EnemyFactory();
            waveFactory = new WaveFactory(enemyFactory);
        }

        private void Start()
        {
            amountKilledEnemies = 0;
            waveIndex = 0;
            data = waves[0];
            waveFactory.CreateWave(data,PositionSpawners);
        }

        private void Win()
        {
            finishGamePanel.OpenWin();
        }
        
        public void StartNewWave()
        {
            if (waveIndex < waves.Length - 1)
            {
                amountKilledEnemies = 0;
                waveIndex++;
                data = waves[waveIndex];
                waveFactory.CreateWave(data, PositionSpawners);
            }
            else
                Win();
        }

        public void EnemyDead()
        {
            amountKilledEnemies++;
            if (!waves[waveIndex].IsWaveAlive(amountKilledEnemies))
                StartCoroutine(PauseBeforeWave(timeDelay));
        }

        IEnumerator PauseBeforeWave(float timeDelay)
        {
            yield return new WaitForSeconds(timeDelay);
            StartNewWave();
        }
    }
}
