namespace DungeonCrawlerProject
{
  public class NoAttack : ICharacterAttackBehaviour<bool>
  {
    public bool Attack(ICharacter character)
    {
      return true;
    }
  }


}
