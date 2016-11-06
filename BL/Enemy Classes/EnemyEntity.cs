using System;
using System.Drawing;

namespace BL.Enemy_Classes
{
    public enum ARMOR { Without = 0, Light = 10, Medium = 15, Heavy = 20, Hero = 30, Unknown = -1 };
    public enum ENTITY_MINION_CLASS_ENEMY { Goblin, Spider, Golem, Unknown = -1 };
    public enum ENTITY_HERO_CLASS_ENEMY { Knight, Unknown };
    public enum ACTION { Move, Fight, Unknown };

    public abstract class EnemyEntity
    {
        protected Random rnd;

        public ACTION MoveFight { get; set; }
        public PointF Coords;
        public int LaneMove { get; set; }
        public int Health { get; set; }
        public int Damage { get; protected set; }
        public ARMOR Armor { get; protected set; }
        public virtual ENTITY_MINION_CLASS_ENEMY MinionClass { get; protected set; }
        public virtual ENTITY_HERO_CLASS_ENEMY HeroClass { get; protected set; }
        public bool[] CheckPoints;

        public EnemyEntity()
        {
            rnd = new Random();
            Health = 0;
            Damage = 0;
            Armor = ARMOR.Unknown;
            MinionClass = ENTITY_MINION_CLASS_ENEMY.Unknown;
            HeroClass = ENTITY_HERO_CLASS_ENEMY.Unknown;
            MoveFight = ACTION.Unknown;
            LaneMove = -1;
            CheckPoints = new bool[2];
        }

        public virtual int Hit(out string hit) { hit = "Hit"; return Damage; }
    }
}