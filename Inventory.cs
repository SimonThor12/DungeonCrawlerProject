using System.Collections;

namespace DungeonCrawlerProject
{
  //Inventory klassen implementerar IEnumerable för att kunna använda foreach loopar
  //och behandla samlingen av items som en lista. Detta är en bra idé eftersom vi
  //ville att Inventory skulle vara en samling av items. Detta är ett exempel på att 
  //använda IEnumerable och därav också Iterator pattern. 
  //När vi använder IEnumerable kan vi också nyttja yield return för att returnera
  //Items från listan på ett "lazy" vis. Det gör att de returneras en och en, eller "on the fly".

  //Vi använder här type parameter constraints för att säkerställa att T är en IItem. Detta gör att vi kan behålla typinformation om T när vi använder den i metoder i Inventory.
  public class Inventory<T> : IEnumerable<T> where T : IItem
  {
    public int MaxInventorySize = 9;
    public List<T> Items { get; set; }

    public Inventory()
    {
      Items = new List<T>();
    }

    public void AddItem(T item)
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

    public void RemoveItem(T item)
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


    public IEnumerator<T> GetEnumerator()
    {
      for (int i = 0; i < Items.Count; i++)
        if (Items[i] != null)
          yield return Items[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public T GetItem(int v)
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
