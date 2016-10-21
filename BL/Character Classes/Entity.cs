using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Character_Classes
{
    public abstract class Entity
    {
        public string Name { get; set; }
        public int Health { get; set; }        
        public int Damage { get; set; }
        public int Dodge { get; set; }

        public Entity()
        {
            Name = String.Empty;
            Health = 0;
            Damage = 0;
            Dodge = 0;
        }
    }
}
