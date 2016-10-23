using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Character_Classes
{
    public class Mage : Entity
    {
        public Mage() : base() { }
        public Mage(string name) : base()
        {
            Name = name;
            Damage = rnd.Next(10, 15);
            Armor = ARMOR.Without;
            Health = 50;
        }

        public override int Hit(out string hit)
        {
            int magicLuck = rnd.Next(100);
            if (magicLuck > 66) { hit = "Magic crit"; return Damage * 2; }
            else { hit = "Hit"; return Damage; }
        }
    }
}
