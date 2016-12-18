using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoreGenerator
{
    public class Creature
    {
        #region Properties

        public string Name { get; set; }

        public Rarity Rarity { get; set; }

        #endregion

        #region Construction

        public Creature(string name, Rarity rarity)
        {
            Name = name;
            Rarity = rarity;
        }

        #endregion
    }
}
