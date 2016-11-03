using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Enemy_Classes.Minions
{
    public class Golem : EnemyEntity
    {

        public Golem() : base()
        {
            Armor = ARMOR.Heavy;
            Health = 50;
            Damage = rnd.Next(3, 5);
            MinionClass = ENTITY_MINION_CLASS_ENEMY.Golem;
            MoveFight = true;
        }
        public override int Hit(out string hit)
        {
            return base.Hit(out hit);
        }
    }
}
