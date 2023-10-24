// See https://aka.ms/new-console-template for more information

using DungeonCrawlerProject;

//Game engine = new GameEngine(); 

//userInterface UI = new userInterface();

//enigne.StartGame(UI);

//Instantiate a new achievement observer

GameEngine gameEngine = new GameEngine();
gameEngine.CharacterTyped += c => Console.Beep(1000, 100);
gameEngine.StartGame();




