﻿namespace DungeonCrawlerProject
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
      bool combatChoiceSucess = false;
      bool encounterOver = false;
      bool playerTurn = true;
      // Create a monster based on the player's score 
      // (e.g., if the player's score is 10 or higher, create a boss monster)

      MonsterCharacter encounteredMonster = CreateMonsterForEncounter();
      Monster = encounteredMonster;

      PlayEncounterText(Player, Monster);
      Console.ReadKey();

      while (!encounterOver)
      {
        //Slowly lose strength gained from item over time
        if (playerTurn)
        {
          if (Player.Strength > 5)
          {
            if (Player.Strength > 100)
            {
              Player.Strength = (int)(Player.Strength * 0.60);
            }
            else if (Player.Strength > 50)
            {
              Player.Strength = (int)(Player.Strength * 0.75);
            }
            else
            {
              Player.Strength = (int)(Player.Strength * 0.90);
            }
          }

          Console.Clear();
          Console.WriteLine("It's your turn. What will you do? (1-3)");
          Console.WriteLine(Player.Name + " HP: " + Player.Health + "/" + Player.MaxHealth + " | " + Monster.Name + " HP: " + Monster.Health);
          Console.WriteLine("**************************");
          Console.WriteLine("|> 1. Attack            <|");
          Console.WriteLine("|> 2. Flee (10% chance) <|");
          Console.WriteLine("|> 3. Inventory         <|");
          Console.WriteLine("**************************");

          GetCombatChoice();

        }
        else
        {
          MonsterAttack();
          Console.Clear();
        }

        // Check if the encounter is over (e.g., player or monster health reaches zero)
        if (Player.Health <= 0)
        {
          TypeTextWithDelay("You have been defeated!");
          TypeTextWithDelay("Press any key to continue...");
          Console.ReadKey();
          Console.Clear();

          encounterOver = true;

        }
        else if (Monster.Health <= 0)
        {
          TypeTextWithDelay($"You have defeated the {Monster.Name}!");

          Player.DefeatMonster();   // här får man experience
          /*KONCEPT: Invarians.
            HUR: Dessa listor är ett exempel på en IList<T> som är en samling av objekt av typen T.
            T i IList<T> är inte kovariant eller kontravariant och är därför ett exempel på en invariant typ.
            VARFÖR: listor är en väldigt effektiv samling som kommer med inbyggda metoder i C#. Anledningen till att den är invariant
            i C# är främst för att vi kan både hämta och sätta element av typen T i en lista enligt definitionen av List i C#.
            Det tyder på att den är både kovariant och kontravariant. 
            Det bryter alltså mot statisk typ-säkerhet att ha List<T> som kovariant, eller kontravariant.
            Med andra ord så blir risken stor för runtime-exception när vi använder listor som att de vore 
            ko/kontra-varianta
            i C#.
          */
          List<PowerUp> powerups = new List<PowerUp> {
            new PowerUp("Health Potion", new HealEffect(50)),
            new PowerUp("Strong Health Potion", new HealEffect(750)),
            new PowerUp("Divine Health Potion", new HealEffect(150)),
            new PowerUp("Strength Potion", new StrengthEffect(20)),
            new PowerUp("Strong Strength Potion", new StrengthEffect(30)),
            new PowerUp("Divine Strength Potion", new StrengthEffect(50)),
            new PowerUp("Devious Health Potion", new HealEffect(5)),
            new PowerUp("Devious Strength Potion", new StrengthEffect(1)),
            new PowerUp("Water bottle", new HealEffect(10)),
          };
          List<Weapon> weapons = new List<Weapon>
{
    new Weapon("Iron Dagger", 20),
    new Weapon("Rusty Shortsword", 25),
    new Weapon("Steel Sword", 30),
    new Weapon("Silver Sabre", 35),
    new Weapon("Gold-Plated Rapier", 40),
    new Weapon("Dragonfang Blade", 45),

    new Weapon("Wooden Staff", 55),
    new Weapon("Enchanted Wand", 60),
    new Weapon("Shadowstrike Dagger", 65),
    new Weapon("Mystic Spear", 70),
    new Weapon("Elven Longsword", 75),
    new Weapon("Hard Hammer", 80),

    new Weapon("Firebrand Axe", 110),
    new Weapon("Ice-Infused Greatsword", 120),
    new Weapon("Thunderstrike Warhammer", 130),
    new Weapon("Sorcerer's Staff", 140),
    new Weapon("Venomous Dagger", 150),
    new Weapon("Darkblade Scythe", 160),

    new Weapon("Celestial Bow", 180),
    new Weapon("Ancient Runeblade", 190),
    new Weapon("Doomsday Halberd", 200),
    new Weapon("Divine Excalibur", 220),
    new Weapon("Eternal Staff", 230),
    new Weapon("Wrath of Doom", 250)
};

          ItemFactory<PowerUp> powerUpFactory = new ItemFactory<PowerUp>(powerups);
          ItemFactory<Weapon> weaponFactory = new ItemFactory<Weapon>(weapons);

          var loot1 = powerUpFactory.Pick();
          var loot2 = powerUpFactory.Pick();
          Random random = new Random();


          Player.personalInventory.AddItem(loot1);
          TypeTextWithDelay("You have gained a " + loot1.Name + "!");
          Console.ReadKey();


<<<<<<< HEAD
          if (random.Next(3) == 1)
          {
            Player.personalInventory.AddItem(loot2);
            TypeTextWithDelay("You have gained a " + loot2.Name + "!");
            Console.ReadKey();
          }
          //Här används LINQ för att filtrera ut vapen som är av rätt typ. Vi använder
          //Where() för att filtrera ut vapen som har en viss ItemPower, från en lista av vapen.
          //Vi använder också ToList() för att konvertera resultatet till en lista.
          //Detta gör koden mer läsbar och förenklar den.
=======
          /*KONCEPT: LINQ.
          HUR: Här används LINQ för att filtrera ut vapen som är av rätt typ. Vi använder
          Where() för att filtrera ut vapen som har en viss ItemPower, från en lista av vapen.
          Vi använder också ToList() för att konvertera resultatet till en lista.
          VARFÖR: Detta gör koden mer läsbar och förenklar den. LINQ är otroligt effektivt för att filtrera ur en samling
          eller databas. Det gör att kod som annars skulle vara jättelång och komplex, blir kort och lättskriven, samt lätt att 
          förstå. 
          */
>>>>>>> fdcdc4507193128f33ced57d6c377b26938857b1
          if (Player.CompletedRooms >= 10 && random.Next(1, 11) != 1)
          {
            IEnumerable<Weapon> tempList = weaponFactory.PickRandom(3).Where(w => w.ItemPower >= 180).ToList();

            //spelare väljer vilket vapen de vill ha
            PrintDroppedWeapons(tempList);
            EquipAsk(tempList);

          }
          else if (Player.CompletedRooms >= 7 && random.Next(1, 11) != 1)
          {
            IEnumerable<Weapon> tempList = weaponFactory.PickRandom(3).Where(w => w.ItemPower >= 80 && w.ItemPower <= 160).ToList();

            PrintDroppedWeapons(tempList);

            EquipAsk(tempList);
          }
          else if (Player.CompletedRooms >= 3 && random.Next(1, 11) != 1)
          {
            IEnumerable<Weapon> tempList = weaponFactory.PickRandom(3).Where(w => w.ItemPower >= 55 && w.ItemPower <= 80).ToList();
            PrintDroppedWeapons(tempList);
            EquipAsk(tempList);
          }
          else if (Player.CompletedRooms < 3 && random.Next(1, 11) != 1)
          {

            IEnumerable<Weapon> tempList = weaponFactory.PickRandom(3).Where(w => w.ItemPower >= 10 && w.ItemPower <= 45).ToList();
            PrintDroppedWeapons(tempList);
            EquipAsk(tempList);
          }

          encounterOver = true;
          Player.CompletedRooms++;
          Console.WriteLine("Encounter has ended. Press any key to continue...");

          Console.ReadKey();
          Console.Clear();

        }
        playerTurn = !playerTurn; // Switch turns between player and monster
      }

    }

    private MonsterCharacter CreateMonsterForEncounter()
    {

      if (Player.CompletedRooms >= 10)
      {
        MonsterFactory = new BossMonsterFactory(new BossMonsterWeaponCreator());
        Monster = MonsterFactory.CreateMonster();

      }
      else if (Player.CompletedRooms >= 7)
      {
        MonsterFactory = new HardMonsterFactory(new HardMonsterWeaponCreator());
        Monster = MonsterFactory.CreateMonster();


      }
      else if (Player.CompletedRooms >= 3)
      {
        MonsterFactory = new MediumMonsterFactory(new MediumMonsterWeaponCreator());
        Monster = MonsterFactory.CreateMonster();
      }
      else
      {
        MonsterFactory = new EasyMonsterFactory(new EasyMonsterWeaponCreator());
        Monster = MonsterFactory.CreateMonster();
      }
      return Monster;
    }
    private void PlayEncounterText(PlayerCharacter player, MonsterCharacter monster)
    {
      /* KONCEPT: Collections
      HUR: Vi definierar en Dictionary som är en samling av key-value pairs. Dictionary Implementerar ICollection<T>
      och kan därför använda metoder och egenskaper som återfinns i ICollection<T> (t.ex. Count). 
      VARFÖR: Användningen av en Dictionary möjliggör effektiv hantering av data genom att tilldela varje
      element en unik nyckel och koppla det till ett värde. Dessutom ger ICollection-implementeringen oss
      tillgång till gemensamma funktioner för hantering av kollektioner, som att räkna antalet element i samlingen
      (Count), vilket är användbart för styrning av programmet. 
      */
      */
      var monsterDescriptions = new Dictionary<string, string>
      {
          { "Gremlin", $"A small and mischievous creature lurks in the shadows\nand you see a {Monster.Name} wielding a {Monster.equipedWeapon.Name}." },
          { "Orc", $"A hulking and fearsome {Monster.Name} stands before\nyou wielding a {Monster.equipedWeapon.Name}, ready for battle." },
          { "Pesky Troll", $"A massive, regenerating troll with a {Monster.equipedWeapon.Name} confronts you." },
          { "Goblin", "A cunning goblin with a sharp blade prepares to strike." },
          { "Ogre", $"A monstrous ogre with immense strength and a giant {Monster.equipedWeapon.Name} threatens to crush you." },
          { "Minotaur", $"A formidable minotaur, part man and part bull, charges at you with its massive horns\nwielding a {Monster.equipedWeapon.Name}." },
          { "Skeleton", $"A skeletal warrior, risen from the dead, wields a {Monster.equipedWeapon.Name} and clatters menacingly." },
          { "Harpy", "A fierce harpy with razor-sharp talons and wings that can whip up storms swoops down to attack." },
          { "Chimera", "A nightmarish chimera, a fusion of lion, goat, and serpent,\nstands ready to unleash its deadly breath." },
          { "Goblin King", $"A powerful and cunning goblin king, adorned with a crown approaches,\nwielding a {Monster.equipedWeapon.Name}." },
          { "Smaller Dragon", "A smaller but no less dangerous dragon awaits, ready to spit fire and claws at you." },
          { "Blob", $"A grotesque, amorphous blob oozes towards you,\nits insides filled with {Monster.equipedWeapon.Name}s." },
          { "Netherlord Zorath", "The ground trembles as Netherlord Zorath,\nan otherworldly terror, emerges from the void.\nHis dark eyes pierce your soul, and his power is immeasurable." },
          { "Serpentix the Devourer", "Serpentix, a colossal serpent with jagged fangs and venomous breath,\nslithers forth with an insatiable hunger for destruction." },
          { "Molten Core Guardian", $"The Molten Core Guardian, a living inferno of molten rock and searing flames,\nradiates intense heat and an aura of pure annihilation. Holding The {Monster.equipedWeapon.Name}" },
          { "Abyssal Leviathan", "From the depths of the abyss, the Abyssal Leviathan rises wielding ,\nan ancient sea terror with jaws that can crush ships and a hunger for chaos." },
          { "Bandit", $"A cunning {Monster.Name} emerges from the shadows, wielding a {Monster.equipedWeapon.Name} and ready to rob you." },
          { "Dead Soldier", $"A dead {Monster.Name} in uniform confronts you, armed with a {Monster.equipedWeapon.Name}." },
          { "Thief", $"A sneaky {Monster.Name} lurks in the darkness, ready to steal your valuables with a {Monster.equipedWeapon.Name}." },
          { "Brigand", $"A menacing {Monster.Name} with a wild look in its eyes wields a {Monster.equipedWeapon.Name} and demands your treasure." },
          { "Mage Apprentice", $"A young {Monster.Name} with a pointed hat and a {Monster.equipedWeapon.Name} conjures magical spells with a mischievous grin." },
          { "Knight", $"A noble {Monster.Name} in shining armor charges at you with a {Monster.equipedWeapon.Name}, ready for a chivalrous battle." },
          { "Rogue", $"A rogue {Monster.Name} with stealthy movements and a {Monster.equipedWeapon.Name} prepares to strike from the shadows." },
          { "Assassin", $"A deadly {Monster.Name} with a poisoned {Monster.equipedWeapon.Name} moves with lethal precision, ready to eliminate its target." },
          { "Guardian", $"A fierce {Monster.Name} stands guard with a towering {Monster.equipedWeapon.Name}, determined to protect its territory." }

      };

      /* KONCEPT: built in delegates.
      HUR: Vi använder här inbyggda delegaten Func för att skapa en funktion som 
      tar in en MonsterCharacter och returnerar en string. 
      VARFÖR: Detta ökar läsbarheten och underhållbarheten i koden,
      samtidigt som det tillåter oss att utnyttja den inbyggda funktionaliteten
      hos delegater för att skapa dynamiska och återanvändbara funktioner. 
      */
      
      /*KONCEPT: Lambda.
      HUR: I detta fall har vi en Func-delegat med parametertypen MonsterCharacter och returtypen string, som refererar
      till ett lambda-uttryck. Lambda-funktionen tar emot en MonsterCharacter och returnerar
      en sträng. Den används här för att generera en beskrivning för en MonsterCharacter baserat på dess namn.
      VARFÖR: Vi använder oss av ett lambda-uttryck här för att det är en kortare och mer läsbar syntax.
      Det finns ingen mening med att göra denna metod icke-anonym eftersom den bara används här.
      */
      
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
      // Console.WriteLine("Press any key to continue..."); 
      // Console.ReadKey();
      DotDelayShort();
    }
    private void MonsterAttack()
    {
      int damage = Monster.Attack();
      Console.WriteLine($"The {Monster.Name} attacks you with the {Monster.equipedWeapon.Name} and deals {damage} damage!");
      Player.Health -= damage;
      //Console.ReadKey();
      DotDelay();
    }

    public void TypeTextWithDelay(string text)
    {
      string wavFilePath = "archivo (3).wav";
      SoundManager soundManager = new SoundManager(wavFilePath);

      soundManager.PlaySound();

      foreach (char c in text)
      {
        if (Console.KeyAvailable)
        {
          ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(intercept: true);
        }
        Console.Write(c);
        Thread.Sleep(20); // Adjust the delay in milliseconds (1000ms = 1 second)

      }
      soundManager.StopSound();
      Console.WriteLine();
    }


    public void DotDelay()

    {
      for (int i = 0; i < 3; i++)
      {
        Console.Write(".");
        Thread.Sleep(1000); // Adjust the delay in milliseconds (1000ms = 1 second)
      }
      Console.WriteLine();
    }
    public void DotDelayShort()
    {
      for (int i = 0; i < 3; i++)
      {
        if (Console.KeyAvailable)
        {
          ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(intercept: true);
        }
        Console.Write(".");
        Thread.Sleep(200); // Adjust the delay in milliseconds (1000ms = 1 second)
      }
      Console.WriteLine();
    }
    public void EquipAsk(IEnumerable<Weapon> tempList)
    {
      if (tempList.Count() == 0)
      {
        return;
      }
      else
      {
        TypeTextWithDelay("Do you want to equip? (input corresponding number, 0 for none of them)\n");
        string input = Console.ReadLine();
        switch (input)
        {
          case "1":
            Player.equipedWeapon = tempList.ElementAt(0);
            Console.WriteLine("Good Choice!");
            break;
          case "2":
            Player.equipedWeapon = tempList.ElementAt(1);
            Console.WriteLine("Good Choice!");
            break;
          case "3":
            Player.equipedWeapon = tempList.ElementAt(2);
            Console.WriteLine("Good Choice!");
            break;
          case "0":
            Console.WriteLine("You leave the pile.");
            break;
          default:
            Console.WriteLine("You can not do that, try again!");
            Console.ReadKey();
            EquipAsk(tempList);
            break;

        }
        Console.ReadKey();
      }


    }
    public void PrintDroppedWeapons(IEnumerable<Weapon> tempList)
    {
      int i = 1;

      //Make player choose what weapon they want to equip
      if (tempList.Count() == 0)
      {
        TypeTextWithDelay("The monster did not drop any weapons, but you got some potions a least...");
      }
      else
      {
        TypeTextWithDelay($"The monster dropped this as well:\n ");
        foreach (var weapLoot in tempList)
        {
          TypeTextWithDelay(i + ": " + weapLoot.Name + " with " + weapLoot.ItemPower + " power\n");
          i++;
        }

        Console.WriteLine($"This is your current weapon: {Player.equipedWeapon.Name}({Player.equipedWeapon.ItemPower})");
      }
    }

    public bool UseInventory()
    {
      var invEnumerator = Player.personalInventory.GetEnumerator();
      int invNum = 1;
      bool itemChosen = false; //change to correct!
      while (invEnumerator.MoveNext())
      {
        Console.WriteLine(invNum + ": " + invEnumerator.Current.Name);
        invNum++;
      }
      Console.WriteLine("What do you want to use?");

      switch (Console.ReadLine())
      {
        case "1":
          Player.personalInventory.GetItem(0).UseItem(Player);
          Player.personalInventory.RemoveItem(Player.personalInventory.GetItem(0));
          itemChosen = true;
          break;
        case "2":
          Player.personalInventory.GetItem(1).UseItem(Player);
          Player.personalInventory.RemoveItem(Player.personalInventory.GetItem(1));
          itemChosen = true;
          break;
        case "3":
          Player.personalInventory.GetItem(2).UseItem(Player);
          Player.personalInventory.RemoveItem(Player.personalInventory.GetItem(2));
          itemChosen = true;
          break;
        case "4":
          Player.personalInventory.GetItem(3).UseItem(Player);
          Player.personalInventory.RemoveItem(Player.personalInventory.GetItem(3));
          itemChosen = true;

          break;
        case "5":
          Player.personalInventory.GetItem(4).UseItem(Player);
          Player.personalInventory.RemoveItem(Player.personalInventory.GetItem(4));
          itemChosen = true;

          break;
        case "6":
          Player.personalInventory.GetItem(5).UseItem(Player);
          Player.personalInventory.RemoveItem(Player.personalInventory.GetItem(5));
          itemChosen = true;

          break;
        case "7":
          Player.personalInventory.GetItem(6).UseItem(Player);
          Player.personalInventory.RemoveItem(Player.personalInventory.GetItem(6));
          itemChosen = true;

          break;
        case "8":
          Player.personalInventory.GetItem(7).UseItem(Player);
          Player.personalInventory.RemoveItem(Player.personalInventory.GetItem(7));
          itemChosen = true;

          break;
        case "9":
          Player.personalInventory.GetItem(8).UseItem(Player);
          Player.personalInventory.RemoveItem(Player.personalInventory.GetItem(8));
          itemChosen = true;

          break;
        default:
          Console.WriteLine("You leave your inventory");
          break;
      }
      return itemChosen;
    }

    public void GetCombatChoice()
    {
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
            break;
          }
          else
          {
            Console.WriteLine("You failed to flee from the encounter!");
            break;
          }

        case "3":
          Console.WriteLine("You open your inventory");
          UseInventory();
          break;

        default:
          Console.WriteLine("Not a valid input, try again!");
          //Redo the switch statement
          GetCombatChoice();
          Console.ReadKey();
          break;
      }
    }
  }

}
