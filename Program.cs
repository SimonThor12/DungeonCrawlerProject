// See https://aka.ms/new-console-template for more information

using DungeonCrawlerProject;

Console.WriteLine("Hello, TEST!");

//Game engine = new GameEngine(); 

//userInterface UI = new userInterface();

//enigne.StartGame(UI);



Inventory items = new Inventory();

IEnumerator<IItem> num = items.GetEnumerator();

items.AddItem(new PowerUp("health apple"));

//get the current value of the enumerator
num.Current;



