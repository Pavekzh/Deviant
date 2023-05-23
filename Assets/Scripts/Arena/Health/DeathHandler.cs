using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace Assets.Scripts.Arena
{
    public abstract class DeathHandler : MonoBehaviour
    {
        public abstract void HandleDeath();

        public System.Action Died;
      
    }
}