using Arena;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Arena
{
    public class ShootingAnimator:MonoBehaviour
    {
        [SerializeField] private ShootingModule shootingModule;

        private Animator animator;

        private void Start()
        {
            shootingModule.ShootingPaused += ShootingPaused;
            shootingModule.ShootingStarted += ShootingStarted;
            animator= GetComponent<Animator>();
        }

        private void ShootingStarted()
        {
            animator.SetBool("Fire", true);
        }

        private void ShootingPaused()
        {
            animator.SetBool("Fire", false);
        }
    }
}
