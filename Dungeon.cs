namespace DungeonCrawlerProject
{
  public class Dungeon
  {
    //Eventuellt inte vara en lista?
    public List<Room> Rooms { get; set; }

    public Dungeon()
    {
      Rooms = new List<Room>();
    }
  }
}
