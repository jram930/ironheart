using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoreGenerator
{
    public class World
    {
        #region Properties

        public string Name { get; set; }

        public List<Continent> Continents {get; set;}

        #endregion

        #region Public Methods

        public int GetWorldPopulation()
        {
            int population = 0;

            foreach (Continent continent in Continents)
            {
                foreach (List<Character> characters in continent.Characters.Values)
                {
                    foreach(Character character in characters)
                    {
                        population++;
                    }
                }
            }

            return population;
        }

        #endregion
    }
}
