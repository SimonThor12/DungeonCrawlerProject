namespace DungeonCrawlerProject
{
  /* KONCEPT: generic supertype 
   HUR: Detta interface har bara en metod för att attackera och har generiska typen T som output.
   I implementationerna av detta interface har vi stängt supertypen eftersom de är icke-generiska subtyper.
   Vi säger därför att de icke-generiska attackbeteendena stänger supertypen genom att sätta T som int.
   VARFÖR: Vi skulle nu kunna använda detta för att attackera med en annan output i framtiden. 
   Om vi till exempel skulle vilja ha ett attackbeteende som returnerar en bool istället, 
   så skulle det vara möjligt eftersom T är generisk i supertypen. 
   Vi har i vårt projekt satt NormalAttack.cs som parametriserad över int, medan NoAttack.cs är parametriserad över bool. 
   Detta visar på hur flexibelt det kan vara med generiska supertyper.
  */
  public interface ICharacterAttackBehaviour<T>
  {
    public T Attack(ICharacter attacker);
  }
}
