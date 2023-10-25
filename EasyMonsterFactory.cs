namespace DungeonCrawlerProject
{
  public class EasyMonsterFactory : MonsterFactory
  {
    EasyMonsterWeaponCreator monsterWeaponCreator;
    public EasyMonsterFactory(EasyMonsterWeaponCreator monsterWeaponCreator)
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
          return new MonsterCharacter("Gremlin", random.Next(70, 100), new NormalAttack(), random.Next(5, 10), monsterWeaponCreator.CreateWeapon("Gremlin"));
        case 2:
          return new MonsterCharacter("Orc", random.Next(70, 100), new NormalAttack(), random.Next(5, 10), monsterWeaponCreator.CreateWeapon("Orc"));
        case 3:
          return new MonsterCharacter("Pesky Troll", random.Next(70, 100), new NormalAttack(), random.Next(5, 10), monsterWeaponCreator.CreateWeapon("Pesky Troll"));
        default:
          return new MonsterCharacter("Goblin", random.Next(70, 100), new NormalAttack(), random.Next(5, 10), monsterWeaponCreator.CreateWeapon("Goblin"));
      }
    }
  }
}
