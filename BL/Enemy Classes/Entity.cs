using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Enemy_Classes
{
    public enum ARMOR { Without = 0, Light = 10, Heavy = 25, Unknown = -1 };
    public enum ENTITY_TYPE { Goblin, Knight, Rogue, Unknown = -1 };

    public abstract class Entity
    {
        public int Health { get; protected set; }
        public int Damage { get; protected set; }
        public ARMOR Armor { get; protected set; }
        public ENTITY_TYPE Type { get; protected set; }

        public Entity()
        {
            Health = 0;
            Damage = 0;
            Armor = ARMOR.Unknown;
            Type = ENTITY_TYPE.Unknown;
        }

        public virtual int Hit() { return Damage; }
        public void NewWave()
        {
            Damage += Damage;
            Health += Health;
        }
    }
}
