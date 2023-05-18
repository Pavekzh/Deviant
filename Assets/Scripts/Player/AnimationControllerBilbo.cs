using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerBilbo : MonoBehaviour
{
    [SerializeField] private UI.Joystick joystickMove;
    [SerializeField] private UI.Joystick joystickFire;
    private Rigidbody bilboRb;
    private Animator bilboAnimator;
    private bool fire;
    private bool run;
    void Start()
    {
        fire = false;
        run = false;
        bilboAnimator = GetComponent<Animator>();
        bilboRb= GetComponent<Rigidbody>();
    }

    void Update()
    {
        if ((joystickMove.JoystickDirection * -1).normalized.x != 0 || (joystickMove.JoystickDirection * -1).normalized.z != 0)
        {
            run = true;
            bilboAnimator.SetBool("Run", run);
        }
        if ((joystickMove.JoystickDirection * -1).normalized.x == 0 || (joystickMove.JoystickDirection * -1).normalized.z == 0)
        {
            run = false;
            bilboAnimator.SetBool("Run", run);
        }
    }

}
