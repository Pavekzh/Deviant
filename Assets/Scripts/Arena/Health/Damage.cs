using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Arena
{
    public class Damage
    {
        public List<DamagePart> Parts { get; private set; }
        public float AllDamage
        {
            get
            {
                float allDamage = 0;
                foreach(DamagePart part in Parts)
                {
                    allDamage += part.Points;
                    
                }
                return allDamage;
            }
        }
    }
}
