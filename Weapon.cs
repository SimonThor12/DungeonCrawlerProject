using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawlerProject
{
    public class Weapon : IWeapon
    {
        public string Name { get; set; }
        public int ItemPower { get; set; }
        
        public Weapon(string name, int itemPower)
        {
            Name = name;
            ItemPower = itemPower;
        }
    }
}
