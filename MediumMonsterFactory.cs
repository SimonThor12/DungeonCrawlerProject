namespace DungeonCrawlerProject
{
  public class MediumMonsterFactory : MonsterFactory
  {
    public override MonsterCharacter CreateMonster()
    {
      //Random number generator
      Random rand = new Random();

      switch (rand.Next(1, 4))
      {
        case 1:
          return new MonsterCharacter("Ogre", 200, new NormalAttack());
        case 2:
          return new MonsterCharacter("Minotaur", 190, new NormalAttack());
        case 3:
          return new MonsterCharacter("Skeleton", 150, new NormalAttack());
        default:
          return new MonsterCharacter("Harpy", 165, new TalonSmashAttack());
      }
    }
  }
}
