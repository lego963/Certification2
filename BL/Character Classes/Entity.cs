using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Character_Classes
{
    public enum ARMOR { Without = 0, Light = 10, Heavy = 25, Unknown = -1 };
    public enum ENTITY_CLASS { Mage, Knight, Rogue, Unknown = -1 };

    public abstract class Entity
    {
        protected Random rnd;

        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }
        public ARMOR Armor { get; protected set; }
        public ENTITY_CLASS Class { get; protected set; }

        public Entity()
        {
            rnd = new Random();
            Name = String.Empty;
            Health = 0;
            Damage = 0;
            Armor = ARMOR.Unknown;
            Class = ENTITY_CLASS.Unknown;
        }
    }
}
