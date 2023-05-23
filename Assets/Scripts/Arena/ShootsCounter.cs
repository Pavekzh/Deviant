using System.Collections;
using UnityEngine;
using Arena;

namespace Assets.Scripts.Arena
{
    public class ShootsCounter : MonoBehaviour
    {
        private void Awake()
        {
            AccuracyCalculator.Instance.AddShoot();
        }

    }
}