namespace DungeonCrawlerProject
{
  //KONCEPT: Generic Classes
  //HUR: ItemFactory klassen är en generisk klass som tar emot en lista av ett visst objekt, med typ-parameter 'T'.
  //VARFÖR: Detta gör att det går att arbeta med olika typer av listor, t.ex. en lista av PowerUp-objekt eller en lista av 
  //Weapon-objekt. Vi kan alltså använda samma klass-definition för listor av arbiträrt innehåll.
  public class ItemFactory<T>
  {
    protected List<T> source;
    public ItemFactory(List<T> source)
    {
      this.source = source;
    }
    public List<T> PickRandom(int count)
    {
      List<T> result = new List<T>();

      for (int i = 0; i < count; i++)
      {
        result.Add(Pick());
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
