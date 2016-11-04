using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Character_Classes.Heroes
{
    public class Knight : AllyEntity
    {
        public Knight() : base() { }
        public Knight(string name) : base()
        {
            Name = name;
            Damage = rnd.Next(4, 7);
            Armor = ARMOR.Heavy;
            Gold = 0;
            Health = 100;
            HeroClass = ENTITY_HERO_CLASS_ALLY.Knight;
            MoveFight = false;
        }

        public override int Hit(out string hit)
        {
            int luck = rnd.Next(100);
            if (luck > 75) { hit = "Cavalry Hit"; return Damage * 2; }
            { hit = "Hit"; return Damage; }
        }
    }
}
