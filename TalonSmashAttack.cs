namespace DungeonCrawlerProject
{
  public class TalonSmashAttack : ICharacterAttackBehaviour
  {
    public int Attack(ICharacter character, ICharacter target)
    {
      int damage = 1;
      damage += 5; // dynamic later: attacker.Weapon.ItemPower; 
      target.Health -= damage;
      return damage;
    }
  }
}