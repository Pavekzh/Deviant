using System.Collections;
using UnityEngine;
using Assets.Scripts.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menu
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private StateChanger creditsVisibleManager;
        [SerializeField] private int arenaSceneIndex;

        public void Play()
        {
            SceneManager.LoadSceneAsync(arenaSceneIndex);
        }

        public void Credits()
        {
            creditsVisibleManager.State = State.Changed;
        }

        public void CloseCredits()
        {
            creditsVisibleManager.State = State.Default;
        }

        public void Quit()
        {
            Application.Quit();
        }


    }
}