namespace DungeonCrawlerProject
{
  public class TalonSmashAttack : ICharacterAttackBehaviour<int>
  {
    public int Attack(ICharacter character)
    {
      Random random = new Random();
      int damage = character.equipedWeapon.ItemPower + random.Next(10, 40);
      return damage;
    }
  }
}