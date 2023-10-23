namespace DungeonCrawlerProject
{
  public class HealEffect : IPowerUpEffect
  {
    public int HealAmount { get; set; }
    public HealEffect(int healAmount)
    {
      HealAmount = healAmount;
    }
    public void UsePowerUp(PlayerCharacter player)
    {
      player.Health += HealAmount;
      Console.WriteLine("You have gained " + HealAmount + " HP!");
      Console.WriteLine("Press any key to continue...");
      Console.ReadKey();
    }
  }
}
