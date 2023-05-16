using System.Collections;
using UnityEngine;
using Assets.Scripts.UI;

namespace Assets.Scripts.Arena
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private FillingBar healthBar;
        [SerializeField] private float MaxHP;
        [SerializeField] private float HP;

        public void TakeDamage(Damage damage)
        {

            HP -= damage.AllDamage;

            if(healthBar != null)
                healthBar.UpdateFilling(HP / MaxHP);
        }
    }
}