namespace DungeonCrawlerProject
{
  public class NormalAttack : ICharacterAttackBehaviour
  {
 
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
