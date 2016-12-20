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
            int randomRace = theRandom.Next(0, continent.Characters.Keys.Count);
            string race = "";
            List<Character> characters = new List<Character>();
            List<Couple> couples = new List<Couple>();
            int index = 0;
            foreach (KeyValuePair<string, List<Character>> raceChars in continent.Characters)
            {
                if (index == randomRace)
                {
                    race = raceChars.Key;
                    characters = raceChars.Value;
                    break;
                }
                index++;
            }
            foreach (KeyValuePair<string, List<Couple>> raceCouples in continent.Couples)
            {
                if (index == randomRace)
                {
                    race = raceCouples.Key;
                    couples = raceCouples.Value;
                    break;
                }
                index++;
            }
            string disasterName = theNameGen.GenerateNaturalDisasterName();
            int racePopulation = characters.Count;
            int actualDeathCount = Math.Min(randomDeathCount, racePopulation);

            Console.Out.WriteLine("The " + disasterName + " earthquake killed " + actualDeathCount + " of " + racePopulation + " characters of the " + race + " race");

            for (int i = 0; i < actualDeathCount; i++)
            {
                continent.KillRandomCharacter(race);
            }
        }

        #endregion
    }
}
