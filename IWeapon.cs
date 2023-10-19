using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawlerProject
{
    public interface IWeapon : IItem
    {
        int ItemPower { get; set; }
    }
}
