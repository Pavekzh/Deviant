using Arena;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Arena.Animators
{
    public class DeathAnimator : MonoBehaviour
    {
        [SerializeField] private DeathHandler death;
        [SerializeField] private Health health;

        private Animator animator;

        private void Start()
        {
            health.TakedDamage += TakedDamage;
            death.Died += Died;
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