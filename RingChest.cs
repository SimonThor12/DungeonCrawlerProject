namespace DungeonCrawlerProject
{
  internal class RingChest : ItemChest<Ring>
  {
    public Ring GiveItem()
    {

      Random random = new Random();
      int randomEffect = random.Next(100, 401);
      return new Ring("Ring of Health", randomEffect);

    }
  }
}
