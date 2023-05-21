using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Arena
{
    public class PlayerDeathHandler : DeathHandler
    {
        public override void HandleDeath()
        {
            StartCoroutine(WaitRestart());
            //SceneManager.LoadScene(0);
        }
        IEnumerator WaitRestart() 
        {
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(0);
        }
    }
}