using System.Collections;
using UnityEngine;

namespace Arena
{
    public abstract class ProjectileController : MonoBehaviour
    {
        public virtual Vector3 Target { get; set; }

        public abstract void Shoot();
    }
}