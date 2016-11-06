namespace BL.Character_Classes.Minions
{
    public class Gargoyle : AllyEntity
    {
        public Gargoyle() : base()
        {
            Health = 25;
            Armor = ARMOR.Heavy;
            Damage = rnd.Next(2, 4);
            MinionClass = ENTITY_MINION_CLASS_ALLY.Gargoyle;
            MoveFight = ACTION.Move;
        }

        public override int Hit(out string hit)
        {
            return base.Hit(out hit);
        }
    }
}
