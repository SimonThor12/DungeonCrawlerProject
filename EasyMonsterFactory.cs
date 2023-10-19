namespace DungeonCrawlerProject
{
  public class EasyMonsterFactory : MonsterFactory
  {
    public override MonsterCharacter CreateMonster()
    {
      //Random number generator
      Random rand = new Random();

      switch (rand.Next(1, 4))
      {
        case 1:
          return new MonsterCharacter("Gremlin", 50, new NormalAttack());
        case 2:
          return new MonsterCharacter("Orc", 70, new NormalAttack());
        case 3:
          return new MonsterCharacter("Pesky Troll", 100, new NormalAttack());
        default:
          return new MonsterCharacter("Goblin", 40, new NormalAttack());
      }

    }
  }
}
