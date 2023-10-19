namespace DungeonCrawlerProject
{
  public class Encounter
  {

    public MonsterFactory MonsterFactory { get; set; }
    public MonsterCharacter Monster { get; set; }
    public PlayerCharacter Player { get; set; }


    public Encounter(PlayerCharacter player)
    {
      Player = player;
    }

    public void StartEncounter()
    {
      bool encounterOver = false;
      bool playerTurn = true;

      if (Player.PlayerScore >= 10)
      {
        MonsterFactory = new BossMonsterFactory();
        Monster = MonsterFactory.CreateMonster();
      }
      else if (Player.PlayerScore >= 7)
      {
        MonsterFactory = new HardMonsterFactory();
        Monster = MonsterFactory.CreateMonster();
      }
      else if (Player.PlayerScore >= 3)
      {
        MonsterFactory = new MediumMonsterFactory();
        Monster = MonsterFactory.CreateMonster();
      }
      else
      {
        MonsterFactory = new EasyMonsterFactory();
        Monster = MonsterFactory.CreateMonster();
      }

      Console.WriteLine($"You have encountered a {Monster.Name}!");
      Console.WriteLine("Press any key to continue...");
      Console.ReadKey();
      Console.Clear();

      while (!encounterOver)
      {
        if (playerTurn)
        {
          Console.WriteLine("It's your turn. What will you do?");
          Console.WriteLine("1. Attack");
          Console.WriteLine("2. Flee");

          string input = Console.ReadLine();

          switch (input)
          {
            case "1":
              PlayerAttack();
              break;

            case "2":
              Console.WriteLine("You flee from the encounter!");
              encounterOver = true;
              break;

            default:
              Console.WriteLine("Invalid choice. Try again.");
              break;
          }
        }
        else
        {
          MonsterAttack();
        }

        // Check if the encounter is over (e.g., player or monster health reaches zero)
        if (Player.Health <= 0)
        {
          Console.WriteLine("You have been defeated!");
          encounterOver = true;
        }
        else if (Monster.Health <= 0)
        {
          Console.WriteLine($"You have defeated the {Monster.Name}!");
          encounterOver = true;
        }

        playerTurn = !playerTurn; // Switch turns between player and monster
      }

    }
    public static void PlayEncounter(PlayerCharacter player)
    {
      Console.Clear();
      Console.WriteLine("As you cautiously step through the door, you find yourself in a vast chamber.");
      Console.WriteLine("The air is thick with tension as you notice shadows dancing across the walls.");
      Console.WriteLine($"Suddenly, a menacing screech pierces the silence, and a monster swoops down before you!");
      Console.WriteLine($"Prepare for battle, {player.Name}!");
    }

    private void PlayerAttack()
    {
      int damage = Player.Attack(Monster);
      Console.WriteLine($"You attack the {Monster.Name} and deal {damage} damage!");
      Monster.Health -= damage;

    }

    private void MonsterAttack()
    {
      int damage = Monster.Attack(Player);
      Console.WriteLine($"The {Monster.Name} attacks you and deals {damage} damage!");
      Player.Health -= damage;
    }
  }
}
