namespace DungeonCrawlerProject
{
  public class PowerUpChest : ItemChest<PowerUp>
  {
    public PowerUp GiveItem()
    {
      Random random = new Random();
      int randomPowerUp = random.Next(0, 2);
      int randomEffect = random.Next(10, 100);
      switch (randomPowerUp)
      {
        case 0:
          return new PowerUp("Mysterious Strength Potion", new StrengthEffect(randomEffect));
        case 1:
          return new PowerUp("Mysterious Health Potion", new HealEffect(randomEffect));
        default:
          return new PowerUp("Mysterious Health Potion", new HealEffect(randomEffect));

      }

    }

  }
}

