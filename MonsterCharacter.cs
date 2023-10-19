namespace DungeonCrawlerProject
{
  public class MonsterCharacter : ICharacter
  {
    public string Name { get; set; }
    public int Health { get; set; }
    public ICharacterAttackBehaviour AttackBehaviour { get; set; }
    public IWeapon equipedWeapon { get; set; }

    public MonsterCharacter(string name, int health, ICharacterAttackBehaviour attackBehaviour)
    {
      Name = name;
      Health = health;
      AttackBehaviour = attackBehaviour;
    }

    public int Attack(ICharacter target)
    {
      return AttackBehaviour.Attack(this);
    }
  }
}
