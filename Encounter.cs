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

        //Slowly lose strength gained from item over time
        if (playerTurn)
        {
          if (Player.Strength > 1)
          {
           Player.Strength = (int)(Player.Strength * 0.90);

           }
          Console.Clear();
          Console.WriteLine("It's your turn. What will you do? (1-3)");
          Console.WriteLine(Player.Name + " HP: " + Player.Health + " | " + Monster.Name + " HP: " + Monster.Health);
          Console.WriteLine("**************************");
          Console.WriteLine("|> 1. Attack            <|");
          Console.WriteLine("|> 2. Flee (10% chance) <|");
          Console.WriteLine("|> 3. Inventory         <|");
          Console.WriteLine("**************************");

          string input = Console.ReadLine();

          switch (input)
          {
            case "1":
              PlayerAttack();
              break;

            case "2":
              //try to flee from the encounter, with a small chance of success
              if (new Random().Next(1, 11) == 1)
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
              var inv = Player.personalInventory.GetEnumerator();
              int invNum = 1;
              while (inv.MoveNext())
              {
                Console.WriteLine(invNum + ": " + inv.Current.Name);
                invNum++;
              }
              Console.WriteLine("What do you want to use?");
              switch (Console.ReadLine())
              {
                case "1":
                  Player.personalInventory.GetItem(0).UseItem(Player);
                  Player.personalInventory.RemoveItem(Player.personalInventory.GetItem(0));
                  break;
                case "2":
                  Player.personalInventory.GetItem(1).UseItem(Player);
                  Player.personalInventory.RemoveItem(Player.personalInventory.GetItem(1));
                  break;
                case "3":
                  Player.personalInventory.GetItem(2).UseItem(Player);
                  Player.personalInventory.RemoveItem(Player.personalInventory.GetItem(2));
                  break;
                case "4":
                  Player.personalInventory.GetItem(3).UseItem(Player);
                  Player.personalInventory.RemoveItem(Player.personalInventory.GetItem(3));
                  break;
                case "5":
                  Player.personalInventory.GetItem(4).UseItem(Player);
                  Player.personalInventory.RemoveItem(Player.personalInventory.GetItem(4));
                  break;
                case "6":
                  Player.personalInventory.GetItem(5).UseItem(Player);
                  Player.personalInventory.RemoveItem(Player.personalInventory.GetItem(5));
                  break;
                case "7":
                  Player.personalInventory.GetItem(6).UseItem(Player);
                  Player.personalInventory.RemoveItem(Player.personalInventory.GetItem(6));
                  break;
                case "8":
                  Player.personalInventory.GetItem(7).UseItem(Player);
                  Player.personalInventory.RemoveItem(Player.personalInventory.GetItem(7));
                  break;
                case "9":
                  Player.personalInventory.GetItem(8).UseItem(Player);
                  Player.personalInventory.RemoveItem(Player.personalInventory.GetItem(8));
                  break;

              }
              break;

            default:
              Console.WriteLine("You fumble and flail your arms, to no use. Try again next time.");
              Console.ReadKey();
              break;
          }
        }
        else
        {
          MonsterAttack();
          Console.Clear();
        }

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
          //ska randomisa vapen man får, ej hårdkoda

          List<PowerUp> powerups = new List<PowerUp> {
            new PowerUp("Health Potion", new HealEffect(50)),
            new PowerUp("Strong Health Potion", new HealEffect(100)),
            new PowerUp("Divine Health Potion", new HealEffect(200)),
            new PowerUp("Strength Potion", new StrengthEffect(20)),
            new PowerUp("Strong Strength Potion", new StrengthEffect(40)),
            new PowerUp("Divine Strength Potion", new StrengthEffect(80)),
            new PowerUp("Devious Health Potion", new HealEffect(0)),
            new PowerUp("Devious Strength Potion", new StrengthEffect(0)),
            new PowerUp("Water bottle", new HealEffect(10)),
          };
          List<Weapon> weapons = new List<Weapon>
        {
            new Weapon("Dragonfang Blade", 40),
            new Weapon("Shadowstrike Dagger", 90),
            new Weapon("Mjölnir's Hammer", 50),
            new Weapon("Elven Longsword", 80),
            new Weapon("Obsidian Waraxe", 60),
            new Weapon("Serpent's Fang", 95),
            new Weapon("Holy Avenger", 100),
            new Weapon("Runeblade of Frost", 80),
            new Weapon("Thunderstrike Maul", 75),
            new Weapon("Orcish Cleaver", 85)
        };

          ItemFactory<Weapon> weaponFactory = new ItemFactory<Weapon>(weapons);
          ItemFactory<PowerUp> powerUpFactory = new ItemFactory<PowerUp>(powerups);

          var loot1 = powerUpFactory.Pick();
          var loot2 = powerUpFactory.Pick();
          var weapLoot = weaponFactory.Pick();

          Player.personalInventory.AddItem(loot1);
          TypeTextWithDelay("You have gained a " + loot1.Name + "!");
          Console.ReadKey();

          Player.personalInventory.AddItem(loot2);
          TypeTextWithDelay("You have gained a " + loot2.Name + "!");
          Console.ReadKey();

          if (Player.equipedWeapon.ItemPower < weapLoot.ItemPower)
          {
            Player.equipedWeapon = weapLoot;
            TypeTextWithDelay("You found a " + weapLoot.Name + " and equipped it!");
            Console.ReadKey();
          }
          else
          {
            TypeTextWithDelay("You found a " + weapLoot.Name + " but it was not as strong as your current weapon, so you leave it behind.");
            Console.ReadKey();
          }

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
      //make a list of weapons that the bosses can equip when they are created

      if (Player.CompletedRooms >= 10)
      {
        MonsterFactory = new BossMonsterFactory();
        Monster = MonsterFactory.CreateMonster();

      }
      else if (Player.CompletedRooms >= 7)
      {
        MonsterFactory = new HardMonsterFactory();
        Monster = MonsterFactory.CreateMonster();


      }
      else if (Player.CompletedRooms >= 3)
      {
        MonsterFactory = new MediumMonsterFactory();
        Monster = MonsterFactory.CreateMonster();
      }
      else
      {
        MonsterFactory = new EasyMonsterFactory();
        Monster = MonsterFactory.CreateMonster();
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
      TypeTextWithDelay(generateMonsterDescription(monster));
      TypeTextWithDelay($"Prepare for battle, {player.Name}!");
    }
    private void PlayerAttack()
    {
      int damage = Player.Attack();
      Console.WriteLine($"You attack the {Monster.Name} with {Player.equipedWeapon.Name} and deal {damage} damage!");
      Monster.Health -= damage;
      Console.WriteLine("Press any key to continue...");
      Console.ReadKey();
    }

    private void MonsterAttack()
    {
      int damage = Monster.Attack();
      Console.WriteLine($"The {Monster.Name} attacks you and deals {damage} damage!");
      Player.Health -= damage;
      Console.WriteLine("Press any key to continue...");
      Console.ReadKey();
    }
    public void TypeTextWithDelay(string text)
    {
      foreach (char c in text)
      {
        Console.Write(c);
        Thread.Sleep(30); // Adjust the sleep duration to control the typing speed
      }
      Console.WriteLine();

    }

  }
}
