namespace DungeonCrawlerProject
{
  public class PlayerCharacter : ICharacter
  {
    public string Name { get; set; }
    public int Health { get; set; }

    public int CompletedRooms = 0;
    public ICharacterAttackBehaviour AttackBehaviour { get; set; }

    public Inventory<IItem> personalInventory = new Inventory<IItem>();
    public IWeapon equipedWeapon { get; set; }

    public int Strength = 1;
    public PlayerCharacter(int health, ICharacterAttackBehaviour attackBehaviour)
    {
      Health = health;
      AttackBehaviour = attackBehaviour;
    }
    //method that takes the attackbehaviour and the weapon and uses the attackbehaviour to attack with the weapon
    public int Attack()
    {
      return Strength + AttackBehaviour.Attack(this);
    }
  }
}
