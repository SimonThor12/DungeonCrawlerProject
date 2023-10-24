namespace DungeonCrawlerProject
{
  public class BossMonsterFactory : MonsterFactory
  {
    public override MonsterCharacter CreateMonster()
    {
      // Random number generator
      Random random = new Random();

      switch (random.Next(1, 4))
      {
        case 1:
          return new MonsterCharacter("Netherlord Zorath", random.Next(500, 2001), new NormalAttack(), random.Next(50, 150));
        case 2:
          return new MonsterCharacter("Serpentix the Devourer", random.Next(500, 2001), new NormalAttack(), random.Next(50, 150));
        case 3:
          return new MonsterCharacter("Molten Core Guardian", random.Next(500, 2001), new NormalAttack(), random.Next(50, 150));
        default:
          return new MonsterCharacter("Abyssal Leviathan", random.Next(500, 2001), new NormalAttack(), random.Next(50, 150));
      }
    }
  }
}
