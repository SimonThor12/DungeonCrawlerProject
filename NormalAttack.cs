namespace DungeonCrawlerProject
{
  public class NormalAttack : ICharacterAttackBehaviour
  {
    //sending both attacker and target for future use in attack behaviours and armor
    public int Attack(ICharacter attacker)
    {
      int itempower = attacker.equipedWeapon.ItemPower;
      int strength = attacker.Strength;
      int damage;

      if (itempower >= strength)
      {
        damage = itempower;
      }
      else
      {
        damage = itempower + strength;
      }

      return damage;


    }
  }



}
