using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Arena
{
    public class HitsCounter : MonoBehaviour
    {
        [SerializeField] Health health;

        private void Awake()
        {
            health.TakedDamage += Hit;
        }

        private void Hit()
        {
            AccuracyCalculator.Instance.AddHit();
        }
    }
}