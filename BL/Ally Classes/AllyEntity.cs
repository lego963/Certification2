using System;
using System.Drawing;

namespace BL.Character_Classes
{
    public enum ARMOR { Unarmored = 0, Light = 10, Medium = 15, Heavy = 20, Hero = 30, Unknown = -1 };
    public enum ENTITY_HERO_CLASS_ALLY { Griffin, Knight, Crusader, Unknown = -1 };
    public enum ENTITY_MINION_CLASS_ALLY { Dwarf, AirElemental, Gargoyle, Unknown = -1 };
    public enum ACTION { Move, Fight, Unknown };

    public abstract class AllyEntity
    {
        protected Random rnd;

        public virtual string Name { get; protected set; }
        public PointF Coords;
        public virtual int Gold { get; set; }
        public int Health { get; set; }
        public int Damage { get; protected set; }
        public ARMOR Armor { get; protected set; }
        public virtual ENTITY_HERO_CLASS_ALLY HeroClass { get; protected set; }
        public virtual ENTITY_MINION_CLASS_ALLY MinionClass { get; protected set; }
        public ACTION MoveFight { get; set; }
        public int LaneMove { get; set; }
        public bool[] CheckPoints { get; set; }

        public AllyEntity()
        {
            rnd = new Random();
            Name = String.Empty;
            Gold = 0;
            Health = 0;
            Damage = 0;
            Armor = ARMOR.Unknown;
            HeroClass = ENTITY_HERO_CLASS_ALLY.Unknown;
            MinionClass = ENTITY_MINION_CLASS_ALLY.Unknown;
            MoveFight = ACTION.Unknown;
            LaneMove = -1;
            CheckPoints = new bool[2];
        }

        public virtual int Hit(out string hit) { hit = "HIT"; return Damage; }
        public virtual void LevelUp(int cost)
        {
            Damage += Damage;
            Health += Health;
            Gold -= cost;
        }
    }
}
