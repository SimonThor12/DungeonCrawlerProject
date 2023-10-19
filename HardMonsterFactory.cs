namespace DungeonCrawlerProject
{
  public class HardMonsterFactory : MonsterFactory
  {
    public override MonsterCharacter CreateMonster()
    {
      //Random number generator
      Random rand = new Random();

      switch (rand.Next(1, 4))
      {
        case 1:
          return new MonsterCharacter("Goblin King", 370, new NormalAttack());
        case 2:
          return new MonsterCharacter("Chimera", 350, new NormalAttack());
        case 3:
          return new MonsterCharacter("Smaller Dragon", 500, new NormalAttack());
        default:
          return new MonsterCharacter("Blob", 250, new NormalAttack());
      }

    }
  }
}
