namespace DungeonCrawlerProject
{
  public class NoAttack : ICharacterAttackBehaviour
  {
    public int Attack(ICharacter character, ICharacter target)
    {
      return 0;
    }
  }


}
