using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Arena;
using Arena;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private UI.Joystick joystick;
    [SerializeField] private LayerMask shootableLayerMask;
    [SerializeField] private ShootingModule shootingModule;
    [SerializeField] private float additionalAngle;

    private bool isShooting = false;
    private void Awake()
    {
        joystick.InputReadingStoped += StopShooting;
        joystick.InputBinding.ValueChanged += JoystickInputChanged;
    }

    private void Update()
    {
        if(joystick.IsTouched)
            shootingModule.Target = FindTarget(transform.position, joystick.JoystickDirection * -1, shootableLayerMask);
    }

    private void StopShooting()
    {
        if (isShooting)
        {
            isShooting = false;
            shootingModule.StopShooting();
        }
    }

    private void StartShooting()
    {
        if (!isShooting)
        {
            isShooting = true;        
            shootingModule.StartShooting();
        }       
    }

    private void JoystickInputChanged(Vector3 value, object source)
    {
        if (!health.Alive)
            return;

        value *= -1;
        if (value != Vector3.zero)
        {
            transform.rotation = Quaternion.Euler(Quaternion.LookRotation(value).eulerAngles+new Vector3(0,additionalAngle,0));
        }
        
       
        StartShooting();
    }

    private static Vector3 FindTarget(Vector3 position,Vector3 direction,LayerMask shootable)
    {
        Ray ray = new Ray(position, direction);
        if(Physics.Raycast(ray,out RaycastHit hit, float.MaxValue, shootable))
        {
            return hit.point;
        }
        return position;
    }
}
