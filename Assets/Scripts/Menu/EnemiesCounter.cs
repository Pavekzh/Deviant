using System.Collections;
using UnityEngine;
using TMPro;
using Arena;

namespace Assets.Scripts.Menu
{
    public class EnemiesCounter : MonoBehaviour
    {
        [SerializeField] TMP_Text text;

        private void Awake()
        {
            WaveSystem.Instance.ChangedEnemiesCount += UpdateCounter;
        }

        private void UpdateCounter(int count)
        {
            text.text = count.ToString();
        }
    }
}