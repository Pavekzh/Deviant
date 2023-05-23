using System;
using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts.Arena
{
    class PovitryanaTryvoga:MonoBehaviour
    {
        [SerializeField] Light light;

        Color redColor;
        Sequence animation;

        private void OnDestroy()
        {
            animation.Kill();
        }

        private void Start()
        {
            redColor = light.color;

            animation = DOTween.Sequence()
                .Append(light.DOColor(Color.white, 1).SetEase(Ease.InOutCubic))
                .Append(light.DOColor(redColor, 1).SetEase(Ease.InOutCubic))
                .SetLoops(-1);
        }
    }
}
