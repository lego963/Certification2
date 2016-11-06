namespace BL.Enemy_Classes.Heroes
{
    public class Knight : EnemyEntity
    {
        public Knight() : base()
        {
            Armor = ARMOR.Hero;
            Damage = rnd.Next(10,25);
            MoveFight = ACTION.Move;
            Health = 100;
            HeroClass = ENTITY_HERO_CLASS_ENEMY.Knight;
        }
        public override int Hit(out string hit)
        {
            return base.Hit(out hit);
        }
    }
}
