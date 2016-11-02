using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Character_Classes.Minions
{
    public class Dwarf : AllyEntity
    {
        public Dwarf() : base()
        {
            Health = 25;
            Armor = ARMOR.Medium;
            Damage = rnd.Next(2, 4);
            MinionClass = ENTITY_MINION_CLASS.Dwarf;
        }

        public override int Hit(out string hit)
        {
            return base.Hit(out hit);
        }
    }
}
