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

        TypeTextWithDelay("As you can not see or hear anything in the darkness, ");
        TypeTextWithDelay("you decide to randomly feel your way around the room");
        DotDelay();
        TypeTextWithDelay("You find a sturdy stick beside 2 small potions, one yellow and one red, and decide to pick them up");
        currentPlayer.equipedWeapon = new Weapon("Stick", 10);
        currentPlayer.personalInventory.AddItem(new PowerUp("Red Potion", new HealEffect(30)));
        currentPlayer.personalInventory.AddItem(new PowerUp("Yellow Potion", new StrengthEffect(10)));

        DotDelay();
        Console.WriteLine("You find a door, what do you want to do?");
        HandleUserDoorAction();

        Encounter encounter = new Encounter(currentPlayer);

        while (currentPlayer.Health > 0)
        {
          encounter.StartEncounter();
          Console.WriteLine("After the room has been looted you find yourself staring at another door");  //random lore 
          HandleUserDoorAction();
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
      string action = Console.ReadLine();
      if (action.ToLower().Trim() != "open" && action.ToLower().Trim() != "open door" && action.ToLower().Trim() != "hit")
      {
        Console.WriteLine("Try something else");
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
      foreach (char c in text)
      {
        Console.Write(c);
        Thread.Sleep(30); // Adjust the sleep duration to control the typing speed
      }
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
