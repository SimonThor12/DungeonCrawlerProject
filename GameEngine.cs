namespace DungeonCrawlerProject
{
  public class GameEngine
  {
    //make a list of monster
    public List<ICharacter> Monsters { get; set; }
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
        Console.WriteLine("Welcome to the Monster Dungeon!");
        Thread.SpinWait(50000000);
        Console.WriteLine("What is your name?");

        currentPlayer.Name = GetPlayerName();
        Console.Clear();

        Console.WriteLine("In a realm shrouded in mystery, you awaken in a dimly lit chamber");
        Console.WriteLine("your memories a distant echo in the darkness.");
        Console.WriteLine("As your eyes adjust to the inky blackness, a faint whisper of magic stirs in the air,");
        Console.WriteLine("beckoning you to explore the enigmatic depths of this wondrous realm");
        Console.ReadKey();
        Delay();
        Console.WriteLine("As you can not see or hear anything,");
        Console.WriteLine("you decide to randomly feel your way around the room");
        Delay();
        Console.WriteLine("You find a stick and decide to pick it up");
        currentPlayer.equipedWeapon = new Weapon("Stick", 10);
        Delay();
        Console.WriteLine("You find a door");
        HandleUserDoorAction();
        Delay();
        Console.ReadKey();

        //GameLoop(); //Hela spelloopen
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
        Console.WriteLine("This can not be done on door");
        HandleUserDoorAction();
      }
      else if (action.ToLower().Trim() == "hit")
      {
        Console.WriteLine("You hit with stick in the door opening");
        Console.WriteLine("Nothing happens");
        HandleUserDoorAction();
      }
      else
      {
        Console.WriteLine("Door opened");

      }

    }

    public void CreateWorld()
    {
      //STARTVÄRDEN
    }
    //public void GameLoop()
    //{
    //  while (Player.Health > 0)
    //  {
    //    InventoryManagement(); //här får man kolla och använda items
    //    Console.WriteLine("Enter the next room? (y/n");
    //    string input = Console.ReadLine().ToLower();
    //    if (input == "y")
    //    {
    //      GenerateRoom(); //här skapar vi rummet, monster, combatloopen och looten
    //    }
    //    else
    //    {
    //      Console.WriteLine("You dont have a choice, you enter the room anyways");
    //      GenerateRoom(); //här skapar vi rummet, monster, combatloopen och looten
    //    }

    //  }
    //  Console.WriteLine("You have died! Game Over!");
    //}

    public void Delay()
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
        Console.WriteLine("Try again!");
        return GetPlayerName();
      }
      else
      {
        return name;
      }
    }
  }
}
