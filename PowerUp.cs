namespace DungeonCrawlerProject
{
  /* KONCEPT: composition over inheritance.
  HUR: Vi har här en powerup klass som har ett beteende som är en IPowerUpEffect. 
  IPowerUpEffect används av PowerUp-objektet för att utföra en effekt på en PlayerCharacter. 
  VARFÖR: det är sällan en bra idé att lösa arv med mer arv. Ett alternativ är att vi kunde ha haft arv, där 
  varje olika powerup ärver från PowerUp som basklass. Detta kan dock vara ett problem om vi vill skapa nya klasser av 
  powerups som inte faller under samma kontrakt som PowerUp. Då måste vi skapa en ny basklass för dessa powerups. Detta
  är ofta en ond cirkel av arv.
  */
  public class PowerUp : IItem
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
