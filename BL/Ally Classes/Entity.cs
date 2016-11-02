using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Character_Classes
{
    public enum ARMOR { Unarmored = 0, Light = 10, Medium = 25, Heavy = 25, Hero = 50, Unknown = -1 };
    public enum ENTITY_HERO_CLASS { Griffin, Knight, Crusader, Unknown = -1 };
    public enum ENTITY_MINION_CLASS { Dwarf, AirElemental, Gargoyle, Unknown = -1 };

    public abstract class Entity
    {
        protected Random rnd;

        public virtual string Name { get; protected set; }
        public PointF StrtCoords { get; set; }
        public virtual int Gold { get; set; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }
        public ARMOR Armor { get; protected set; }
        public virtual ENTITY_HERO_CLASS HeroClass { get; protected set; }
        public virtual ENTITY_MINION_CLASS MinionClass { get; protected set; }

        public Entity()
        {
            rnd = new Random();
            Name = String.Empty;
            Gold = 0;
            Health = 0;
            Damage = 0;
            Armor = ARMOR.Unknown;
            HeroClass = ENTITY_HERO_CLASS.Unknown;
            MinionClass = ENTITY_MINION_CLASS.Unknown;
        }

        public virtual int Hit(out string hit) { hit = "Hit"; return Damage; }
        public virtual void LevelUp(int cost)
        {
            Damage += Damage;
            Health += Health;
            Gold -= cost;
        }
    }
}
