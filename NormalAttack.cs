namespace DungeonCrawlerProject
{
  public class NormalAttack : ICharacterAttackBehaviour
  {
    public void Attack(ICharacter attacker, ICharacter target)
    {
      int damage = 1;
      damage += 5; // dynamic later: attacker.Weapon.ItemPower; 
      target.Health -= damage;
      Console.WriteLine($"{attacker.Name} hit {target.Name} for {damage} damage");
    }
  }



}
