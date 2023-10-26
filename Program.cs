// See https://aka.ms/new-console-template for more information

using DungeonCrawlerProject;

//OBS!
//Kommentarer för koncepten som ska täckas i projektet är i följande filer på följande rader:
//- Generic classes: ItemFactory.cs, rad 3-5.
//- Generic supertypes: 
//- Type parameter constraints:
//- Collections: Encounter.cs, rad 287.
//- Dependency injection: PlayerCharacter.cs, rad 15-18.
//- Composition over inheritance: PowerUp.cs, rad 3-8.
//- Strategy pattern: IPowerUpEffect.cs, rad 3-7.
//- Bridge pattern: 
//- Delegates
//- Generic delegates
//- Built in delegates: Encounter.cs, rad 313-314.
//- Multicast delegates
//- Lambdas: Encounter: rad 315-316.
//- Observer pattern + Events
//- Iterator pattern + Enumerable/Enumerator: Inventory.cs, rad 3-8.
//- Yield and lazy evaluation: Inventory.cs, rad 8-10.
//- LINQ: Encounter.cs, rad 204-207 
//- Covariance
//- Contravariance
//- Invariance
//- Variant Classes
//- Variant delegates
//- Variant generic delegates
//- Variant generic interfaces

GameEngine gameEngine = new GameEngine();
gameEngine.StartGame();
gameEngine.RestartGame(gameEngine.currentPlayer.Health);




