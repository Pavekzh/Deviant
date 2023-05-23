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

        public System.Action WaveStarted;
        public System.Action<int> ChangedEnemiesCount;

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

            WaveStarted?.Invoke();
            ChangedEnemiesCount?.Invoke(waves[waveIndex].Enemies.Length);
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

                WaveStarted.Invoke();
                ChangedEnemiesCount?.Invoke(waves[waveIndex].Enemies.Length);
            }
            else
                Win();
        }

        public void EnemyDead()
        {
            amountKilledEnemies++;
            if (!waves[waveIndex].IsWaveAlive(amountKilledEnemies))
                StartCoroutine(PauseBeforeWave(timeDelay));

            ChangedEnemiesCount?.Invoke(waves[waveIndex].Enemies.Length - amountKilledEnemies);
        }

        IEnumerator PauseBeforeWave(float timeDelay)
        {
            yield return new WaitForSeconds(timeDelay);
            StartNewWave();
        }
    }
}
