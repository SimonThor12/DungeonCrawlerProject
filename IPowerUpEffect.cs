namespace DungeonCrawlerProject
{
  //The powerup has an effect that is used on the player when the powerup is used.
  //This is the interface for that effect. 
  public interface IPowerUpEffect
  {
    void UsePowerUp(PlayerCharacter player);
  }
}
