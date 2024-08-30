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

      switch (random.Next(1, 5))
      {
        case 1:
          return new MonsterCharacter("Ogre", random.Next(75, 125), new NormalAttack(), random.Next(10, 20), monsterWeaponCreator.CreateWeapon("Ogre"));
        case 2:
          return new MonsterCharacter("Minotaur", random.Next(75, 125), new NormalAttack(), random.Next(10, 20), monsterWeaponCreator.CreateWeapon("Minotaur"));
        case 3:
          return new MonsterCharacter("Skeleton", random.Next(75, 125), new NormalAttack(), random.Next(10, 20), monsterWeaponCreator.CreateWeapon("Skeleton"));
        default:
          return new MonsterCharacter("Harpy", random.Next(75, 125), new TalonSmashAttack(), random.Next(10, 20), monsterWeaponCreator.CreateWeapon("Harpy"));
      }
    }
  }
}
