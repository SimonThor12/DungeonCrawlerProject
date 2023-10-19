namespace DungeonCrawlerProject
{
  //Interface for all characters in the game. 
  public interface ICharacter
  {
    string Name { get; set; }
    public int Health { get; set; }
    public ICharacterAttackBehaviour AttackBehaviour { get; set; }
 
    IItem equipedWeapon { get; set; }
  }

}
