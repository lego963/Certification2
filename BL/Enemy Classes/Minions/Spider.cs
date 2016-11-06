namespace BL.Enemy_Classes.Minions
{
    public class Spider : EnemyEntity
    {
        public Spider() : base()
        {
            Armor = ARMOR.Medium;
            Health = 5;
            Damage = rnd.Next(5, 8);
            MinionClass = ENTITY_MINION_CLASS_ENEMY.Spider;
            MoveFight = ACTION.Move;
        }
        public override int Hit(out string hit)
        {
            int luck = rnd.Next(100);
            if (luck > 50) { hit = "Poison hit"; return Damage * 2; }
            else return base.Hit(out hit);
        }
    }
}
