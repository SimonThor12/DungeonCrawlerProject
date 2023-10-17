namespace DungeonCrawlerProject
{
  public class DragonMonsterFactory : MonsterFactory
  {
    public override ICharacter CreateMonster()
    {
      return new MonsterCharacter("Dragon", 500, new NormalAttack());
    }
  }
}
