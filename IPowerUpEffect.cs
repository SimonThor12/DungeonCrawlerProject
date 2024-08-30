namespace DungeonCrawlerProject
{
  /*KONCEPT: Strategy pattern
  HUR: Denna interface representerar ett beteende som används av PowerUp-objekt för att utföra en effekt på en PlayerCharacter.
  Det enkapsulerar alltså en effekt som ett PowerUp-objekt kan ha. Effekterna som implementerar detta interface är
  t.ex. HealEffect är konkreta effekter som har respektive effekter på spelaren, där HealEffect ökar spelarens Health.
  PowerUp-objektet använder sig av detta interface för att utföra en effekt på en PlayerCharacter.
  VARFÖR: Detta möjliggör att vi kan bestämma nya effekter(strategier) under runtime. Det gör dessutom att vi kan 
  lägga till nya powerups utan att oroa oss för att något måste förändras när den används av spelaren. I och med att spelaren bara har
  en direkt relation med denna strategi och inte de konkreta klasserna som implementerar interfacet, så gör det koden mer anpassningsbar
  och möjliggör lättare påbyggnader i framtiden.
  */
  public interface IPowerUpEffect
  {
    void UsePowerUp(PlayerCharacter player);
  }
}
