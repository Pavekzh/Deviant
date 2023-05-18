using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class GameObjectUI:MonoBehaviour
    {
        private new Camera camera;

        private void Start()
        {
            camera = Camera.main;
        }

        private void Update()
        {
            Quaternion lookToCam = Quaternion.LookRotation(transform.position - camera.transform.position);
            transform.rotation = Quaternion.Euler(new Vector3(lookToCam.eulerAngles.x, 0, lookToCam.eulerAngles.z));
        }
    }
}
