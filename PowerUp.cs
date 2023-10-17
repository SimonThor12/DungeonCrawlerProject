namespace DungeonCrawlerProject
{
  class PowerUp : IItem
  {
    public string Name { get; set; }
    public PowerUp(string name)
    {
      Name = name;
    }

  }
}
