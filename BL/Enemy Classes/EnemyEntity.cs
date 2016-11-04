using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Enemy_Classes
{
    public enum ARMOR { Without = 0, Light = 10, Medium = 15, Heavy = 20, Hero = 30, Unknown = -1 };
    public enum ENTITY_MINION_CLASS_ENEMY { Goblin, Spider, Golem, Unknown = -1 };
    public enum ENTITY_HERO_CLASS_ENEMY { Knight, Unknown };

    public abstract class EnemyEntity
    {
        protected Random rnd;

        public bool MoveFight { get; set; }
        public PointF Coords;
        public int LaneMove { get; set; }
        public int Health { get; set; }
        public int Damage { get; protected set; }
        public ARMOR Armor { get; protected set; }
        public virtual ENTITY_MINION_CLASS_ENEMY MinionClass { get; protected set; }
        public virtual ENTITY_HERO_CLASS_ENEMY HeroClass { get; protected set; }

        public EnemyEntity()
        {
            rnd = new Random();
            Health = 0;
            Damage = 0;
            Armor = ARMOR.Unknown;
            MinionClass = ENTITY_MINION_CLASS_ENEMY.Unknown;
            HeroClass = ENTITY_HERO_CLASS_ENEMY.Unknown;
            MoveFight = false;
            LaneMove = -1;
        }

        public virtual int Hit(out string hit) { hit = "Hit"; return Damage; }
    }
}