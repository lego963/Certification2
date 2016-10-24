using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Character_Classes
{
    public enum ARMOR { Without = 0, Light = 10, Heavy = 25, Unknown = -1 };
    public enum ENTITY_CLASS { Mage, Knight, Rogue, Unknown = -1 };

    public abstract class EntityHeroes
    {
        protected Random rnd;

        public string Name { get; protected set; }
        public PointF StrtCoords { get; set; }
        public int Gold { get; set; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }
        public ARMOR Armor { get; protected set; }
        public ENTITY_CLASS Class { get; protected set; }

        public EntityHeroes()
        {
            rnd = new Random();
            Name = String.Empty;
            Gold = 0;
            Health = 0;
            Damage = 0;
            Armor = ARMOR.Unknown;
            Class = ENTITY_CLASS.Unknown;
        }

        public virtual int Hit(out string hit) { hit = "Hit"; return Damage; }
        public void LevelUp(int cost)
        {
            Damage += Damage;
            Health += Health;
            Gold -= cost;
        }
    }
}
