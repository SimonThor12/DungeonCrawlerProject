namespace DungeonCrawlerProject
{
  public class GoblinMonsterFactory : MonsterFactory
  {
    public override ICharacter CreateMonster()
    {
      return new MonsterCharacter("Goblin", 100, new NormalAttack());
    }
  }
}
