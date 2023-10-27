namespace DungeonCrawlerProject
{
  public class NormalAttack : ICharacterAttackBehaviour
  {
 
    public int Attack(ICharacter attacker)
    {
      int itempower = attacker.equipedWeapon.ItemPower;
      var scalingfactor = (attacker.Strength / 10) + 1;
      itempower *= scalingfactor;
      int damage = itempower; //+ attacker.Strength;
      return damage;

    }
  }



}
