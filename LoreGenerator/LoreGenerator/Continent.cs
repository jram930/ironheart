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

        public Dictionary<string, List<Character>> LiveCharacters { get; set; }

        public Dictionary<string, List<Character>> DeadCharacters { get; set; }

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
            DeadCharacters = new Dictionary<string, List<Character>>();
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
            LiveCharacters = new Dictionary<string, List<Character>>();
            int numNationalitys = theRandom.Next(Configuration.MIN_RACE_COUNT, Configuration.MAX_RACE_COUNT + 1);
            for (int i = 0; i < numNationalitys; i++)
            {
                string nationalityName = theNameGen.GenerateNationalityName();
                LiveCharacters.Add(nationalityName, new List<Character>());
                int numCharacters = theRandom.Next(Configuration.MIN_POPULATION_COUNT, Configuration.MAX_POPULATION_COUNT);
                for (int j = 0; j < numCharacters; j++)
                {
                    string characterName = theNameGen.GenerateCharacterName();
                    int age = theRandom.Next(1, Configuration.MAX_CHARACTER_AGE + 1);
                    var character = new Character(nationalityName, characterName, age);
                    LiveCharacters[nationalityName].Add(character);
                }
                Console.WriteLine("Generated " + numCharacters + " characters of the nationality " + nationalityName + " on the continent " + Name);
            }
        }

        public void AddCouple(string nationality, Couple couple)
        {
            if (Couples == null)
            {
                Couples = new Dictionary<string, List<Couple>>();
            }

            if (!Couples.ContainsKey(nationality))
            {
                Couples.Add(nationality, new List<Couple>());
            }

            Couples[nationality].Add(couple);
        }

        public Character KillRandomCharacter(string nationality)
        {
            int randomDeath = theRandom.Next(0, LiveCharacters[nationality].Count);
            Character killedChar = LiveCharacters[nationality][randomDeath];
            KillCharacter(killedChar);
            return killedChar;
        }

        public void KillCharacter(Character character)
        {
            string nationality = character.Nationality;

            // Handle marriage.
            int index = 0;
            if (character.IsMarried)
            {
                foreach (Couple couple in Couples[nationality])
                {
                    if (couple.Husband.Name == character.Name && couple.Husband.Age == character.Age)
                    {
                        couple.Wife.IsMarried = false;
                        break;
                    }
                    else if (couple.Wife.Name == character.Name && couple.Wife.Age == character.Age)
                    {
                        couple.Husband.IsMarried = false;
                        break;
                    }
                    index++;
                }

                if(index < Couples[nationality].Count)
                {
                    Couples[nationality].RemoveAt(index);
                }
            }

            // Remove from live list.
            index = 0;
            int foundIndex = -1;
            foreach(Character c in LiveCharacters[nationality])
            {
                if(c.Name == character.Name && c.Age == character.Age)
                {
                    foundIndex = index;
                }

                index++;
            }

            // Kill character.
            if(foundIndex != -1)
            {
                character.Kill();
                LiveCharacters[nationality].RemoveAt(foundIndex);
                AddToDeadCharacters(character);
            }
        }

        #endregion

        #region Private Methods

        private void AddToDeadCharacters(Character character)
        {
            if (!DeadCharacters.ContainsKey(character.Nationality))
            {
                DeadCharacters.Add(character.Nationality, new List<Character>());
            }

            DeadCharacters[character.Nationality].Add(character);
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
