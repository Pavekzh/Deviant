using System;
using System.Collections;
using UnityEngine;
using Assets.Scripts.UI;
using Arena;

namespace Assets.Scripts.Menu
{
    class WaveWarning:MonoBehaviour
    {
        [SerializeField] StateChanger visibleManager;
        [SerializeField] TMPro.TMP_Text text;
        [SerializeField] float disappearingTime =3;
        [SerializeField] float time = 2;

        float alphaPerSecond;

        private void Awake()
        {
            alphaPerSecond = 1 / disappearingTime;
            WaveSystem.Instance.WaveStarted += NewWaveStarted;
        }

        private void NewWaveStarted()
        {
            visibleManager.State = State.Changed;
            StartCoroutine(Disappearing());
        }

        private IEnumerator Disappearing()
        {
            yield return new WaitForSeconds(time);
            float startTime = Time.realtimeSinceStartup;
            while(Time.realtimeSinceStartup < startTime + disappearingTime)
            {
                text.color = new Color(text.color.r,text.color.g,text.color.b,text.color.a - alphaPerSecond * Time.deltaTime);
                yield return null;
            }
            visibleManager.State = State.Default;
            text.color = new Color(text.color.r, text.color.g, text.color.b, 255);
        }
    }
}
