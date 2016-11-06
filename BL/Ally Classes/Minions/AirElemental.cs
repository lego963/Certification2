namespace BL.Character_Classes.Minions
{
    public class AirElemental : AllyEntity
    {
        public AirElemental() : base()
        {
            Health = 25;
            Armor = ARMOR.Unarmored;
            Damage = rnd.Next(2, 4);
            MinionClass = ENTITY_MINION_CLASS_ALLY.AirElemental;
            MoveFight = ACTION.Move;
        }

        public override int Hit(out string hit)
        {
            return base.Hit(out hit);
        }
    }
}
