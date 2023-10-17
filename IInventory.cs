namespace DungeonCrawlerProject
{
  interface IInventory<IItem>
  {
    List<IItem> Items { get; set; }
    void AddItem(IItem item);
    void RemoveItem(IItem item);
    void UseItem(IItem item);
  }
}
