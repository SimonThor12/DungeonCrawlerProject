namespace DungeonCrawlerProject
{
  //Denna interface är ett beteende som används av PowerUp-objekt för att utföra en effekt på en PlayerCharacter.
  //Det enkapsulerar alltså en effekt som ett PowerUp-objekt kan ha. Effekterna som implementerar detta interface är
  //t.ex. HealEffect är konkreta effekter som har respektive effekter på spelaren, där HealEffect ökar spelarens Health.
  //PowerUp-objektet använder sig av detta interface för att utföra en effekt på en PlayerCharacter.
  //Detta möjliggör att vi kan bestämma nya effekter(strategier) under runtime.
  public interface IPowerUpEffect
  {
    void UsePowerUp(PlayerCharacter player);
  }
}
