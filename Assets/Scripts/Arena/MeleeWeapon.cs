using System;
using UnityEngine;

namespace Assets.Scripts.Arena
{
    public abstract class MeleeWeapon : MonoBehaviour
    {
        public abstract void Attack();

        public abstract event Action Attacked;
    }
}