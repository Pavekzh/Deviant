using System;
using UnityEngine;

namespace Assets.Scripts.Arena
{
    public class Damager:MonoBehaviour
    {
        [SerializeField] Damage damage;

        public Damage Damage { get => damage; }
    }
}
