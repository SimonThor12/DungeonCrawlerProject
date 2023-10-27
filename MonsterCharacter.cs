namespace DungeonCrawlerProject
{
  public class MonsterCharacter : ICharacter
  {
    public string Name { get; set; }
    public int Health { get; set; }

    public int Strength { get; set; }
    public ICharacterAttackBehaviour<int> AttackBehaviour { get; set; }
    public IWeapon equipedWeapon { get; set; }

    public MonsterCharacter(string name, int health, ICharacterAttackBehaviour<int> attackBehaviour, int strength, IWeapon weapon)
    {
      Name = name;
      Health = health;
      AttackBehaviour = attackBehaviour;
      Strength = strength;
      equipedWeapon = weapon;
    }

    public int Attack()
    {
      return AttackBehaviour.Attack(this);
    }
  }
}
