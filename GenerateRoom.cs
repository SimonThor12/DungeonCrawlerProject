//namespace DungeonCrawlerProject
//{
//  private void GenerateRoom()
//  {
//    int roomNumber = 0;
//    roomNumber++;

//    Console.WriteLine($"A wild {monster.Name} appears!");

//    bool combat = true;

//    while (combat)
//    {
//      Console.WriteLine($"{PlayerCharacter.Name} HP: {PlayerCharacter.Health} | {monster.Name} HP: {monster.Health}");
//      Console.WriteLine($"press '1' to attack {monster.Name} ");
//      string choice = Console.ReadLine();

//      switch (choice)
//      {
//        case "1":
//          PlayerCharacter.AttackBehaviour.Attack(PlayerCharacter, monster);
//          if (monster.Health <= 0)
//          {
//            Console.WriteLine($"{monster.Name} is defeated!");
//            combat = false;
//            continue;
//          }

//          monster.AttackBehaviour.Attack(monster, PlayerCharacter);
//          if (Player.Health <= 0)
//          {
//            Console.WriteLine($"{PlayerCharacter.Name} has been defeated!");
//            combat = false;
//          }
//          break;
//        default:
//          Console.WriteLine("You should attack!");
//          break;
//      }
//    }
//  }

//}
