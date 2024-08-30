namespace DungeonCrawlerProject
{
  public class BossMonsterFactory : MonsterFactory
  {
    BossMonsterWeaponCreator monsterWeaponCreator;
    public BossMonsterFactory(BossMonsterWeaponCreator monsterWeaponCreator)
    {
      this.monsterWeaponCreator = monsterWeaponCreator;
    }
    public override MonsterCharacter CreateMonster()
    {
      // Random number generator
      Random random = new Random();

      switch (random.Next(1, 5))
      {
        case 1:
          return new MonsterCharacter("Netherlord Zorath", random.Next(900, 2001), new NormalAttack(), random.Next(50, 150), monsterWeaponCreator.CreateWeapon("Netherlord Zorath"));
        case 2:
          return new MonsterCharacter("Serpentix the Devourer", random.Next(900, 2001), new NormalAttack(), random.Next(50, 150), monsterWeaponCreator.CreateWeapon("Serpentix the Devourer"));
        case 3:
          return new MonsterCharacter("Molten Core Guardian", random.Next(900, 2001), new NormalAttack(), random.Next(50, 150), monsterWeaponCreator.CreateWeapon("Molten Core Guardian"));
        default:
          return new MonsterCharacter("Abyssal Leviathan", random.Next(900, 2001), new NormalAttack(), random.Next(50, 150), monsterWeaponCreator.CreateWeapon("Abyssal Leviathan"));
      }
    }
  }
}
