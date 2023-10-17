namespace DungeonCrawlerProject
{
  public class GameEngine
  {
    //make a list of monsters
    public List<ICharacter> Monsters { get; set; }
    //make a player
    public PlayerCharacter Player { get; set; }
    //make a list of items
    public List<IItem> Items { get; set; }
  }
}
