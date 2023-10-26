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
      if (player.MaxHealth < player.Health + HealAmount)
      {
        player.Health = player.MaxHealth;
        Console.WriteLine("You have gained " + HealAmount + " HP!");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        return;
      }
      else
      {
        player.Health += HealAmount;
        Console.WriteLine("You have gained " + HealAmount + " HP!");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        return;

      }

    }
  }
}
