namespace DungeonCrawlerProject
{
  class Inventory : IInventory<IItem>
  {
    public int MaxInventorySize = 9;
    public List<IItem> Items { get; set; }

    public Inventory()
    {
      Items = new List<IItem>();
    }

    public void AddItem(IItem item)
    {
      // If the inventory is full, don't add the item
      if (Items.Count >= MaxInventorySize)
      {
        Console.WriteLine("Inventory is full");
        return;
      }
      Items.Add(item);

    }
    public void RemoveItem(IItem item)
    {
      //if the item is not in the inventory, don't remove it
      if (!Items.Contains(item))
      {
        Console.WriteLine("Item not found");
        return;
      }
      Items.Remove(item);
    }


    public void RemoveAll()
    {
      Items.Clear();
    }
    public void UseItem(IItem item)
    {
    }
  }
}
