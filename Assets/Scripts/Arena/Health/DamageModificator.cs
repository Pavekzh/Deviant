using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Arena
{
    [CreateAssetMenu (fileName = "DamageModificator",menuName = "ScriptableObject/Health/DamageModificator")]
    public class DamageModificator : ScriptableObject
    {
        [SerializeField] List<DamageModifacatorPart> parts;
        public List<DamageModifacatorPart> Parts { get => parts; }
        public void Modificate(Damage damage)
        {
            foreach (DamagePart part in damage.DamageParts)
            {
                foreach (DamageModifacatorPart mPart in Parts)
                {
                    mPart.Modificate(part);
                }
            }

        }

    }
}
