using System;
using UnityEngine;

namespace Arena
{
    public abstract class ShootingModule:MonoBehaviour
    {
        public virtual Vector3 Target { get; set; }

        public abstract void StartShooting();

        public abstract void StopShooting();

        public abstract event Action ShootingStarted;
        public abstract event Action ShootingPaused;
    }
}
