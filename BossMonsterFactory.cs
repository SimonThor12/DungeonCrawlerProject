namespace DungeonCrawlerProject
{
  public class BossMonsterFactory : MonsterFactory
  {
    public override MonsterCharacter CreateMonster()
    {
      // Random number generator
      Random rand = new Random();

      switch (rand.Next(1, 4))
      {
        case 1:
          return new MonsterCharacter("Netherlord Zorath", rand.Next(700, 2001), new NormalAttack());
        case 2:
          return new MonsterCharacter("Serpentix the Devourer", rand.Next(700, 2001), new NormalAttack());
        case 3:
          return new MonsterCharacter("Molten Core Guardian", rand.Next(700, 2001), new NormalAttack());
        default:
          return new MonsterCharacter("Abyssal Leviathan", rand.Next(700, 2001), new NormalAttack());
      }
    }
  }
}
