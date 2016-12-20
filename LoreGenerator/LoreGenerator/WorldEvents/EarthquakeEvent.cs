using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoreGenerator
{
    public class EarthquakeEvent : IWorldEvent
    {
        #region Members

        private static Random theRandom = new Random(DateTime.Now.ToString().GetHashCode());

        private NameGenerator theNameGen = new NameGenerator();

        #endregion

        #region IWorldEvent

        public void ActOnWorld(World world)
        {
            int randomContinent = theRandom.Next(0, world.Continents.Count);
            Continent continent = world.Continents[randomContinent];
            int randomDeathCount = theRandom.Next(Configuration.MIN_KILLED_EARTHQUAKE, Configuration.MAX_KILLED_EARTHQUAKE + 1);
            int randomNationality = theRandom.Next(0, continent.LiveCharacters.Keys.Count);
            string nationality = "";
            List<Character> characters = new List<Character>();
            List<Couple> couples = new List<Couple>();
            int index = 0;
            foreach (KeyValuePair<string, List<Character>> nationalityChars in continent.LiveCharacters)
            {
                if (index == randomNationality)
                {
                    nationality = nationalityChars.Key;
                    characters = nationalityChars.Value;
                    break;
                }
                index++;
            }
            foreach (KeyValuePair<string, List<Couple>> nationalityCouples in continent.Couples)
            {
                if (index == randomNationality)
                {
                    nationality = nationalityCouples.Key;
                    couples = nationalityCouples.Value;
                    break;
                }
                index++;
            }
            string disasterName = theNameGen.GenerateNaturalDisasterName();
            int natPopulation = characters.Count;
            int actualDeathCount = Math.Min(randomDeathCount, natPopulation);

            Console.Out.WriteLine("The " + disasterName + " earthquake killed " + actualDeathCount + " of " + natPopulation + " characters of the " + nationality + " nation");

            for (int i = 0; i < actualDeathCount; i++)
            {
                continent.KillRandomCharacter(nationality);
            }
        }

        #endregion
    }
}
