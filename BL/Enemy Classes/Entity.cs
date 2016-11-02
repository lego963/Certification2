using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Enemy_Classes
{
    public enum ARMOR { Without = 0, Light = 10, Heavy = 25, Unknown = -1 };
    public enum ENTITY_TYPE { Goblin, Spider, Golem, Unknown = -1 };

    public abstract class Entity
    {
        protected Random rnd;

        public PointF StrtCoords { get; set; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }
        public ARMOR Armor { get; protected set; }
        public ENTITY_TYPE Type { get; protected set; }

        public Entity()
        {
            rnd = new Random();
            Health = 0;
            Damage = 0;
            Armor = ARMOR.Unknown;
            Type = ENTITY_TYPE.Unknown;
        }

        public virtual int Hit(out string hit) { hit = "Hit"; return Damage; }
        public void NewWave()
        {
            Damage += Damage;
            Health += Health;
        }
    }
}