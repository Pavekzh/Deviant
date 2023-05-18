using UnityEditor;
using UnityEngine;

namespace Arena
{
    [System.Serializable]
    public class EnemySettings
    {
        [SerializeField] private GameObject enemy;
        public GameObject Enemy { get => enemy; }
    }
}