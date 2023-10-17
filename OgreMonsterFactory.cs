namespace DungeonCrawlerProject
{
  public class OgreMonsterFactory : MonsterFactory
  {
    public override ICharacter CreateMonster()
    {
      return new MonsterCharacter("Ogre", 200, new NormalAttack());
    }
  }
}
