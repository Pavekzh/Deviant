using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Arena
{
    public class PlayerDeathHandler : DeathHandler
    {
        public override void HandleDeath()
        {
            Debug.Log("Лох попущенный проебал в своей игре");
        }
    }
}