using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    [SerializeField] private UI.Joystick joystick;
    [SerializeField] private LayerMask objectSelectionMask;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        

        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, objectSelectionMask))
        {
            Debug.Log(hit.collider.name);
            Debug.Log(hit.point);
        }
        if (joystick.Direction.y != 0 || joystick.Direction.x != 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(joystick.Direction.x, 0, joystick.Direction.y));
        }
    }

}
