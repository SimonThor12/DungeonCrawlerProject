namespace DungeonCrawlerProject
{
  public class StrengthEffect : IPowerUpEffect
  {
    public int StrengthAmount { get; set; }

    public StrengthEffect(int strengthAmount)
    {
      StrengthAmount = strengthAmount;
    }
    public void UsePowerUp(PlayerCharacter player)
    {
      player.Strength += StrengthAmount;
      Console.WriteLine($"You gained {StrengthAmount} strength!");
      Console.WriteLine("Press any key to continue...");
      Console.ReadKey();

    }
  }


}
