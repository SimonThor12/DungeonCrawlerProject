namespace DungeonCrawlerProject
{
  //Interface for all characters in the game. 
  public interface ICharacter
  {
    string Name { get; set; }
    public int Health { get; set; }
    public ICharacterAttackBehaviour<int> AttackBehaviour { get; set; }
    IWeapon equipedWeapon { get; set; }

    public int Strength { get; set; }
  }

}
