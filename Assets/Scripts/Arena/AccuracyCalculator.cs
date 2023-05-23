using System;
using System.Collections.Generic;
using UnityEngine;
using BasicTools;

namespace Assets.Scripts.Arena
{
    class AccuracyCalculator:Singleton<AccuracyCalculator>
    {
        [SerializeField] int shoots;
        [SerializeField] int hits;

        public int Shoots { get => shoots; }
        public int Hits { get => hits; }

        public float Accuracy
        {
            get
            {
                float accuracy = ((float)Hits / Shoots)*100;
                return (float)Math.Round(accuracy, 2);
            }
        }

        public void AddHit()
        {
            hits++;
        }

        public void AddShoot()
        {
            shoots++;
        }

    }
}
