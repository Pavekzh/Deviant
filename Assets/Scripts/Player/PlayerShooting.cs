using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arena;
public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private UI.Joystick joystick;
    [SerializeField] private LayerMask shootableLayerMask;
    [SerializeField] private ShootingModule shootingModule;
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
            transform.rotation = Quaternion.LookRotation(value);
        }
        Ray ray = new Ray(transform.position, value);
        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, shootableLayerMask))
        {
            shootingModule.Target = hit.point;
        }
        
    }
}
