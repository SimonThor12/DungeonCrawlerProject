namespace DungeonCrawlerProject
{
  public interface IWeapon : IItem
  {
    public int ItemPower { get; set; }

    public void UseItem(PlayerCharacter player);
  }
}
