namespace BL.Enemy_Classes.Minions
{
    public class Golem : EnemyEntity
    {

        public Golem() : base()
        {
            Armor = ARMOR.Heavy;
            Health = 25;
            Damage = rnd.Next(3, 5);
            MinionClass = ENTITY_MINION_CLASS_ENEMY.Golem;
            MoveFight = ACTION.Move;
        }
        public override int Hit(out string hit)
        {
            return base.Hit(out hit);
        }
    }
}
