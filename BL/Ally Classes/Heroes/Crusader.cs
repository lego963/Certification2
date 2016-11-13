namespace BL.Character_Classes.Heroes
{
    public class Crusader : AllyEntity
    {
        public Crusader() : base() { }
        public Crusader(string name) : base()
        {
            Name = name;
            Health = 75;
            Armor = ARMOR.Hero;
            Gold = 0;
            Damage = rnd.Next(8, 10);
            HeroClass = ENTITY_HERO_CLASS_ALLY.Crusader;
            MoveFight = ACTION.Move;
        }

        public override int Hit(out string hit)
        {
            int luck = rnd.Next(100);
            if (luck > 50) { hit = "CRITICAL HIT"; return Damage * 2; }
            else { hit = "HIT"; return Damage; }
        }
    }
}
