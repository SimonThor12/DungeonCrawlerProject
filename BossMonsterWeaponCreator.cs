namespace DungeonCrawlerProject
{
  public class BossMonsterWeaponCreator : IMonsterWeaponCreator<IWeapon>
  {
    private readonly Random random = new Random();
    public IWeapon CreateWeapon(string bossname)
    {
      // Randomly generate a weapon name from the list of weapon names using the ItemFactory Pick method
      int itemPower = random.Next(50, 100);
      if (bossname == "Netherlord Zorath")
      {
        return new Weapon("Never Ending Sword Of Nether", itemPower);
      }
      else if (bossname == "Serpentix the Devourer")
      {
        return new Weapon("Serpent's Fang", itemPower);
      }
      else if (bossname == "Molten Core Guardian")
      {
        return new Weapon("Huge Fiery Stone Pillar", itemPower);
      }
      else
      {
        return new Weapon("Abyssal Trident", itemPower);
      }
    }
  }
}
