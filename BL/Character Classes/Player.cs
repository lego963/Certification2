using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Character_Classes
{
    public class Player : Entity
    {
        public Player() : base() { }
        public Player(string name, ENTITY_CLASS _class) : base()
        {
            Name = name;
            Class = _class;
        }
    }
}
