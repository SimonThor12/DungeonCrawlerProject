namespace DungeonCrawlerProject
{
  public class NormalAttack : ICharacterAttackBehaviour
  {
    //sending both attacker and target for future use in attack behaviours and armor
    public int Attack(ICharacter attacker, ICharacter target)
    {
      int damage = 1;
      damage += 5; // dynamic later: attacker.Weapon.ItemPower; 
      return damage;

    }
  }



}
