﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Character_Classes
{
    public class Knight : Entity
    {
        public Knight() : base() { }
        public Knight(string name) : base()
        {
            Name = name;
            Damage = rnd.Next(4, 7);
            Armor = ARMOR.Heavy;
            Health = 100;
        }
    }
}
