namespace DungeonCrawlerProject
{
  public class GameEngine
  {

    //make a player
    public PlayerCharacter currentPlayer { get; set; }
    //make a list of items
    public void StartGame()
    {


      Console.WriteLine("Create a new game? (y/n)");
      string input = Console.ReadLine().ToLower();
      if (input == "y")
      {
        Console.Clear();
        currentPlayer = new PlayerCharacter(100, new NormalAttack());
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
        TypeTextWithDelay("You find a sturdy stick beside 2 small potions, one yellow and one red, and decide to pick them up");
        currentPlayer.equipedWeapon = new Weapon("Stick", 10);
        currentPlayer.personalInventory.AddItem(new PowerUp("Red Potion", new HealEffect(30)));
        currentPlayer.personalInventory.AddItem(new PowerUp("Yellow Potion", new StrengthEffect(10)));

        DotDelay();
        Console.WriteLine("You find a door on one of the walls");
        Console.WriteLine("");
        HandleUserDoorAction();

        Encounter encounter = new Encounter(currentPlayer);

        while (encounter.Player.Health > 0)
        {
          encounter.StartEncounter();

          // Generate immersive kill descriptions
          string[] roomDescriptions = {
        "As you triumph over the monstrous foe, the acrid smell of burnt scales fills the chamber, and you catch your breath. Another door appears!",
        "In the aftermath of the intense battle, you notice the once flickering torches now casting steady light upon the room's battle-scarred walls. Another door appears!",
        "After a fierce struggle, the room falls silent. You can hear the faint echo of your footsteps amidst the victorious silence. Another door appears!",
        "With a final swing, the formidable beast lies defeated. Its bloodied scales and fiery breath are no more. Another door appears!",
        "As the dust settles, you take in the sight of the vanquished enemy. The room's treasures and secrets await your exploration. Another door appears!"
        };

          Console.WriteLine();

          //take player health and add it to the local gamengine player health
          // Continue the adventure
          if (encounter.Player.Health > 0)
          {
            TypeTextWithDelay(roomDescriptions[new Random().Next(0, roomDescriptions.Length)]);
            Console.WriteLine("Press enter to continue...");
            HandleUserDoorAction();
            Console.ReadKey();
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
      Console.ReadKey();//remove
      Console.Clear();
      Console.WriteLine("What do you want to do?");
      string action = Console.ReadLine();
      if (action.ToLower().Trim() != "open" && action.ToLower().Trim() != "open door" && action.ToLower().Trim() != "hit" && action.ToLower().Trim() != "use inventory" && action.ToLower().Trim() != "use potion" && action.ToLower().Trim() != "open inventory")
      {
        Console.WriteLine("Try something else");
        HandleUserDoorAction();
      }
      else if (action.ToLower().Trim() == "use inventory" || action.ToLower().Trim() == "use potion" || action.ToLower().Trim() == "open inventory")
      {
        Console.WriteLine("You open your inventory");
        if (currentPlayer.personalInventory.Items.Count == 0)
        {
          Console.WriteLine("Your inventory is empty.");
          HandleUserDoorAction();
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
          HandleUserDoorAction();
          return;
        }

        if (int.TryParse(choice, out int itemNumber) && itemNumber >= 1 && itemNumber <= currentPlayer.personalInventory.Items.Count)
        {
          var selectedItem = currentPlayer.personalInventory.GetItem(itemNumber - 1);
          if (selectedItem != null)
          {
            selectedItem.UseItem(currentPlayer);
            currentPlayer.personalInventory.RemoveItem(selectedItem);
          }
          else
          {
            Console.WriteLine("The selected item cannot be used.");
          }
        }
        else
        {
          Console.WriteLine("Invalid choice.");
        }
        Console.WriteLine("You leave the inventory and go back to the door.");
        HandleUserDoorAction();
      }
      else if (action.ToLower().Trim() == "hit")
      {
        Console.WriteLine($"You hit with {currentPlayer.equipedWeapon.Name} in the door opening");
        Console.WriteLine("Nothing happens");
        HandleUserDoorAction();
      }

      else
      {
        DotDelay();
        Console.WriteLine("Door opened");
        Console.Clear();
      }
    }

    public void TypeTextWithDelay(string text)
    {
      string wavFilePath = "archivo (3).wav";
      SoundManager soundManager = new SoundManager(wavFilePath);

      soundManager.PlaySound();

      foreach (char c in text)
      {
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

    public string GetPlayerName()
    {
      string name = Console.ReadLine();

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
  }
}
