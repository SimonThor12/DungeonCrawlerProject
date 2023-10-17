namespace DungeonCrawlerProject
{
  public class GoblinMonsterFactory
  {
    public ICharacter CreateMonster()
    {
      return new MonsterCharacter("Goblin", 100, new NormalAttack());
    }
  }
}
