using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Character_Classes
{
    public class Mage : EntityHeroes
    {
        public Mage() : base() { }
        public Mage(string name) : base()
        {
            Name = name;
            Damage = rnd.Next(10, 15);
            Armor = ARMOR.Without;
            Gold = 0;
            Health = 50;
            Class = ENTITY_CLASS.Mage;
        }

        public override int Hit(out string hit)
        {
            int magicLuck = rnd.Next(100);
            if (magicLuck > 66) { hit = "Magic crit"; return Damage * 2; }
            else { hit = "Hit"; return Damage; }
        }
    }
}
