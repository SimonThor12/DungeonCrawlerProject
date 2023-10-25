namespace DungeonCrawlerProject
{
  public class BossMonsterWeaponCreator : IMonsterWeaponCreator
  {
    private readonly Random random = new Random();
    private string monstername;



    public IWeapon CreateWeapon(string bossname)
    {
      // Randomly generate a weapon name from the list of weapon names using the ItemFactory Pick method
      string weaponName = bossname; //<-- added string name implement later according to the boss name, it has unique weapon name
      // Randomly generate an item power from 1 to 10
      int itemPower = random.Next(50, 100);

      return new Weapon(weaponName, itemPower);
    }
  }
}
