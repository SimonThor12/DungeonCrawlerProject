namespace DungeonCrawlerProject
{
  public class MonsterCharacter : ICharacter
  {
    public string Name { get; set; }
    public int Health { get; set; }
    public int Attack { get; set; }
    public ICharacterAttackBehaviour AttackBehaviour { get; set; }
    public IItem equipedWeapon { get; set; }

    public MonsterCharacter(string name, int health, ICharacterAttackBehaviour attackBehaviour)
    {
      Name = name;
      Health = health;
      AttackBehaviour = attackBehaviour;
    }
  }
}
