namespace DungeonCrawlerProject
{
  public class NormalAttack : ICharacterAttackBehaviour
  {
    public void Attack(ICharacter attacker, ICharacter target)
    {
            int damage = 1;
            damage += attacker.Weapon.ItemPower;   //varför måste IItem ha itempower?
            target.Health -= damage;
            Console.WriteLine($"{attacker.Name} hit {target.Name} for {damage} damage" );
        }
  }



}
