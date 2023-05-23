using System.Collections;
using UnityEngine;
using Assets.Scripts.Menu;

namespace Assets.Scripts.Arena
{
    public class PlayerDeathHandler : DeathHandler
    {
        [SerializeField] FinishGamePanelController finishGamePanel;

        public override void HandleDeath()
        {
            Died?.Invoke();
            finishGamePanel.OpenLoose();
        }

    }
}