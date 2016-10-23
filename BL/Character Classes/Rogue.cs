﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Character_Classes
{
    public class Rogue : EntityHeroes
    {
        public Rogue() : base() { }
        public Rogue(string name)
        {
            Name = name;
            Health = 75;
            Armor = ARMOR.Light;
            Gold = 0;
            Damage = rnd.Next(8, 10);
            Class = ENTITY_CLASS.Rogue;
        }

        public override int Hit(out string hit)
        {
            int luck = rnd.Next(100);
            if (luck > 50) { hit = "Critical hit"; return Damage * 2; }
            else { hit = "Hit"; return Damage; }
        }
    }
}
