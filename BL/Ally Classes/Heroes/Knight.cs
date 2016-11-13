namespace BL.Character_Classes.Heroes
{
    public class Knight : AllyEntity
    {
        public Knight() : base() { }
        public Knight(string name) : base()
        {
            Name = name;
            Damage = rnd.Next(4, 7);
            Armor = ARMOR.Heavy;
            Gold = 0;
            Health = 100;
            HeroClass = ENTITY_HERO_CLASS_ALLY.Knight;
            MoveFight = ACTION.Move;
        }

        public override int Hit(out string hit)
        {
            int luck = rnd.Next(100);
            if (luck > 75) { hit = "CAVALRY HIT"; return Damage * 2; }
            { hit = "HIT"; return Damage; }
        }
    }
}
