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

  }
}
