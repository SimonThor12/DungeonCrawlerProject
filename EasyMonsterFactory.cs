namespace DungeonCrawlerProject
{
  public class EasyMonsterFactory : MonsterFactory
  {
    public override MonsterCharacter CreateMonster()
    {
      //Random number generator
      Random random = new Random();

      switch (random.Next(1, 4))
      {
        case 1:
          return new MonsterCharacter("Gremlin", random.Next(70, 100), new NormalAttack(), random.Next(5, 10));
        case 2:
          return new MonsterCharacter("Orc", random.Next(70, 100), new NormalAttack(), random.Next(5, 10));
        case 3:
          return new MonsterCharacter("Pesky Troll", random.Next(70, 100), new NormalAttack(), random.Next(5, 10));
        default:
          return new MonsterCharacter("Goblin", random.Next(70, 100), new NormalAttack(), random.Next(5, 10));
      }
    }
  }
}
