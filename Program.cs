// See https://aka.ms/new-console-template for more information

using DungeonCrawlerProject;

Console.WriteLine("Hello, TEST!");

//Game engine = new GameEngine(); 

//userInterface UI = new userInterface();

//enigne.StartGame(UI);



//Instantiate a new achievement manager
AchievementManager achievementManager = new AchievementManager();

//Instantiate a new player
PlayerCharacter player = new PlayerCharacter("Player", 100, new NormalAttack(), achievementManager);

//Instantiate a new achievement observer



//Instantiate a new monster
MonsterCharacter monster = new MonsterCharacter("Monster", 100, new NormalAttack());

IItem item = new PowerUp("Fisk");

player.personalInventory.AddItem(item);
var enumerator = player.personalInventory.GetEnumerator();


//Handle the achievement completed event
player.SubscribeToAchievements(achievementManager);








