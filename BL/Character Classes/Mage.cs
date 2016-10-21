using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Character_Classes
{
    public class Mage : Entity
    {
        Random rnd = new Random();

        public Mage() : base() { }
        public Mage(string name, int damage) : base()
        {
            Name = name;
            Damage = rnd.Next(10, 15);
            Dodge = 0;
        }
    }
}
