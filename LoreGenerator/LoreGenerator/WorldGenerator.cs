using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoreGenerator
{
    /// <summary>
    /// Generates the world in which the story will take place.
    /// </summary>
    public class WorldGenerator
    {
        #region Properties

        public World World { get; set; }

        #endregion

        #region Members

        private static Random theRandom = new Random(DateTime.Now.ToString().GetHashCode());

        private NameGenerator theNameGen = new NameGenerator();

        #endregion

        #region Public Methods

        public World GenerateWorld()
        {
            World = new World();

            PrintStartMessage();
            GenerateBasicWorldInfo();
            GenerateContinents();
            GenerateContinentLandmarks();
            GenerateCreatures();
            GenerateCharacters();

            return World;
        }

        #endregion

        #region Private Methods

        private void PrintStartMessage()
        {
            Console.Out.WriteLine();
            Console.Out.WriteLine("//////////////////////////////////////");
            Console.Out.WriteLine("// Generating world");
            Console.Out.WriteLine("//////////////////////////////////////");
            Console.Out.WriteLine();
        }

        private void GenerateBasicWorldInfo()
        {
            World.Name = theNameGen.GenerateLocationName();
            Console.Out.WriteLine("World name is " + World.Name);
        }

        private void GenerateContinents()
        {
            World.Continents = new List<Continent>();
            int totalLandmass = 0;
            while (totalLandmass < Configuration.MIN_LANDMASS)
            {
                int landmass = theRandom.Next(Configuration.MIN_CONTINENT_SIZE, Configuration.MAX_CONTINENT_SIZE);
                totalLandmass += landmass;
                var continent = new Continent(theNameGen.GenerateLocationName(), landmass);
                World.Continents.Add(continent);
            }
            Console.Out.WriteLine("Generated " + World.Continents.Count + " continents:");
            foreach(Continent c in World.Continents)
            {
                Console.Out.WriteLine(c.ToString());
            }
        }

        private void GenerateContinentLandmarks()
        {
            foreach(Continent continent in World.Continents)
            {
                continent.GenerateLandmarks();
            }
        }

        private void GenerateCreatures()
        {
            foreach(Continent continent in World.Continents)
            {
                continent.GenerateCreatures();
            }
        }

        private void GenerateCharacters()
        {
            foreach (Continent continent in World.Continents)
            {
                continent.GenerateCharacters();
            }
        }

        #endregion
    }
}
