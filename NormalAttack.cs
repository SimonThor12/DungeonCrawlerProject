namespace DungeonCrawlerProject
{
  public class NormalAttack : ICharacterAttackBehaviour<int>
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
