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
      // Create a monster based on the player's score 
      // (e.g., if the player's score is 10 or higher, create a boss monster)
      //The goal is to change the equiped weapons more precicely...orkar inte fixa det nu.
      MonsterCharacter encounteredMonster = CreateMonsterForEncounter();
      Monster = encounteredMonster;

      Console.WriteLine("As you cautiously step into the dimly lit chamber,");
      Console.WriteLine("a menacing growl echoes off the cold stone walls.");
      Console.WriteLine("The air feels thick with tension,");
      Console.WriteLine($"and your heart quickens as you catch a glimpse of movement in the shadows.");
      Console.WriteLine($"There, emerging from the darkness, is a {Monster.Name}!");
      Console.WriteLine("Its eyes gleam with malevolence,");
      Console.WriteLine("and its grotesque form sends shivers down your spine.");
      Console.ReadKey();
      Console.WriteLine("Prepare for battle!");
      Console.Clear();



      while (!encounterOver)
      {
        if (playerTurn)
        {
          Console.Clear();
          Console.WriteLine("It's your turn. What will you do?");
          Console.WriteLine(Player.Name + " HP: " + Player.Health + " | " + Monster.Name + " HP: " + Monster.Health);
          Console.WriteLine("******************");
          Console.WriteLine("|> 1. Attack    <|");
          Console.WriteLine("|> 2. Flee      <|");
          Console.WriteLine("|> 3. Inventory <|");
          Console.WriteLine("******************");

          string input = Console.ReadLine();

          switch (input)
          {
            case "1":
              PlayerAttack();
              break;

            case "2":
              //try to flee from the encounter, with a small chance of success
              if (new Random().Next(1, 10) == 1)
              {
                Console.WriteLine("You successfully flee from the encounter!");
                encounterOver = true;
                break;
              }
              else
              {
                Console.WriteLine("You failed to flee from the encounter!");
                break;
              }

            case "3":
              Console.WriteLine("You open your inventory");
              break;

            default:
              Console.WriteLine("Invalid choice. Try again next time.");
              break;
          }
        }
        else
        {
          MonsterAttack();
        }
        Console.Clear();
        // Check if the encounter is over (e.g., player or monster health reaches zero)
        if (Player.Health <= 0)
        {
          Console.WriteLine("You have been defeated!");
          Console.WriteLine("GAME OVER");
          //Try again?
          Console.WriteLine("Press any key to continue...");
          Console.ReadKey();
          Console.Clear();

          encounterOver = true;

        }
        else if (Monster.Health <= 0)
        {
          Console.WriteLine($"You have defeated the {Monster.Name}!");
          Player.PlayerScore++;
          Player.Health = 100;
          //ska randomisa vapen man får, ej hårdkoda
          Player.equipedWeapon = new Weapon("Sword", 100);
          //Här kommer inventory in vid lootning
          encounterOver = true;
          Console.WriteLine("Encounter has ended, and your health was restored. Press any key to continue...");    //tester om detta slutar encountern
          Console.ReadKey();
          return;
        }

        playerTurn = !playerTurn; // Switch turns between player and monster
      }

    }

    private MonsterCharacter CreateMonsterForEncounter()
    {
      if (Player.PlayerScore >= 10)
      {
        MonsterFactory = new BossMonsterFactory();
        Monster = MonsterFactory.CreateMonster();
        Monster.equipedWeapon = new Weapon("Fist", 1000);

      }
      else if (Player.PlayerScore >= 7)
      {
        MonsterFactory = new HardMonsterFactory();
        Monster = MonsterFactory.CreateMonster();
        Monster.equipedWeapon = new Weapon("Fist", 500);


      }
      else if (Player.PlayerScore >= 3)
      {
        MonsterFactory = new MediumMonsterFactory();
        Monster = MonsterFactory.CreateMonster();
        Monster.equipedWeapon = new Weapon("Fist", 50);

      }
      else
      {
        MonsterFactory = new EasyMonsterFactory();
        Monster = MonsterFactory.CreateMonster();
        Monster.equipedWeapon = new Weapon("Fist", 5);
      }


      Console.WriteLine($"You have encountered a {Monster.Name}!");

      return Monster;

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
