namespace DungeonCrawlerProject
{
  public class OrcMonsterFactory : MonsterFactory
  {
    public override ICharacter CreateMonster()
    {
      return new MonsterCharacter("Orc", 150, new NormalAttack());
    }
  }
}
