namespace DungeonCrawlerProject
{
  public class PlayerCharacter : ICharacter
  {
    public string Name { get; set; }
    public int Health { get; set; }
    public ICharacterAttackBehaviour AttackBehaviour { get; set; }
    public IItem Weapon { get; set; }

    public PlayerCharacter(string name, int health, ICharacterAttackBehaviour attackBehaviour)
    {
      Name = name;
      Health = health;
      AttackBehaviour = attackBehaviour;
    }
    //method that takes the attackbehaviour and the weapon and uses the attackbehaviour to attack with the weapon
  }
}
