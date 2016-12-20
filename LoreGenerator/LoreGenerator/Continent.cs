using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoreGenerator
{
    public class Continent
    {
        #region Properties

        public string Name { get; set; }

        public int Size { get; set; }

        public List<Landmark> Landmarks { get; set; }

        public Dictionary<string, List<Creature>> Creatures { get; set; }

        public Dictionary<string, List<Character>> Characters { get; set; }

        public Dictionary<string, List<Couple>> Couples { get; set; }

        #endregion

        #region Members

        private static Random theRandom = new Random(DateTime.Now.ToString().GetHashCode());

        private NameGenerator theNameGen = new NameGenerator();

        #endregion

        #region Construction

        public Continent(string name, int size)
        {
            Name = name;
            Size = size;
        }

        #endregion

        #region Public Methods

        public void GenerateLandmarks()
        {
            Console.Out.WriteLine("Generating landmarks for continent: " + Name);
            Landmarks = new List<Landmark>();
            int remainingSpace = Size;
            bool cityCreated = false;
            while (remainingSpace > 0)
            {
                int possibleSize = Configuration.MAX_LANDMARK_SIZE;
                if (remainingSpace < Configuration.MAX_LANDMARK_SIZE)
                {
                    possibleSize = remainingSpace;
                }
                int landmarkSize = theRandom.Next(1, possibleSize + 1);
                if (Configuration.FORCE_CITY_ON_EACH_CONTINENT && !cityCreated)
                {
                    Landmarks.Add(LandmarkFactory.CreateCity(theNameGen.GenerateLocationName(), landmarkSize));
                    cityCreated = true;
                }
                else
                {
                    Landmarks.Add(LandmarkFactory.CreateLandmark(theNameGen.GenerateLocationName(), landmarkSize));
                }
                remainingSpace -= landmarkSize;
            }
        }

        public void GenerateCreatures()
        {
            Console.Out.WriteLine("Generating creatures for continent: " + Name);
            Creatures = new Dictionary<string, List<Creature>>();
            int numCreatureTypes = theRandom.Next(Configuration.MIN_CREATURES_PER_CONTINENT, Configuration.MAX_CREATURES_PER_CONTINENT + 1);
            for (int i = 0; i < numCreatureTypes; i++)
            {
                string creatureName = theNameGen.GenerateCreatureName();
                int numCreatures = theRandom.Next(Configuration.MIN_CREATURE_COUNT, Configuration.MAX_CREATURE_COUNT + 1);
                Rarity rarity = Rarity.COMMON;
                if (numCreatures < Configuration.CREATURE_RARITY_UNCOMMON)
                {
                    rarity = Rarity.UNCOMMON;
                }
                if (numCreatures < Configuration.CREATURE_RARITY_RARE)
                {
                    rarity = Rarity.RARE;
                }
                if (numCreatures < Configuration.CREATURE_RARITY_LEGENDARY)
                {
                    rarity = Rarity.LEGENDARY;
                }
                var creatureDesc = new Creature(creatureName, rarity);
                Creatures.Add(creatureName, new List<Creature>());
                for (int j = 0; j < numCreatures; j++)
                {
                    Creatures[creatureName].Add(new Creature(creatureName, rarity));
                }
                Console.Out.WriteLine("Generated " + numCreatures + " " + creatureName + " creatures of rarity " + rarity + " on the continent " + Name);
            }
        }

        public void GenerateCharacters()
        {
            Console.Out.WriteLine("Generating characters for continent: " + Name);
            Characters = new Dictionary<string, List<Character>>();
            int numRaces = theRandom.Next(Configuration.MIN_RACE_COUNT, Configuration.MAX_RACE_COUNT + 1);
            for (int i = 0; i < numRaces; i++)
            {
                string raceName = theNameGen.GenerateRaceName();
                Characters.Add(raceName, new List<Character>());
                int numCharacters = theRandom.Next(Configuration.MIN_POPULATION_COUNT, Configuration.MAX_POPULATION_COUNT);
                for (int j = 0; j < numCharacters; j++)
                {
                    string characterName = theNameGen.GenerateCharacterName();
                    int age = theRandom.Next(1, Configuration.MAX_CHARACTER_AGE + 1);
                    var character = new Character(raceName, characterName, age);
                    Characters[raceName].Add(character);
                }
                Console.WriteLine("Generated " + numCharacters + " characters of the race " + raceName + " on the continent " + Name);
            }
        }

        public void AddCouple(string race, Couple couple)
        {
            if (Couples == null)
            {
                Couples = new Dictionary<string, List<Couple>>();
            }

            if (!Couples.ContainsKey(race))
            {
                Couples.Add(race, new List<Couple>());
            }

            Couples[race].Add(couple);
        }

        public Character KillRandomCharacter(string race)
        {
            int randomDeath = theRandom.Next(0, Characters[race].Count);
            Character killedChar = Characters[race][randomDeath];
            KillCharacter(race, killedChar);
            return killedChar;
        }

        public void KillCharacter(string race, Character character)
        {
            // Handle marriage.
            int index = 0;
            if (character.IsMarried)
            {
                foreach (Couple couple in Couples[race])
                {
                    if (couple.Husband.Name == character.Name && couple.Husband.Age == character.Age)
                    {
                        couple.Wife.IsMarried = false;
                        couple.Wife.Spouse = null;
                        break;
                    }
                    else if (couple.Wife.Name == character.Name && couple.Wife.Age == character.Age)
                    {
                        couple.Husband.IsMarried = false;
                        couple.Husband.Spouse = null;
                        break;
                    }
                    index++;
                }

                if(index < Couples[race].Count)
                {
                    Couples[race].RemoveAt(index);
                }
            }

            // Handle children.
            index = 0;
            int foundIndex = -1;
            foreach(Character c in Characters[race])
            {
                if(c.Name == character.Name && c.Age == character.Age)
                {
                    foundIndex = index;
                }

                if(c.Father.Name == character.Name && c.Father.Age == character.Age)
                {
                    c.Father = null;
                }
                else if (c.Mother.Name == character.Name && c.Mother.Age == character.Age)
                {
                    c.Mother = null;
                }
                index++;
            }

            // Remove character.
            if(foundIndex != -1)
            {
                Characters[race].RemoveAt(foundIndex);
            }
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return "Continent Name: " + Name + ", " + "Size: " + Size;
        }

        #endregion
    }
}
