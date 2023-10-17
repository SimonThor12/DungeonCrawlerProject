namespace DungeonCrawlerProject
{
  class PlayerCharacter : ICharacter
  {
    public string Name { get; set; }
    public int Health { get; set; }
    public ICharacterAttackBevaviour AttackBevaviour { get; set; }

    public PlayerCharacter(string name, int health, ICharacterAttackBevaviour attackBevaviour)
    {
      Name = name;
      Health = health;
      AttackBevaviour = attackBevaviour;
    }
    //method that takes the attackbehaviour and the weapon and uses the attackbehaviour to attack with the weapon
  }
}
