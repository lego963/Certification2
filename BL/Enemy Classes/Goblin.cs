using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Enemy_Classes
{
    public class Goblin : EntityEnemies
    {
        public Goblin() : base()
        {
            Armor = ARMOR.Light;
            Health = 35;
            Damage = rnd.Next(1, 3);
        }
        public override int Hit(out string hit)
        {
            int luck = rnd.Next(100);
            if (luck > 50) { hit = "Critical hit"; return Damage * 2; }
            else return base.Hit(out hit);
        }
    }
}
