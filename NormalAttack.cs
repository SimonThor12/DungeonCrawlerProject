namespace DungeonCrawlerProject
{
  public class NormalAttack : ICharacterAttackBevaviour
  {
    public void Attack(ICharacter target)
    {
      target.Health -= 10;
    }
  }



}
