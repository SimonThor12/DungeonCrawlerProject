namespace DungeonCrawlerProject
{
  public interface IItem
  {
    public string Name { get; set; }

    public void UseItem(PlayerCharacter player);
  }
}
