namespace DungeonCrawlerProject
{
  public class GameEngine
  {
    //make a list of monster
    public List<ICharacter> Monsters { get; set; }
    //make a player
    public PlayerCharacter Player { get; set; }
    //make a list of items
    public List<IItem> Items { get; set; }

    public void StartGame()
    {
            Console.WriteLine("Create a new game? (y/n");
         string input = Console.ReadLine().ToLower();
         if (input == "y")
            {
                CreateWorld(); //VI BEHÖVER DENNA FUNKTION
                GameLoop(); //Hela spelloopen
            }
         else
            {
                Console.WriteLine("Thank you for playing our game!");
            }
    }
    public void CreateWorld()
    {
         //STARTVÄRDEN
    }
    public void GameLoop()
    {
        while (Player.Health > 0)
        {
                InventoryManagement(); //här får man kolla och använda items
                Console.WriteLine("Enter the next room? (y/n");
                string input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    GenerateRoom(); //här skapar vi rummet, monster, combatloopen och looten
                }
                else
                {
                    Console.WriteLine("You dont have a choice, you enter the room anyways");
                    GenerateRoom(); //här skapar vi rummet, monster, combatloopen och looten
                }
                
        }
            Console.WriteLine("You have died! Game Over!");
    }
  }
}
