namespace DungeonCrawlerProject
{
  public class MonsterCharacter : ICharacter
  {
    public string Name { get; set; }
    public int Health { get; set; }

    public int Strength { get; set; }
    public ICharacterAttackBehaviour AttackBehaviour { get; set; }
    public IWeapon equipedWeapon { get; set; }

    public MonsterCharacter(string name, int health, ICharacterAttackBehaviour attackBehaviour, int strength)
    {
      Name = name;
      Health = health;
      AttackBehaviour = attackBehaviour;
      Strength = strength;
      equipedWeapon = new Weapon("Fists", 1);
    }

    public int Attack()
    {
      return AttackBehaviour.Attack(this);
    }
  }
}
