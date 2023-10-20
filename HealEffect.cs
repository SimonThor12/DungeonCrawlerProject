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
      Console.WriteLine("You have been healed for " + HealAmount + " HP!");
    }
  }
}
