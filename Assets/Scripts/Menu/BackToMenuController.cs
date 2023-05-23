using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.UI;

namespace Assets.Scripts.Menu
{
    class BackToMenuController:MonoBehaviour
    {
        [SerializeField] StateChanger visibleManager;
        [SerializeField] int menuSceneIndex;


        public void ChangeState()
        {
            visibleManager.ChangeState();
        }
        public void Open()
        {
            visibleManager.State = State.Changed;
        }
        public void Close()
        {
            visibleManager.State = State.Default;
        }
        public void BackToMenu()
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(menuSceneIndex);
        }
    }
}
