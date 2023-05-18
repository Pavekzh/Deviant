using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class FillingBar : MonoBehaviour
    {
        [SerializeField] private Image FillingImage;

        public void UpdateFilling(float filling)
        {
            FillingImage.fillAmount = filling;
        }
    }
}