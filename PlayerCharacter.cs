namespace DungeonCrawlerProject
{
  public class PlayerCharacter : ICharacter
  {
    public string Name { get; set; }
    public int Health { get; set; }

    public int CompletedRooms = 0;

    public ICharacterAttackBevaviour AttackBevaviour { get; set; }

    public Inventory personalInventory = new Inventory();

    public List<Achievement> Achievements { get; } = new List<Achievement>();



    public PlayerCharacter(string name, int health, ICharacterAttackBevaviour attackBevaviour, AchievementManager achievementManager)
    {
      Name = name;
      Health = health;

    }
    //method that takes the attackbehaviour and the weapon and uses the attackbehaviour to attack with the weapon

    //event handling for sending information about achievements

    public event EventHandler<AchievementEventArgs> AchievementCompleted;
    public void AddAchievement(Achievement achievement)
    {
      Achievements.Add(achievement);
    }



    public void SubscribeToAchievements(AchievementManager achievementManager)
    {
      achievementManager.AchievementCompleted += HandleAchievementCompleted;
    }

    private void HandleAchievementCompleted(object sender, AchievementEventArgs e)
    {
      Achievement completedAchievement = e.CompletedAchievement;
      Console.WriteLine($"Achievement Unlocked: {completedAchievement.Description}");
      // Display achievement details or perform other related actions
    }
  }
}
