using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arena;
public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private UI.Joystick joystick;
    [SerializeField] private LayerMask shootableLayerMask;
    [SerializeField] private ShootingModule shootingModule;
    [SerializeField] private float additionalAngle;
    private void Awake()
    {
        joystick.InputReadingStoped += StopShooting;
        joystick.InputReadingStarted += StartShooting;
        joystick.InputBinding.ValueChanged += JoystickInputChanged;
    }

    private void StopShooting()
    {
        shootingModule.StopShooting();
    }

    private void StartShooting()
    {
        shootingModule.StartShooting();
       
    }

    private void JoystickInputChanged(Vector3 value, object source)
    {
        value *= -1;
        if (value != Vector3.zero)
        {
            transform.rotation = Quaternion.Euler(Quaternion.LookRotation(value).eulerAngles+new Vector3(0,additionalAngle,0));
        }
        Ray ray = new Ray(shootingModule.transform.position, value);
        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, shootableLayerMask))
        {
            shootingModule.Target = hit.point;
        }
        
    }
}
