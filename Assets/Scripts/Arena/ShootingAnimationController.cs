using Arena;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Arena
{
    public class ShootingAnimationController:MonoBehaviour
    {
        [SerializeField] private ShootingModule shootingModule;
        private Animator bilboAnimator;

        private void Start()
        {
            shootingModule.ShootingPaused += ShootingPaused;
            shootingModule.ShootingStarted += ShootingStarted;
            bilboAnimator= GetComponent<Animator>();
        }

        private void ShootingStarted()
        {
            bilboAnimator.SetBool("Fire", true);
        }

        private void ShootingPaused()
        {
            bilboAnimator.SetBool("Fire", false);
        }
    }
}
