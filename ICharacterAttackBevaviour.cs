namespace DungeonCrawlerProject
{
  //This interface abstracts the attack behaviour of a character to allow for different attack behaviours
  public interface ICharacterAttackBevaviour
  {
    void Attack(ICharacter target);
  }
}
