namespace DungeonCrawlerProject
{
  public class HardMonsterFactory : MonsterFactory
  {
    HardMonsterWeaponCreator monsterWeaponCreator;

    public HardMonsterFactory(HardMonsterWeaponCreator monsterWeaponCreator)
    {
      this.monsterWeaponCreator = monsterWeaponCreator;
    }
    public override MonsterCharacter CreateMonster()
    {
      //Random number generator
      Random random = new Random();

      switch (random.Next(1, 5))
      {
        case 1:
          return new MonsterCharacter("Goblin King", random.Next(150, 300), new NormalAttack(), random.Next(30, 50), monsterWeaponCreator.CreateWeapon("Goblin King"));
        case 2:
          return new MonsterCharacter("Chimera", random.Next(150, 300), new NormalAttack(), random.Next(30, 50), monsterWeaponCreator.CreateWeapon("Chimera"));
        case 3:
          return new MonsterCharacter("Smaller Dragon", random.Next(150, 300), new NormalAttack(), random.Next(30, 50), monsterWeaponCreator.CreateWeapon("Smaller Dragon"));
        default:
          return new MonsterCharacter("Blob", random.Next(150, 300), new NormalAttack(), random.Next(30, 50), monsterWeaponCreator.CreateWeapon("Blob"));
      }
    }
  }
}
