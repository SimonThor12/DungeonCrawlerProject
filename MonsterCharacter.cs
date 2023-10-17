﻿namespace DungeonCrawlerProject
{
  class MonsterCharacter : ICharacter
  {
    public string Name { get; set; }
    public int Health { get; set; }
    public int Attack { get; set; }
    public ICharacterAttackBevaviour AttackBevaviour { get; set; }

    public MonsterCharacter(string name, int health, ICharacterAttackBevaviour attackBehaviour)
    {
      Name = name;
      Health = health;
      AttackBevaviour = attackBehaviour;
    }
  }
}
