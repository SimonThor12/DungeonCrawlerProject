namespace DungeonCrawlerProject
{
  public class PlayerCharacter : ICharacter
  {
    public string Name { get; set; }
    public int Health { get; set; }
    public ICharacterAttackBehaviour AttackBehaviour { get; set; }
    public IWeapon equipedWeapon { get; set; }
    public Inventory<IItem> powerUpInventory { get; set; }

    public int PlayerScore = 0;
    public PlayerCharacter(int health, ICharacterAttackBehaviour attackBehaviour)
    {
      Health = health;
      AttackBehaviour = attackBehaviour;
    }
    public int Attack(ICharacter target)
    {
      return AttackBehaviour.Attack(this);
    }
  }
}
