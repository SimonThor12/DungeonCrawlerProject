namespace DungeonCrawlerProject
{
  public class GameEngine
  {

    //make a player
    public PlayerCharacter currentPlayer { get; set; }
    private PlayerEvent<PlayerCharacter> playerEventDelegate;
    private Random rng = new Random();
    public GameEngine()
    {
<<<<<<< HEAD
      playerEventDelegate = GrantBonusItem;
      currentPlayer = new PlayerCharacter(100, new NormalAttack());
      // Assign the function to the delegate
=======
      playerEventDelegate = GrantBonusItem; 
>>>>>>> fdcdc4507193128f33ced57d6c377b26938857b1
    }

    //make a list of items
    public void StartGame()
    {
      Console.WriteLine("Create a new game? (y/n)");
      string input = Console.ReadLine()!.ToLower();
      if (input == "y")
      {
        Console.Clear();
        currentPlayer.PlayerLeveledUp += Player_OnLeveledUp!;
        TypeTextWithDelay("Welcome to the Monster Dungeon!");
        TypeTextWithDelay("What is your name?");

        currentPlayer.Name = GetPlayerName();
        Console.Clear();

        TypeTextWithDelay("In a realm shrouded in mystery, you awaken in a dimly lit chamber");
        TypeTextWithDelay("your memories a distant echo in the darkness.");
        TypeTextWithDelay("As your eyes adjust to the inky blackness, a faint whisper of magic stirs in the air,");
        TypeTextWithDelay("beckoning you to explore the enigmatic depths of this wondrous realm");
        Console.WriteLine("Press enter to Continue");
        Console.ReadKey();
        Console.Clear();

        TypeTextWithDelay("As you can not see or hear anything in the darkness, ");
        TypeTextWithDelay("you decide to randomly feel your way around the room");
        DotDelay();
        TypeTextWithDelay("You find a sturdy stick beside two small potions,\n" +
          "one yellow and one red.\n" +
          "You equip the stick and put the potions in a bag.");
        currentPlayer.equipedWeapon = new Weapon("Stick", 10);
        currentPlayer.personalInventory.AddItem(new PowerUp("Red Potion", new HealEffect(30)));
        currentPlayer.personalInventory.AddItem(new PowerUp("Yellow Potion", new StrengthEffect(10)));
        DotDelay();
        TypeTextWithDelay("Looking around you, You spot a door on one of the walls");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        Console.Clear();
        HandleUserDoorAction();

        Encounter encounter = new Encounter(currentPlayer);

        while (encounter.Player.Health > 0)
        {
          encounter.StartEncounter();

          // Generate immersive kill descriptions
          string[] roomDescriptions = {
        "As you triumph over the monstrous foe, the acrid smell of combat fills the chamber,\n" +
        "and you catch your breath. Another door appears!",
        "In the aftermath of the intense battle,\n" +
        "you notice the once flickering torches now casting steady light upon the room's battle-scarred walls.\n" +
        "Another door appears!",
        "After a fierce struggle, the room falls silent.\n" +
        "You can hear the faint echo of your footsteps\namidst the victorious silence. Another door appears!",
        "With a final swing, the formidable foe lies defeated.\n" +
        "The monster is no more...\nas you catch your breath another door appears!",
        "As the dust settles, you take in the sight of the vanquished enemy.\n" +
        "The room's treasures and secrets await your exploration. Another door appears!"
        };

          //take player health and add it to the local gamengine player health
          // Continue the adventure
          if (encounter.Player.Health > 0)
          {
            Random random = new Random();


            TypeTextWithDelay(roomDescriptions[new Random().Next(0, roomDescriptions.Length)]);
            if (random.Next(5) == 1)
            {
              OpenChest();
            }
            Console.ReadKey();

            HandleUserDoorAction();
            Console.Clear();
          }

        }
      }
      else if (input == "n")
      {
        Console.WriteLine("Thank you for playing our game!");
      }
      else
      {
        Console.WriteLine("Wrong input, try again!");
        StartGame();
      }
    }
    private void HandleUserDoorAction()
    {
      Console.Clear();
      TypeTextWithDelay($"You are standing infront of the door, with a bag and a {currentPlayer.equipedWeapon.Name}.");
      TypeTextWithDelay("What do you want to do? (hint: hit, open or use something)");

      string action = Console.ReadLine();


      if (action.ToLower().Trim() == "use inventory" || action.ToLower().Trim() == "use potion" || action.ToLower().Trim() == "open inventory" || action.ToLower().Trim() == "use bag" || action.ToLower().Trim() == "use the bag" || action.ToLower().Trim() == "open the bag" || action.ToLower().Trim() == "open bag")
      {
        TypeTextWithDelay("You open your inventory");
        UseInventory();
        HandleUserDoorAction();
      }
      else if (action.ToLower().Trim() == "hit" || action.ToLower().Trim() == "hit door" || action.ToLower().Trim() == "use weapon" || action.ToLower().Trim() == "hit the door" || action.ToLower().Trim() == "use weapon")
      {
        TypeTextWithDelay($"You hit with {currentPlayer.equipedWeapon.Name} in the door opening");

        if (currentPlayer.equipedWeapon.Name == "Stick")
        {
          TypeTextWithDelay("The stick breaks :(");
          currentPlayer.equipedWeapon = new Weapon("Broken stick", 2);
          Console.ReadKey();
          HandleUserDoorAction();
        }
        else if (currentPlayer.equipedWeapon.ItemPower >= 100)
        {
          DotDelay();
          TypeTextWithDelay("The door scatters by the force from your weapon!");
          DotDelay();
          Console.WriteLine("Door opened");
          Console.Clear();
        }
        else
        {
          TypeTextWithDelay("The strong hit creates an echo in the room, but nothing happens");
          Console.WriteLine("Press any key to continue");
          Console.ReadKey();

          HandleUserDoorAction();
        }
      }
      else if (action.ToLower().Trim() == "use door" || action.ToLower().Trim() == "open door" || action.ToLower().Trim() == "open the door" || action.ToLower().Trim() == "door open")
      {
        DotDelay();
        TypeTextWithDelay("Door opened");
        Console.ReadKey();
        Console.Clear();
      }
      else
      {
        TypeTextWithDelay("Not valid");
        Console.ReadKey();
        HandleUserDoorAction();
      }

      int eventChance = rng.Next(100);
      Console.WriteLine(eventChance);
      Console.ReadKey();

      if (eventChance > 90)
      {
        playerEventDelegate = GrantBonusItem;
        playerEventDelegate(currentPlayer);

        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
      }
      else if (eventChance < 10)
      {
        playerEventDelegate = EncounterMysteriousAlly;
        playerEventDelegate(currentPlayer);
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
      }
      else if (eventChance > 11 && eventChance < 21)
      {
        playerEventDelegate = GenerateWellOfHealth;
        playerEventDelegate(currentPlayer);
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
      }
      Console.Clear();
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
        Thread.Sleep(20);

      }
      soundManager.StopSound();
      Console.WriteLine();
    }
    public void DotDelay()
    {
      for (int i = 0; i < 3; i++)
      {
        if (Console.KeyAvailable)
        {
          ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(intercept: true);
        }
        Console.Write(".");
        Thread.Sleep(1000);
      }
      Console.WriteLine();
    }

    public string GetPlayerName()
    {
      string name = Console.ReadLine()!;

      if (name == null || name == "")
      {
        Console.WriteLine("Not valid name! Try again!");
        return GetPlayerName();
      }
      else
      {
        return name;
      }
    }

    public void GrantBonusItem(PlayerCharacter player)
    {
      TypeTextWithDelay("When you enter the room you find yourself infront of a bag.");
      TypeTextWithDelay("You open the bag and see something shiny inside the bag and decide to pick it up.");

      if (player.personalInventory.IsFull())
      {
        TypeTextWithDelay("However, your inventory is already full, and you can't pick up the shiny item.");
      }
      else
      {
        Console.WriteLine();
        player.personalInventory.AddItem(new PowerUp("Strong Health Potion", new HealEffect(50)));
        TypeTextWithDelay("You found a Strong Health potion and added it to your inventory.");
        DotDelay();
      }
      TypeTextWithDelay("But when you look up you see that you are no alone in the room.");
    }
    public void GenerateWellOfHealth(PlayerCharacter player)
    {
      TypeTextWithDelay("As you explore the area, you stumble upon a mysterious well of health.");
      TypeTextWithDelay("The well is adorned with ancient runes and glistening waters.");
      TypeTextWithDelay("Feeling a magical presence, you cautiously approach the well.");

      TypeTextWithDelay("You carefully slurp up some of the rejuvenating water from the well.");
      player.MaxHealth += 50;
      player.Health += 250;
      TypeTextWithDelay("You feel healthy and ready for action like never before!");

      TypeTextWithDelay("With the well of health behind you,\nyou continue your adventure, feeling the magical aura still resonating within.");

    }
    public void EncounterMysteriousAlly(PlayerCharacter player)
    {
      TypeTextWithDelay("A mysterious figure steps out of the shadows, observing you.");
      TypeTextWithDelay("\"You seem like you could use some help,\" the figure says.");

      if (player.personalInventory.IsFull())
      {
        TypeTextWithDelay("You tried to take the Mystic Elixir, but your inventory is full!");
        TypeTextWithDelay("The figure sighs, \"Perhaps another time then...\" and disappears into the shadows.");
      }
      else
      {
        TypeTextWithDelay("Without waiting for your response, they toss you a small object.");
        Console.WriteLine();
        player.personalInventory.AddItem(new PowerUp("Mystic Elixir", new StrengthEffect(60)));
        TypeTextWithDelay("You've received a Mystic Elixir that boosts your strength.");
        DotDelay();
        TypeTextWithDelay("The figure disappears as suddenly as they appeared, leaving you in wonder.");
        TypeTextWithDelay("but as you look around in the room you see that you are not alone.");
      }
    }
    private void UseInventory()
    {
      Console.WriteLine("Inventory:");
      if (currentPlayer.personalInventory.Items.Count == 0)
      {
        Console.WriteLine("Your inventory is empty.");
        DotDelay();
        return;
      }

      int invNum = 1;
      foreach (var item in currentPlayer.personalInventory.Items)
      {
        Console.WriteLine($"{invNum}: {item.Name}");
        invNum++;
      }

      Console.WriteLine("What do you want to use? Or press 'B' to go back.");

      string choice = Console.ReadLine().ToLower().Trim();

      if (choice == "b")
      {
        Console.WriteLine("You leave your inventory and go back to the door");
        DotDelay();
        Console.Clear();
        return;
      }

      if (int.TryParse(choice, out int itemNumber) && itemNumber >= 1 && itemNumber <= currentPlayer.personalInventory.Items.Count)
      {
        var selectedItem = currentPlayer.personalInventory.GetItem(itemNumber - 1);
        if (selectedItem != null)
        {
          TypeTextWithDelay("You used a potion.");
          selectedItem.UseItem(currentPlayer);
          currentPlayer.personalInventory.RemoveItem(selectedItem);
          Console.Clear();
          UseInventory();
        }
        else
        {
          Console.WriteLine("The selected item cannot be used.");
          UseInventory();
        }
      }
      else
      {
        Console.WriteLine("Invalid choice.");
        UseInventory(); // Call the UseInventory method again for another choice.
      }
    }

    public void OpenChest()
    {
      TypeTextWithDelay("After looking around your surroundings you spot a chest in the rubble!");
      TypeTextWithDelay("You walk over to the chest");
      TypeTextWithDelay("Press enter to open the chest, press 0 to walk away");
      ConsoleKeyInfo keyInfo = Console.ReadKey();
      if (keyInfo.Key == ConsoleKey.Enter)
      {
        ItemChest<IItem> chest = new PowerUpChest();
        ItemChest<IItem> chest2 = new RingChest();

        //Randomize what chest the player gets
        Random random = new Random();
        int chestNumber = random.Next(0, 5);
        if (chestNumber != 0)
        {

          var item = chest.GiveItem();
          TypeTextWithDelay($"You open the chest and find {item.Name} inside.");
          TypeTextWithDelay("You put it in your inventory");
          DotDelay();
          currentPlayer.personalInventory.AddItem(item);

        }
        else
        {

          if (currentPlayer.amountOfRings < 2)
          {
            var item2 = chest2.GiveItem();
            TypeTextWithDelay($"You open the chest and find {item2.Name} inside!");
            TypeTextWithDelay("You equip the ring");
            DotDelay();
            item2.UseItem(currentPlayer);
            currentPlayer.amountOfRings++;
          }
          else
          {
            var item2 = chest2.GiveItem();
            TypeTextWithDelay($"You open the chest and find {item2.Name} inside!");
            Console.WriteLine("Sadly your vanity stops you from equipping more rings,\n" +
              "so you leave it be.");

          }

        }
      }
      else if (keyInfo.Key == ConsoleKey.D0)
      {
        TypeTextWithDelay("You walk away from the chest");
      }
      else
      {
        TypeTextWithDelay("Wrong input, try again!");
        OpenChest();
      }
    }

    public void RestartGame(int health)
    {
      if (health <= 0)
      {
        TypeTextWithDelay("GAME OVER");
        Console.WriteLine("Do you want to restart the game? (y/n)");
        string input = Console.ReadLine().ToLower();
        if (input == "y")
        {
          Console.Clear();
          StartGame();
        }
        else if (input == "n")
        {
          Console.WriteLine("Thank you for playing our game!");
        }
        else
        {
          Console.WriteLine("Wrong input, try again!");
          RestartGame(health);
        }
      }
      else
      {
        Console.WriteLine("You won!");
        Console.WriteLine("Do you want to restart the game? (y/n)");
        string input = Console.ReadLine().ToLower();
        if (input == "y")
        {
          Console.Clear();
          StartGame();
        }
        else if (input == "n")
        {
          Console.WriteLine("Thank you for playing our game!");
        }
        else
        {
          Console.WriteLine("Wrong input, try again!");
          RestartGame(health);
        }
      }

    }
    /*
    KONCEPT: Observer pattern + events.
    HUR: Denna metod hanterar när en spelare nivåhöjs denna event-hanterare använder sig av observer-pattern.
     Där 'Player' är det subjekt som observeras.
     Denna metod fungerar som en observerare som svarar på förändringar (i det här fallet, en nivåhöjning).
     VARFÖR: Event ger möjlighet för andra delar av programmet att svara på en nivåhöjning.
     Det ger en lös koppling mellan olika delar av programmet. När en spelare höjer sin nivå
     agerar eventet som en notifiering som andra delar av koden kan prenumerera på och svara på utan att direkt påverka
     källkoden för 'Player'. Detta främjar moduläritet och underhållbarhet genom att olika delar av programmet kan svara på
     händelser på ett decentraliserat sätt. Det ger också en öppen arkitektur där nya funktioner enkelt kan skrivas utan
     att kräva stora ändringar i koden.
    */
    private void Player_OnLeveledUp(object sender, EventArgs e)
    {
      var player = sender as PlayerCharacter;

      if (player != null)
      {
        player.MaxHealth += 50;
        player.Health += 50;
        player.Strength += 10;
        Console.WriteLine("Congratulations! You leveled up!");
        Console.WriteLine("+50 Max Health");
        Console.WriteLine("+10 Strength");
        DotDelay();
      }
    }
    /* KONCEPT: Delegate och generic delegate
     HUR: Här har vi definierat en generisk delegat med namnet `PlayerEvent`.
     Delegaten representerar en metod som tar en parameter av typen `T` 
     och returnerar inget (`void`).
     VARFÖR: Genom att använda en generisk typ kan `PlayerEvent` fungera med olika datatyper, vilket gör det möjligt 
     att använda samma delegat för olika slags spelare eller karaktärer 
     i ett spel, snarare än att skapa en ny delegat för varje typ.
    */
    public delegate void PlayerEvent<T>(T player);

  }


}




