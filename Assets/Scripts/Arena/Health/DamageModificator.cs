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
            for(int i = 0; i < damage.DamageParts.Count; i++)
            {
                DamagePart part = damage.DamageParts[i];

                foreach (DamageModifacatorPart mPart in Parts)
                {
                    mPart.Modificate(ref part);
                }

                damage.DamageParts[i] = part;
            }
        }

    }
}
