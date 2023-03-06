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
    private void Update()
    {
        if (joystick.Direction.y != 0 || joystick.Direction.x != 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(joystick.Direction.x,0 ,joystick.Direction.y));
        }
        CurrentInputVector = Vector3.SmoothDamp(CurrentInputVector, joystick.Direction, ref SmoothInputVelocity, smoothTime);
        transform.Translate(new Vector3( CurrentInputVector.x,0, CurrentInputVector.y) * speed * Time.deltaTime, Space.World);
    }
}
