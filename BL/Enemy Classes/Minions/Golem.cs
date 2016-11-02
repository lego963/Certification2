using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Enemy_Classes
{
    public class Golem : Entity
    {

        public Golem() : base()
        {
            Armor = ARMOR.Heavy;
            Health = 50;
            Damage = rnd.Next(3, 5);
            Type = ENTITY_TYPE.Golem;
        }
        public override int Hit(out string hit)
        {
            return base.Hit(out hit);
        }
    }
}
