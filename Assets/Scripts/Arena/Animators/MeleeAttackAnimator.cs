using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Arena.Animators
{
    public class MeleeAttackAnimator : MonoBehaviour
    {
        [SerializeField] private MeleeWeapon meleeWeapon;

        private Animator animator;
        
        private void Start()
        {
           
            animator= GetComponent<Animator>();
            meleeWeapon.Attacked += Attack;
        }
        private void Attack()
        {
            animator.SetTrigger("Attack");
        }
    }
}