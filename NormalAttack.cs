namespace DungeonCrawlerProject
{
  public class NormalAttack : ICharacterAttackBehaviour
  {
    //sending both attacker and target for future use in attack behaviours and armor
    public int Attack(ICharacter attacker)
    {
      int damage = attacker.equipedWeapon.ItemPower + attacker.Strength;
      return damage;

    }
  }



}
