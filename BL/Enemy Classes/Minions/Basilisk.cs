namespace BL.Enemy_Classes.Minions
{
    public class Basilisk : EnemyEntity
    {
        public Basilisk() : base()
        {
            Armor = ARMOR.Medium;
            Health = 25;
            Damage = rnd.Next(5, 8);
            MinionClass = ENTITY_MINION_CLASS_ENEMY.Basilisk;
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
