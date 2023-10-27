namespace DungeonCrawlerProject
{
  public class MediumMonsterWeaponCreator : IMonsterWeaponCreator<IWeapon>
  {
    private readonly Random random = new Random();
    private readonly List<string> weaponNames = new List<string>
    {
        "Sword", "Sharp Axe", "Dagger", "Mace", "Staff", "Spear", "Hammer",
    };

    public IWeapon CreateWeapon(string name)
    {
      int itemPower = random.Next(5, 20);

      if (name == "Harpy")
      {
        string weaponName = "Talon";
        return new Weapon(weaponName, itemPower);

      }
      else
      {
        // Randomly generate a weapon name from the list of weapon names using the ItemFactory Pick method
        var itemFactory = new ItemFactory<string>(weaponNames);
        string weaponName = itemFactory.Pick();

        // Randomly generate an item power from 1 to 10

        return new Weapon(weaponName, itemPower);
      }

    }
  }

}
