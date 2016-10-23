using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Enemy_Classes
{
    public class Spider : EntityEnemies
    {
        public Spider() : base()
        {
            Armor = ARMOR.Without;
            Health = 20;
            Damage = rnd.Next(5, 8);
        }
        public override int Hit(out string hit)
        {
            int luck = rnd.Next(100);
            if (luck > 50) { hit = "Poison hit"; return Damage * 2; }
            else return base.Hit(out hit);
        }
    }
}
