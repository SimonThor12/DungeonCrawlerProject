namespace DungeonCrawlerProject
{
  public class HardMonsterWeaponCreator : IMonsterWeaponCreator<IWeapon>
  {
    private readonly Random random = new Random();
    private readonly List<string> weaponNames = new List<string>
    {
         "Silver Sword", "Spiky Axe", "Dagger", "Mace", "Spear",
    };

    public IWeapon CreateWeapon(string name)
    {
      int itemPower = random.Next(15, 30);

      if (name == "Smaller Dragon")
      {
        string weaponName = "Fiery Breath";
        return new Weapon(weaponName, itemPower);

      }
      else if (name == "Chimera")
      {
        string weaponName = "Hard Venomous bite";
        return new Weapon(weaponName, itemPower);
      }
      else if (name == "Goblin King")
      {
        string weaponName = "Goblin's Bane";
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
