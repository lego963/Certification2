using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Character_Classes
{
    public class Knight : Entity
    {
        Random rnd = new Random();

        public Knight() : base() { }
        public Knight(string name, int dmg) : base()
        {
            Name = name;
            Damage = rnd.Next(5, 8);
            Dodge = rnd.Next(5, 25);
        }
    }
}
