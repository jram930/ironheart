using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoreGenerator
{
    public abstract class Landmark
    {
        #region Properties

        public string Name { get; set; }

        public int Size { get; set; }

        #endregion

        #region Construction

        public Landmark(string name, int size)
        {
            Name = name;
            Size = size;
        }

        #endregion
    }
}
