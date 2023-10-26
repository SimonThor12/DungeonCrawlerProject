namespace DungeonCrawlerProject
{
  public interface ItemChest<out T> where T : IItem
  {
    T GiveItem();
  }


}
