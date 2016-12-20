using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoreGenerator
{
    public class NameGenerator
    {
        #region Constants

        private const int MIN_ASCII = 65;

        private const int MAX_ASCII = 91;

        #endregion

        #region Members

        private static Random theRandom = new Random(DateTime.Now.ToString().GetHashCode());

        #endregion

        #region Public Methods

        public string GenerateLocationName()
        {
            //TODO For now just generating a random name that will most likely look like garbage.
            int nameLength = theRandom.Next(Configuration.MIN_LOCATION_NAME_LEN, Configuration.MAX_LOCATION_NAME_LEN + 1);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < nameLength; i++)
            {
                builder.Append(((char)theRandom.Next(MIN_ASCII, MAX_ASCII)).ToString());
            }

            return builder.ToString();
        }

        public string GenerateCreatureName()
        {
            //TODO For now just generating a random name that will most likely look like garbage.
            int nameLength = theRandom.Next(Configuration.MIN_CREATURE_NAME_LEN, Configuration.MAX_CREATURE_NAME_LEN + 1);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < nameLength; i++)
            {
                builder.Append(((char)theRandom.Next(MIN_ASCII, MAX_ASCII)).ToString());
            }

            return builder.ToString();
        }

        public string GenerateNationalityName()
        {
            //TODO For now just generating a random name that will most likely look like garbage.
            int nameLength = theRandom.Next(Configuration.MIN_RACE_NAME_LEN, Configuration.MAX_RACE_NAME_LEN + 1);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < nameLength; i++)
            {
                builder.Append(((char)theRandom.Next(MIN_ASCII, MAX_ASCII)).ToString());
            }

            return builder.ToString();
        }

        public string GenerateCharacterName()
        {
            //TODO For now just generating a random name that will most likely look like garbage.
            int nameLength = theRandom.Next(Configuration.MIN_CHARACTER_NAME_LEN, Configuration.MAX_CHARACTER_NAME_LEN + 1);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < nameLength; i++)
            {
                builder.Append(((char)theRandom.Next(MIN_ASCII, MAX_ASCII)).ToString());
            }

            return builder.ToString();
        }

        public string GenerateNaturalDisasterName()
        {
            //TODO For now just generating a random name that will most likely look like garbage.
            int nameLength = theRandom.Next(Configuration.MIN_DISASTER_NAME_LEN, Configuration.MAX_DISASTER_NAME_LEN + 1);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < nameLength; i++)
            {
                builder.Append(((char)theRandom.Next(MIN_ASCII, MAX_ASCII)).ToString());
            }

            return builder.ToString();
        }

        #endregion

        #region Private Methods

        private bool IsNameValid(string name)
        {
            //TODO Put some smart logic in here to reject bad names.

            return true;
        }

        #endregion
    }
}
