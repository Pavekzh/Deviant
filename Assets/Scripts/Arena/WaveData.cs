using Arena;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Wave", menuName = "ScriptableObject/Waves/WaveData")]
public class WaveData : ScriptableObject
{
    [SerializeField] private EnemySettings[] enemies;
    public EnemySettings[] Enemies { get => enemies; }

    public bool IsWaveAlive(int killedEnemies)
    {
        if (killedEnemies < enemies.Length)
            return true;
        else return false;
    }
}
