namespace DungeonCrawlerProject
{
  public class EasyMonsterWeaponCreator
  {

    private readonly Random random = new Random();
    private readonly List<string> weaponNames = new List<string>
    {
        "Sword", "Rusty Axe", "Dagger", "Mace", "Staff", "Spear", "Hammer",
    };

    public IWeapon CreateWeapon(string name)
    {
      // Randomly generate a weapon name from the list of weapon names using the ItemFactory Pick method
      var itemFactory = new ItemFactory<string>(weaponNames);
      string weaponName = itemFactory.Pick();

      // Randomly generate an item power from 1 to 10
      int itemPower = random.Next(5, 12);

      return new Weapon(weaponName, itemPower);
    }

  }
}
