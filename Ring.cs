namespace DungeonCrawlerProject
{
  public class Ring : IItem
  {
    public string Name { get; set; }
    public int prop { get; set; }

    public Ring(string name, int healthprop)
    {
      Name = name;
      this.prop = healthprop;
    }

    public void UseItem(PlayerCharacter player)
    {
      player.MaxHealth += prop;
    }
  }
}
