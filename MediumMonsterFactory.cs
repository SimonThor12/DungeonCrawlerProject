namespace DungeonCrawlerProject
{
  public class MediumMonsterFactory : MonsterFactory
  {
    MediumMonsterWeaponCreator monsterWeaponCreator;

    public MediumMonsterFactory(MediumMonsterWeaponCreator monsterWeaponCreator)
    {
      this.monsterWeaponCreator = monsterWeaponCreator;
    }
    public override MonsterCharacter CreateMonster()
    {
      //Random number generator
      Random random = new Random();

      switch (random.Next(1, 4))
      {
        case 1:
          return new MonsterCharacter("Ogre", random.Next(100, 150), new NormalAttack(), random.Next(10, 30), monsterWeaponCreator.CreateWeapon("Ogre"));
        case 2:
          return new MonsterCharacter("Minotaur", random.Next(100, 150), new NormalAttack(), random.Next(10, 30), monsterWeaponCreator.CreateWeapon("Minotaur"));
        case 3:
          return new MonsterCharacter("Skeleton", random.Next(100, 150), new NormalAttack(), random.Next(10, 30), monsterWeaponCreator.CreateWeapon("Skeleton"));
        default:
          return new MonsterCharacter("Harpy", random.Next(100, 150), new TalonSmashAttack(), random.Next(10, 30), monsterWeaponCreator.CreateWeapon("Harpy"));
      }
    }
  }
}
