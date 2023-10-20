namespace DungeonCrawlerProject
{
  public class Weapon : IWeapon
  {
    public string Name { get; set; }
    public int ItemPower { get; set; }

    public Weapon(string name, int itemPower)
    {
      Name = name;
      ItemPower = itemPower;
    }

    public void UseItem(PlayerCharacter player)
    {

    }
  }
}
