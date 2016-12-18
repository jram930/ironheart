using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoreGenerator
{
    public class Configuration
    {
        /// <summary>
        /// Each continent is sized 1-10. This is the minimum total amount of landmass in the world.
        /// For example, 5 continents of size 10 would be a landmass of 50 and 7 continents of size 3 would be a landmass of 21.
        /// </summary>
        public const int MIN_LANDMASS = 40;

        /// <summary>
        /// The largest a landmark is allow to be on a continent.
        /// For example, if a continent is size 10, and the max size here is 10, a city can cover the entire continent.
        /// </summary>
        public const int MAX_LANDMARK_SIZE = 3;

        /// <summary>
        /// If true, at least one city must be present on each continent.
        /// </summary>
        public const bool FORCE_CITY_ON_EACH_CONTINENT = true;

        /// <summary>
        /// The number of years to simulate while generating the lore for the world.
        /// </summary>
        public const int YEARS_TO_SIMULATE = 2000;

        /// <summary>
        /// The oldest a character can live.
        /// TODO make this use a proper distribution instead of a naive approach like this.
        /// </summary>
        public const int MAX_CHARACTER_AGE = 120;

        /// <summary>
        /// The minimum length of a location name.
        /// </summary>
        public const int MIN_LOCATION_NAME_LEN = 4;

        /// <summary>
        /// The maximum length of a location name.
        /// </summary>
        public const int MAX_LOCATION_NAME_LEN = 10;

        /// <summary>
        /// The minimum length of a creature name.
        /// </summary>
        public const int MIN_CREATURE_NAME_LEN = 4;

        /// <summary>
        /// The maximum length of a creature name.
        /// </summary>
        public const int MAX_CREATURE_NAME_LEN = 8;

        /// <summary>
        /// The minimum size of a continent.
        /// </summary>
        public const int MIN_CONTINENT_SIZE = 3;

        /// <summary>
        /// The maximum size of a continent.
        /// </summary>
        public const int MAX_CONTINENT_SIZE = 10;

        /// <summary>
        /// The minimum number of creatures per continent.
        /// </summary>
        public const int MIN_CREATURES_PER_CONTINENT = 3;

        /// <summary>
        /// The maximum number of creatures per continent.
        /// </summary>
        public const int MAX_CREATURES_PER_CONTINENT = 7;

        /// <summary>
        /// The minimum number of each creature to put on each continent.
        /// </summary>
        public const int MIN_CREATURE_COUNT = 2;

        /// <summary>
        /// The maximum number of each creature to put on each continent.
        /// </summary>
        public const int MAX_CREATURE_COUNT = 300;

        /// <summary>
        /// If there are less than this many of a type of creature, it is considered uncommon.
        /// </summary>
        public const int CREATURE_RARITY_UNCOMMON = 150;

        /// <summary>
        /// If there are less than this many of a type of creature, it is considered rare.
        /// </summary>
        public const int CREATURE_RARITY_RARE = 50;

        /// <summary>
        /// If there are less than this many of a type of creature, it is considered legendary.
        /// </summary>
        public const int CREATURE_RARITY_LEGENDARY = 20;

        /// <summary>
        /// The minimum number of races to put on each continent.
        /// </summary>
        public const int MIN_RACE_COUNT = 2;

        /// <summary>
        /// The maximum number of races to put on each continent.
        /// </summary>
        public const int MAX_RACE_COUNT = 5;

        /// <summary>
        /// The minimum number of characters for each race to generate.
        /// </summary>
        public const int MIN_POPULATION_COUNT = 1000;

        /// <summary>
        /// The maximum number of characters for each race to generate.
        /// </summary>
        public const int MAX_POPULATION_COUNT = 10000;

        /// <summary>
        /// The shortest a name of a race can be.
        /// </summary>
        public const int MIN_RACE_NAME_LEN = 5;

        /// <summary>
        /// The longest a name of a race can be.
        /// </summary>
        public const int MAX_RACE_NAME_LEN = 8;

        /// <summary>
        /// The shortest a name of a character can be.
        /// </summary>
        public const int MIN_CHARACTER_NAME_LEN = 5;

        /// <summary>
        /// The longest a name of a character can be.
        /// </summary>
        public const int MAX_CHARACTER_NAME_LEN = 10;

        /// <summary>
        /// The minimum attractiveness to marry without random chance.
        /// </summary>
        public const int MIN_ATTRACTIVENESS_TO_MARRY = 4;

        /// <summary>
        /// The minimum wealth to marry without random chance.
        /// </summary>
        public const int MIN_WEALTH_TO_MARRY = 7;

        /// <summary>
        /// Percentage chance that an almost match will still happen.
        /// </summary>
        public const int RANDOM_MARRY_CHANCE = 30;

        /// <summary>
        /// The number of times to attempt to pair mates in a year.
        /// </summary>
        public const int MARRIAGE_ATTEMPTS_PER_YEAR = 3000;

        /// <summary>
        /// The minimum age before two characters can marry.
        /// </summary>
        public const int MIN_AGE_TO_MARRY = 18;

        /// <summary>
        /// The chance of a couple to have a child in their 20s.
        /// </summary>
        public const int CHANCE_OF_CHILD_20S = 50;

        /// <summary>
        /// The chance of a couple to have a child in their 30s.
        /// </summary>
        public const int CHANCE_OF_CHILD_30S = 25;

        /// <summary>
        /// The chance of a couple to have a child in their 40s.
        /// </summary>
        public const int CHANCE_OF_CHILD_40s = 10;

        /// <summary>
        /// Chance that a trait of the child will be totally different than the parents'.
        /// </summary>
        public const int CHANCE_OF_TRAIT_MUTATION = 20;
    }
}
