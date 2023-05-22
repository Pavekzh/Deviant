using BasicTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMoveAnimator : MonoBehaviour
{
    [SerializeField] private UI.Joystick joystickMove;
    [SerializeField] private UI.Joystick joystickFire;
    [SerializeField] private float forward = 315;
    [SerializeField] private float backward=135;
    [SerializeField] private float right=45;
    [SerializeField] private float left=225;

    private Animator bilboAnimator;
    private float delta;
    private bool runForfard = false;
    private bool runBackward = false;
    private bool runRight = false;
    private bool runLeft = false;

    void Start()
    {
        bilboAnimator = GetComponent<Animator>();
        delta = 360 - forward;
        forward += delta;
        right += delta;
        backward += delta;
        left += delta;
    }

    void Update()
    {
        Vector3 vectorMove = (joystickMove.JoystickDirection * -1).normalized;
        Vector3 vectorFire = (joystickFire.JoystickDirection * -1).normalized;

        float angle = Vector3.Angle(vectorMove,vectorFire);

        float crossLength = Vector3.Cross(vectorMove, vectorFire).y;

        if (crossLength < 0)
            angle = 360 - angle;

        angle = (angle + delta) % 360;

        if (!Mathf.Approximately(vectorMove.magnitude,0))
        {
            if (angle < right)
            {
                runForfard = true;
                runLeft = false;
                runBackward = false;
                runRight = false;
            }
            else if (angle < backward)
            {
                runForfard = false;
                runLeft = true;
                runBackward = false;
                runRight = false;
            }
            else if (angle < left)
            {
                runForfard = false;
                runLeft = false;
                runBackward = true;
                runRight = false;
            }
            else
            {
                runForfard = false;
                runLeft = false;
                runBackward = false;
                runRight = true;
            }
            bilboAnimator.SetBool("Run", runForfard);
            bilboAnimator.SetBool("RunBack", runBackward);
            bilboAnimator.SetBool("RunLeft", runLeft);
            bilboAnimator.SetBool("RunRight", runRight);

        }
        if (Mathf.Approximately(vectorMove.magnitude, 0))
        {
            bilboAnimator.SetBool("Run", false);
            bilboAnimator.SetBool("RunBack", false);
            bilboAnimator.SetBool("RunLeft", false);
            bilboAnimator.SetBool("RunRight", false);
        }
    }

}
