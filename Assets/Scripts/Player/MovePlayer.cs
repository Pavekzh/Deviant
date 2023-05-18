using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private UI.Joystick joystick;
    [SerializeField] private float speed;
    public float smoothTime = 0.3F;
    private Vector3 CurrentInputVector;
    private Vector3 SmoothInputVelocity;

    private void Awake()
    {
        joystick.InputBinding.ValueChanged += JoystickInputChanged;
    }
    private void Update()
    {

        CurrentInputVector = Vector3.SmoothDamp(CurrentInputVector, joystick.JoystickDirection * -1, ref SmoothInputVelocity, smoothTime);
        transform.Translate(CurrentInputVector * speed * Time.deltaTime, Space.World);
    }

    private void JoystickInputChanged(Vector3 value, object source)
    {
        value *= -1;

        if (value != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(value);
        }

    }
}
