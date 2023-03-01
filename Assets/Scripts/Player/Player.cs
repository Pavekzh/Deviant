using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BasicTools;

namespace Player 
{
    public class Player : Singleton<Player>
    {
        [SerializeField] LayerMask terrainLayerMask;

        private Camera main;

        private void Start()
        {
            main = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Ray mouseRay = main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if(Physics.Raycast(mouseRay,out hitInfo, float.MaxValue, terrainLayerMask.value))
                {
                    transform.position = new Vector3(hitInfo.point.x,hitInfo.point.y+1,hitInfo.point.z);
                }
            }
        }
    }
}


