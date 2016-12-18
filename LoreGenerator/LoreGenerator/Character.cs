using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoreGenerator
{
    public class Character
    {
        #region Properties

        public string Race { get; set; }

        public string Name { get; set; }

        public bool Male { get; set; }

        public int Age { get; set; }

        #endregion

        #region Members

        private Random theRandom = new Random(DateTime.Now.ToString().GetHashCode());

        #endregion

        #region Construction

        public Character(string race, string name, int age = 0)
        {
            Race = race;
            Name = name;
            Age = age;

            Male = DetermineIfMale();
        }

        #endregion

        #region Private Methods

        private bool DetermineIfMale()
        {
            int chance = theRandom.Next(1, 101);

            if(chance < 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
