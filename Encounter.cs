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

      PlayEncounterText(Player, Monster);
      Console.ReadKey();

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
          Player.CompletedRooms++;
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
      if (Player.CompletedRooms >= 10)
      {
        MonsterFactory = new BossMonsterFactory();
        Monster = MonsterFactory.CreateMonster();
        Monster.equipedWeapon = new Weapon("Fist", 1000);

      }
      else if (Player.CompletedRooms >= 7)
      {
        MonsterFactory = new HardMonsterFactory();
        Monster = MonsterFactory.CreateMonster();
        Monster.equipedWeapon = new Weapon("Fist", 500);


      }
      else if (Player.CompletedRooms >= 3)
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

      return Monster;

    }

    private void PlayEncounterText(PlayerCharacter player, MonsterCharacter monster)
    {

      // Define a Dictionary to store descriptions for each monster
      var monsterDescriptions = new Dictionary<string, string>
      {
          { "Gremlin", "A small and mischievous creature lurks in the shadows." },
          { "Orc", "A hulking and fearsome orc stands before you, ready for battle." },
          { "Pesky Troll", "A massive, regenerating troll with a club confronts you." },
          { "Goblin", "A cunning goblin with a sharp blade prepares to strike." },
          { "Dragon", "A colossal dragon with scales as hard as steel looms over you, its fiery breath ready to incinerate everything." },
          { "Vampire", "A suave and mysterious vampire with sharp fangs approaches, his eyes glowing with hunger for your blood." },
          { "Werewolf", "A massive, feral werewolf, its fur bristling and claws extended, prepares to pounce." },
          { "Witch", "A cunning witch with a cackling laugh and a wicked coven of spells stands in your path, brewing mischief." },
          { "Ogre", "A monstrous ogre with immense strength and a giant club threatens to crush you." },
          { "Minotaur", "A formidable minotaur, part man and part bull, charges at you with its massive horns." },
          { "Skeleton", "A skeletal warrior, risen from the dead, wields a rusty sword and clatters menacingly." },
          { "Harpy", "A fierce harpy with razor-sharp talons and wings that can whip up storms swoops down to attack." },
          { "Chimera", "A nightmarish chimera, a fusion of lion, goat, and serpent, stands ready to unleash its deadly breath." },
          { "Goblin King", "A powerful and cunning goblin king, adorned with a crown, rules over his minions with authority." },
          { "Smaller Dragon", "A smaller but no less dangerous dragon awaits, ready to spit fire and claws at you." },
          { "Blob", "A grotesque, amorphous blob oozes towards you, its acidic touch melting everything in its path." },
          { "Netherlord Zorath", "The ground trembles as Netherlord Zorath,\nan otherworldly terror, emerges from the void.\nHis dark eyes pierce your soul, and his power is immeasurable." },
          { "Serpentix the Devourer", "Serpentix, a colossal serpent with jagged fangs and venomous breath,\nslithers forth with an insatiable hunger for destruction." },
          { "Molten Core Guardian", "The Molten Core Guardian, a living inferno of molten rock and searing flames,\nradiates intense heat and an aura of pure annihilation." },
          { "Abyssal Leviathan", "From the depths of the abyss, the Abyssal Leviathan rises,\nan ancient sea terror with jaws that can crush ships and a hunger for chaos." },

      };

      // Lambda expression that generates the description based on the monster's name
      Func<MonsterCharacter, string> generateMonsterDescription = (monster) =>
      {
        if (monsterDescriptions.TryGetValue(monster.Name, out var description))
        {
          return description;
        }
        return "A mysterious and powerful creature stands before you.";
      };

      Console.Clear();
      Console.WriteLine("As you cautiously step through the door, you find yourself in a vast chamber.");
      Console.WriteLine("The air is thick with tension as you notice shadows dancing across the walls.");
      Console.WriteLine(generateMonsterDescription(monster));
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
