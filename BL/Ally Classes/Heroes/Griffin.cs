using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Character_Classes
{
    public class Griffin : Entity
    {
        public Griffin() : base() { }
        public Griffin(string name) : base()
        {
            Name = name;
            Damage = rnd.Next(10, 15);
            Armor = ARMOR.Hero;
            Gold = 0;
            Health = 50;
            HeroClass = ENTITY_HERO_CLASS.Griffin;
        }

        public override int Hit(out string hit)
        {
            int luck = rnd.Next(100);
            if (luck > 50) { hit = "Critical hit"; return Damage * 2; }
            else { hit = "Hit"; return Damage; }
        }
    }
}
