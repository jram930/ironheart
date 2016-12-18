using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoreGenerator
{
    public class TimeSimulator
    {
        #region Properties

        public World World { get; set; }

        public int TotalMarriages { get; set; }

        public int YearlyMarriages { get; set; }

        public int TotalDeaths { get; set; }

        public int YearlyDeaths { get; set; }

        public int TotalBirths { get; set; }

        public int YearlyBirths { get; set; }

        #endregion

        #region Members

        private static Random theRandom = new Random(DateTime.Now.ToString().GetHashCode());

        #endregion

        #region Construction

        public TimeSimulator(World world)
        {
            World = world;
            TotalMarriages = 0;
            TotalDeaths = 0;
            TotalBirths = 0;
        }

        #endregion

        #region Public Methods

        public void Simulate()
        {
            Console.Out.WriteLine();
            Console.Out.WriteLine("//////////////////////////////////////");
            Console.Out.WriteLine("// Simulating time on " + World.Name);
            Console.Out.WriteLine("//////////////////////////////////////");
            Console.Out.WriteLine();

            for (int i = 1; i <= Configuration.YEARS_TO_SIMULATE; i++)
            {
                SimulateYear(i);
            }
        }

        #endregion

        #region Private Methods

        private void SimulateYear(int year)
        {
            Console.Out.WriteLine("Simulating year " + year);
            YearlyBirths = 0;
            YearlyDeaths = 0;
            YearlyMarriages = 0;
            KillCharactersByAge();
            MarryCharacters();
            ProduceChildren();
            Console.Out.WriteLine("Summary of year " + year);
            Console.Out.WriteLine( World.GetWorldPopulation() + " world population, " + YearlyDeaths + " deaths, " + YearlyMarriages + " marriages, " + YearlyBirths + " births");
            Thread.Sleep(1000);
        }

        // TODO Make characters die at random ages, preserving an average length of life.
        private void KillCharactersByAge()
        {
            foreach (Continent continent in World.Continents)
            {
                foreach (KeyValuePair<string, List<Character>> raceCharacters in continent.Characters)
                {
                    string race = raceCharacters.Key;
                    List<Character> characters = raceCharacters.Value;
                    List<int> toKill = new List<int>();
                    if (characters.Count == 0)
                    {
                        Console.Out.WriteLine("All characters of race " + race + " are dead.");
                    }
                    int index = 0;
                    foreach (Character character in characters)
                    {
                        if (character.Age <= Configuration.MAX_CHARACTER_AGE)
                        {
                            character.Age++;
                        }
                        else
                        {
                            toKill.Add(index);
                            if(character.IsMarried)
                            {
                                NullMarriage(continent, race, character);
                            }
                        }
                        index++;
                    }
                    toKill.Reverse();
                    foreach (int death in toKill)
                    {
                        TotalDeaths++;
                        YearlyDeaths++;
                        characters.RemoveAt(death);
                    }
                }
            }
        }

        private void NullMarriage(Continent continent, string race, Character character)
        {
            var couples = continent.Couples;
            int indexToRemove = 0;
            foreach(Couple couple in couples[race])
            {
                Character husband = couple.Husband;
                Character wife = couple.Wife;
                if((husband.Name == character.Name && husband.Age == character.Age) ||
                    (wife.Name == character.Name && wife.Age == character.Age))
                {
                    husband.IsMarried = false;
                    wife.IsMarried = false;
                    break;
                }
                indexToRemove++;
            }
            couples[race].RemoveAt(indexToRemove);
            if(couples[race].Count == 0)
            {
                couples.Remove(race);
            }
        }

        // TODO only marry characters if they are inhabitants of the same city.
        private void MarryCharacters()
        {
            foreach (Continent continent in World.Continents)
            {
                foreach (KeyValuePair<string, List<Character>> raceCharacters in continent.Characters)
                {
                    string race = raceCharacters.Key;
                    List<Character> characters = raceCharacters.Value;

                    if (characters.Count > 1)
                    {
                        for (int attempt = 0; attempt < Configuration.MARRIAGE_ATTEMPTS_PER_YEAR; attempt++)
                        {
                            int index1 = theRandom.Next(1, characters.Count);
                            int index2 = theRandom.Next(1, characters.Count);

                            if (index1 != index2)
                            {
                                Character candidate1 = characters[index1];
                                Character candidate2 = characters[index2];

                                bool canMarry = CanCandidatesMarry(candidate1, candidate2);

                                if (canMarry)
                                {
                                    candidate1.MarryTo(candidate2);
                                    candidate2.MarryTo(candidate1);
                                    Couple couple;
                                    if(candidate1.Male)
                                    {
                                        couple = new Couple(candidate1, candidate2);
                                    }
                                    else
                                    {
                                        couple = new Couple(candidate2, candidate1);
                                    }
                                    continent.AddCouple(race, couple);
                                    TotalMarriages++;
                                    YearlyMarriages++;
                                }
                            }
                        }
                    }
                }
            }
        }

        private bool CanCandidatesMarry(Character candidate1, Character candidate2)
        {
            if (candidate1.Male != candidate2.Male && !candidate1.IsMarried && !candidate2.IsMarried)
            {
                Character male = candidate1.Male ? candidate1 : candidate2;
                Character female = candidate1.Male ? candidate2 : candidate1;
                bool femaleOverMinAge = female.Age >= Configuration.MIN_AGE_TO_MARRY;
                bool maleOverMinAge = male.Age >= Configuration.MIN_AGE_TO_MARRY;
                bool maleAttractive = male.Attractiveness >= Configuration.MIN_ATTRACTIVENESS_TO_MARRY;
                bool femaleAttractive = female.Attractiveness >= Configuration.MIN_ATTRACTIVENESS_TO_MARRY;
                bool maleRich = male.Wealth >= Configuration.MIN_WEALTH_TO_MARRY;
                bool femaleRich = female.Wealth >= Configuration.MIN_WEALTH_TO_MARRY;
                int randomChance = theRandom.Next(1, 101);
                bool agesAreClose = (((male.Age / 2) + 7) < female.Age) && (female.Age < male.Age + 5);

                // Minimum requirements are age. This must always be met.
                if (maleOverMinAge && femaleOverMinAge && agesAreClose)
                {
                    // Perfect match.
                    if (maleAttractive && femaleAttractive && maleRich && femaleRich)
                    {
                        return true;
                    }

                    // Close match.
                    if (maleAttractive && femaleAttractive && maleRich)
                    {
                        return true;
                    }

                    // Ok match.
                    if (maleAttractive && femaleAttractive)
                    {
                        return true;
                    }

                    // Funny match.
                    if (!maleAttractive && !femaleAttractive)
                    {
                        return true;
                    }

                    // Random chance they will get married anyway.
                    if (randomChance < Configuration.RANDOM_MARRY_CHANCE)
                    {
                        return true;
                    }
                }

                // Not a match, return false.
                return false;
            }

            // Not proper candidates.
            return false;
        }

        private void ProduceChildren()
        {
            foreach (Continent continent in World.Continents)
            {
                foreach (KeyValuePair<string, List<Couple>> raceCouples in continent.Couples)
                {
                    string race = raceCouples.Key;
                    List<Couple> couples = raceCouples.Value;

                    foreach(Couple couple in couples)
                    {
                        Character child = couple.ConditionallyGiveBirth();
                        if(child != null)
                        {
                            TotalBirths++;
                            YearlyBirths++;
                            continent.Characters[race].Add(child);
                            couple.Husband.Children.Add(child);
                            couple.Wife.Children.Add(child);
                            child.Father = couple.Husband;
                            child.Mother = couple.Wife;
                        }
                    }
                }
            }
        }

        #endregion
    }
}
