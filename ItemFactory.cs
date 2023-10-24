namespace DungeonCrawlerProject
{
  public class ItemFactory<T>
  {
    protected List<T> source;
    public ItemFactory(List<T> source)
    {
      this.source = source;
    }
    public List<T> PickRandom(int count, List<T> source)
    {
      List<T> result = new List<T>();

      for (int i = 0; i < count; i++)
      {
        Pick();
      }
      return result;
    }
    public T Pick()
    {
      Random random = new Random();
      int randomIndex = random.Next(0, source.Count);
      return source[randomIndex];
    }

  }
}
