// See https://aka.ms/new-console-template for more information

using DungeonCrawlerProject;

/*
OBS!
Kommentarer för koncepten som ska täckas i projektet är i följande filer:
- Generic classes: ItemFactory.cs.
- Generic supertypes: ICharacterAttackBehaviour.cs.
- Type parameter constraints: Inventory.cs.
- Collections: Encounter.cs.
- Dependency injection: PlayerCharacter.cs.
- Composition over inheritance: PowerUp.cs.
- Strategy pattern: IPowerUpEffect.cs.
- Bridge pattern: IMonsterWeaponCreator.cs.
- Delegates: GameEngine.cs.
- Generic delegates: GameEngine.cs.
- Built in delegates: Encounter.cs.
- Lambdas: Encounter.cs.
- Observer pattern + Events GameEngine.cs.
- Iterator pattern + Enumerable/Enumerator: Inventory.cs.
- Yield and lazy evaluation: Inventory.cs.
- LINQ: Encounter.cs.
- Covariance: IMonsterWeaponCreator.cs.
- Contravariance IMonsterWeaponCreator.cs.
- Invariance: Encounter.cs.
*/

GameEngine gameEngine = new GameEngine();
gameEngine.StartGame();
gameEngine.RestartGame(gameEngine.currentPlayer.Health);




