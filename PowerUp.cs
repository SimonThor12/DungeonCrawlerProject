namespace DungeonCrawlerProject
{
  class PowerUp : IItem
  {
    public string Name { get; set; }

    public IPowerUpEffect Effect { get; set; }
    public PowerUp(string name, IPowerUpEffect effect)
    {
      Name = name;
      Effect = effect;
    }

    public void UseItem(PlayerCharacter player)
    {
      Effect.UsePowerUp(player);
    }

    public IItem GetPowerUpItem(PlayerCharacter player)
    {
      return this;
    }

  }
}
