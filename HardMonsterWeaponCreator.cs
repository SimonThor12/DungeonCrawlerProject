namespace DungeonCrawlerProject
{
  public class HardMonsterWeaponCreator : IMonsterWeaponCreator
  {
    private readonly Random random = new Random();
    private readonly List<string> weaponNames = new List<string>
    {
        "Sword", "Axe", "Bow", "Dagger", "Mace", "Staff", "Spear", "Hammer", "Wand", "Crossbow"
    };

    public IWeapon CreateWeapon(string name)//<-- Added parameter finish later
    {
      // Randomly generate a weapon name from the list of weapon names using the ItemFactory Pick method
      var itemFactory = new ItemFactory<string>(weaponNames);
      string weaponName = itemFactory.Pick();

      // Randomly generate an item power from 1 to 10
      int itemPower = random.Next(15, 30);

      return new Weapon(weaponName, itemPower);
    }
  }
}
