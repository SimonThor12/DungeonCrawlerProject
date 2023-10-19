namespace DungeonCrawlerProject
{
  public class PlayerCharacter : ICharacter
  {
    public string Name { get; set; }
    public int Health { get; set; }
    public ICharacterAttackBehaviour AttackBehaviour { get; set; }
    public IItem equipedWeapon { get; set; }
    public Inventory<IItem> powerUpInventory { get; set; }
    public PlayerCharacter(int health, ICharacterAttackBehaviour attackBehaviour)
    {
      Health = health;
      AttackBehaviour = attackBehaviour;
    }
    //method that takes the attackbehaviour and the weapon and uses the attackbehaviour to attack with the weapon
  }
}
