using System;
using System.Collections;
using UnityEngine;
using Assets.Scripts.UI;
using TMPro;
using Assets.Scripts.Arena;


namespace Assets.Scripts.Menu
{
    class FinishGamePanelController : MonoBehaviour
    {
        [SerializeField] StateChanger genericVisibleManager;
        [SerializeField] StateChanger looseVisibleManager;
        [SerializeField] StateChanger winVisibleManager;
        [SerializeField] int menuSceneIndex;
        [SerializeField] int arenaSceneIndex;
        [SerializeField] TMP_Text accuracy;

        private void DisplayAccuracy()
        {
            accuracy.text += AccuracyCalculator.Instance.Accuracy +"%";
        }

        public void OpenWin()
        {
            genericVisibleManager.State = State.Changed;
            winVisibleManager.State = State.Changed;
            DisplayAccuracy();
        }

        public void OpenLoose()
        {
            genericVisibleManager.State = State.Changed;
            looseVisibleManager.State = State.Changed;
            DisplayAccuracy();
        }

        public void LoadMenu()
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(menuSceneIndex);
        }

        public void Restart()
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(arenaSceneIndex);
        }
    }
}
