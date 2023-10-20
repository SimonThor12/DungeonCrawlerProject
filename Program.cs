// See https://aka.ms/new-console-template for more information

using DungeonCrawlerProject;

//Game engine = new GameEngine(); 

//userInterface UI = new userInterface();

//enigne.StartGame(UI);

//Instantiate a new achievement observer

GameEngine gameEngine = new GameEngine();
gameEngine.StartGame();

//Instantiate a new monster
MonsterCharacter monster = new MonsterCharacter("Monster", 100, new NormalAttack());

IItem item = new PowerUp("Fisk");

