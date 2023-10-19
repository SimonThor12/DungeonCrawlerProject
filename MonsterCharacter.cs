namespace DungeonCrawlerProject
{
  class MonsterCharacter : ICharacter
  {
    public string Name { get; set; }
    public int Health { get; set; }
    public int Attack { get; set; }
    public ICharacterAttackBehaviour AttackBehaviour { get; set; }

    public MonsterCharacter(string name, int health, ICharacterAttackBehaviour attackBehaviour)
    {
      Name = name;
      Health = health;
      AttackBehaviour = attackBehaviour;
    }
  }
}
