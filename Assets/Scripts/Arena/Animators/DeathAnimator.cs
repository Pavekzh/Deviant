using Arena;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Arena.Animators
{
    public class DeathAnimator : MonoBehaviour
    {
        [SerializeField] private Health health;

        private Animator animator;

        private void Start()
        {
            health.TakedDamage += TakedDamage;
            health.Died += Died;
            animator = GetComponent<Animator>();
        }

        private void TakedDamage()
        {
            animator.SetTrigger("Hit");
        }

        private void Died()
        {
            animator.SetTrigger("Die");
        }
    }
}