﻿namespace DungeonCrawlerProject
{
  public class PlayerCharacter : ICharacter
  {
    public int amountOfRings = 0;
    public string Name { get; set; }
    public int MaxHealth = 300;
    public int Health { get; set; }

    public int CompletedRooms = 0;
    public ICharacterAttackBehaviour<int> AttackBehaviour { get; set; }

    public Inventory<IItem> personalInventory = new Inventory<IItem>();
    public IWeapon equipedWeapon { get; set; }
    public int Strength { get; set; }
    private int _experience = 0;
    private int _level;

    // Event declaration
    public event EventHandler PlayerLeveledUp;

    public int Experience
    {
      get { return _experience; }
      set
      {
        _experience = value;

        while (_experience >= 3)
        {
          _experience -= 3;
          Level++;
          PlayerLeveledUp?.Invoke(this, EventArgs.Empty); // Raise the event
        }
      }
    }

    /* KONCEPT: dependency injection
    HUR: Konstruktor-injection som tar in attackbehaviour. Alltså när en PlayerCharacter instantieras så kräver den 
    ett ICharacterAttackBehaviour.
    Vi skickar in attackbehaviour i konstruktorn 
    VARFÖR: för att vi vill att spelaren ska kunna byta attackbehaviour.
    Det är en bra idé att använda sig av konstruktor-injection när man vill att ett objekt ska ha ett visst beteende
    som kan ändras under runtime. Detta är ett exempel på detta.
    */
    public PlayerCharacter(int health, ICharacterAttackBehaviour<int> attackBehaviour)
    {
      Health = health;
      AttackBehaviour = attackBehaviour;
      Strength = 10;
    }
    //method that takes the attackbehaviour and the weapon and uses the attackbehaviour to attack with the weapon
    public int Attack()
    {
      return Strength + AttackBehaviour.Attack(this);
    }
    public int Level
    {
      get { return _level; }
      private set { _level = value; }
    }

    public int ExperienceToNextLevel
    {
      get { return 5 - _experience; }
    }

    public void DefeatMonster()
    {

      this.Experience += 1;
    }

  }
}
