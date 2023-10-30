namespace DungeonCrawlerProject
{
  //Detta är en interface som är en abstraktion av ett beteende som används av MonsterCharacter-objekt för att skapa
  //ett vapen. Denna abstraction är kopplad till en MonsterFactory som är abstract. Detta är ett bridge pattern, då 2
  //abstraktioner kan utvecklas oberoende av varandra. Vi har olika WeaponCreators beroende på svårigheten på monstret.
  //Man skulle istället kunna tänka sig att alla vapen har ett specifikt "element", t ex, eld. Detta skulle vara ett
  //annat sätt att lätt kunna förändra spelet nu när vi har detta bridge pattern. Om vi i det exemplet skapade
  //"FireMonsterWeaponCreator" och "IceMonsterWeaponCreator" skulle vi kunna skapa olika vapen för olika monster. Detta
  //är ett exempel på hur bridge pattern kan användas för att lätt kunna förändra spelet utan att behöva bry oss om den
  //vänstra sidan av bridge pattern, dvs. i detta fallet, MonsterFactory. Om vi vill kan vi nu göra "Easy" monster som
  //har "HardMonsterWeaponCreator". Man kan tänka sig ett scenario där ett monster plockar upp ett bättre vapen under
  //fighten, vilket nu med detta mönster är möjligt under runtime. 

  //Här är även ett exempel på kovarians, då vi returnerar T i metoden CreateWeapon. T är därför kovariant, eftersom att allt som händer med T i gränssnittet är att den returneras.
  //
  //Vi använder inte kontravarians i vårt projekt, men om vi skulle haft behov av det så skulle man kunna tänka sig att det skulle ha varit här. Det skulle kunna vara så att vi ville ta in ett monster i IMonsterWeaponCreator för att skapa mer specifika monsterweapons. Då skulle vi ha satt en ny typparameter, t ex: TMonster med keywordet "in". Det skulle vara ett relevant framtida projekt för spelet, för att få mer engagerande spel, och mer dynamiska häftiga monster.


  public interface IMonsterWeaponCreator<out T> where T : IWeapon
  {
    public T CreateWeapon(string name);
  }
}
