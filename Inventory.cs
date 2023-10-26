using System.Collections;

namespace DungeonCrawlerProject
{
    //Inventory klassen implementerar IEnumerable för att kunna använda foreach loopar
    //och behandla samlingen av items som en lista. Detta är en bra idé eftersom vi
    //ville att Inventory skulle vara en samling av items. Detta är ett exempel på att 
    //använda IEnumerable och därav också Iterator pattern. 
    //När vi använder IEnumerable kan vi också nyttja yield return för att returnera
    //Items från listan på ett "lazy" vis. Det gör att de returneras en och en, eller "on the fly".
    public class Inventory<IItem> : IEnumerable<IItem>
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
        public bool IsFull()
        {
            return Items.Count >= MaxInventorySize;
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


    public IEnumerator<IItem> GetEnumerator()
    {
      for (int i = 0; i < Items.Count; i++)
        if (Items[i] != null)
          yield return Items[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IItem GetItem(int v)
    {
      if (v >= Items.Count)
      {
        v = Items.Count - 1;
        return GetItem(v);
      }
      else
        return Items[v];
    }
  }
}
