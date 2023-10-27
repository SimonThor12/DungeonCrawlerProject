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

      switch (random.Next(1, 16))
      {
        case 1:
          return new MonsterCharacter("Gremlin", random.Next(70, 100), new NormalAttack(), random.Next(5, 10), monsterWeaponCreator.CreateWeapon("Gremlin"));
        case 2:
          return new MonsterCharacter("Orc", random.Next(70, 100), new NormalAttack(), random.Next(5, 10), monsterWeaponCreator.CreateWeapon("Orc"));
        case 3:
          return new MonsterCharacter("Pesky Troll", random.Next(70, 100), new NormalAttack(), random.Next(5, 10), monsterWeaponCreator.CreateWeapon("Pesky Troll"));
        case 4:
          return new MonsterCharacter("Goblin", random.Next(70, 100), new NormalAttack(), random.Next(5, 10), monsterWeaponCreator.CreateWeapon("Goblin"));
        case 5:
          return new MonsterCharacter("Bandit", random.Next(70, 100), new NormalAttack(), random.Next(5, 10), monsterWeaponCreator.CreateWeapon("Bandit"));
        case 6:
          return new MonsterCharacter("Dead Soldier", random.Next(70, 100), new NormalAttack(), random.Next(5, 10), monsterWeaponCreator.CreateWeapon("Dead Soldier"));
        case 7:
          return new MonsterCharacter("Thief", random.Next(70, 100), new NormalAttack(), random.Next(5, 10), monsterWeaponCreator.CreateWeapon("Thief"));
        case 8:
          return new MonsterCharacter("Brigand", random.Next(70, 100), new NormalAttack(), random.Next(5, 10), monsterWeaponCreator.CreateWeapon("Brigand"));
        case 9:
          return new MonsterCharacter("Knight", random.Next(70, 100), new NormalAttack(), random.Next(5, 10), monsterWeaponCreator.CreateWeapon("Knight"));
        case 10:
          return new MonsterCharacter("Rogue", random.Next(70, 100), new NormalAttack(), random.Next(5, 10), monsterWeaponCreator.CreateWeapon("Rogue"));
        case 11:
          return new MonsterCharacter("Assassin", random.Next(70, 100), new NormalAttack(), random.Next(5, 10), monsterWeaponCreator.CreateWeapon("Assassin"));
        case 12:
          return new MonsterCharacter("Guardian", random.Next(70, 100), new NormalAttack(), random.Next(5, 10), monsterWeaponCreator.CreateWeapon("Guardian"));
        case 13:
          return new MonsterCharacter("Pirate", random.Next(70, 100), new NormalAttack(), random.Next(5, 10), monsterWeaponCreator.CreateWeapon("Pirate"));
        case 14:
          return new MonsterCharacter("Bounty Hunter", random.Next(70, 100), new NormalAttack(), random.Next(5, 10), monsterWeaponCreator.CreateWeapon("Bounty Hunter"));
        default:
          return new MonsterCharacter("Gladiator", random.Next(70, 100), new NormalAttack(), random.Next(5, 10), monsterWeaponCreator.CreateWeapon("Gladiator"));
      }
    }
  }
}
