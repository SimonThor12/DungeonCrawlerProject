namespace DungeonCrawlerProject
{
  public class TalonSmashAttack : ICharacterAttackBehaviour
  {
    public int Attack(ICharacter character)
    {
      int damage = 500;
      return damage;
    }
  }
}