namespace BL.Character_Classes.Heroes
{
    public class Griffin : AllyEntity
    {
        public Griffin() : base() { }
        public Griffin(string name) : base()
        {
            Name = name;
            Damage = rnd.Next(10, 15);
            Armor = ARMOR.Hero;
            Gold = 0;
            Health = 50;
            HeroClass = ENTITY_HERO_CLASS_ALLY.Griffin;
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
