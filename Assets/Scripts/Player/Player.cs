using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BasicTools;

namespace Player 
{
    public class Player : Singleton<Player>
    {
        [SerializeField] GameObject aim;
        [SerializeField] Arena.ShootingModule shootingModule;
        [SerializeField] LayerMask terrainLayerMask;


        private Camera camera;

        private void Start()
        {
            camera = Camera.main;

        }

        private void Update()
        {            
            if (Input.GetMouseButton(0))
            {
                Plane playerPlane = new Plane(Vector3.up, transform.position);
                Ray rayFromCamera = camera.ScreenPointToRay(Input.mousePosition);
                float distance;
                if(playerPlane.Raycast(rayFromCamera, out distance))
                {
                    Vector3 mouseOnPlane = rayFromCamera.GetPoint(distance);
                    aim.transform.position = mouseOnPlane;
                    transform.LookAt(mouseOnPlane);                
                    shootingModule.Target = aim.transform.position;
                }

            }

            if (Input.GetMouseButtonDown(0))
                shootingModule.StartShooting();

            if (Input.GetMouseButtonUp(0))
                shootingModule.StopShooting();



            if (Input.GetMouseButton(1))
            {
                Ray mouseRay = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(mouseRay, out hitInfo, float.MaxValue, terrainLayerMask.value))
                {
                    transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y + 1, hitInfo.point.z);
                }
            }
        }
    }
}


