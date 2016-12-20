using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoreGenerator
{
    public class Couple
    {
        #region Properties
        
        public Character Husband { get; set; }

        public Character Wife { get; set; }

        #endregion

        #region Members

        private static Random theRandom = new Random(DateTime.Now.ToString().GetHashCode());

        private NameGenerator theNameGen = new NameGenerator();

        #endregion

        #region Construction

        public Couple(Character husband, Character wife)
        {
            Husband = husband;
            Wife = wife;
        }

        #endregion

        #region Public Methods

        public Character ConditionallyGiveBirth()
        {
            int chance = theRandom.Next(0, 100);

            Character child = null;

            if(Wife.Age < 30 && chance < Configuration.CHANCE_OF_CHILD_20S)
            {
                child = CreateChild();
            }
            else if(Wife.Age < 40 && chance < Configuration.CHANCE_OF_CHILD_30S)
            {
                child = CreateChild();
            }
            else if(Wife.Age < 50 && chance < Configuration.CHANCE_OF_CHILD_40s)
            {
                child = CreateChild();
            }

            return child;
        }

        #endregion

        #region Private Methods

        private Character CreateChild()
        {
            int attractiveness = Math.Min(((Husband.Attractiveness + Wife.Attractiveness) / 2) + 1, 10);
            int bravery = Math.Min(((Husband.Bravery + Wife.Bravery) / 2) + 1, 10);
            int healthiness = Math.Min(((Husband.Healthiness + Wife.Healthiness) / 2) + 1, 10);
            int wealth = Math.Min(((Husband.Wealth + Wife.Wealth) / 2) + 1, 10);
            int intelligence = Math.Min(((Husband.Intelligence + Wife.Intelligence) / 2) + 1, 10);

            if (ShouldMutate())
            {
                attractiveness = theRandom.Next(1, 11);
            }

            if (ShouldMutate())
            {
                bravery = theRandom.Next(1, 11);
            }

            if (ShouldMutate())
            {
                healthiness = theRandom.Next(1, 11);
            }

            if (ShouldMutate())
            {
                wealth = theRandom.Next(1, 11);
            }

            if (ShouldMutate())
            {
                intelligence = theRandom.Next(1, 11);
            }

            Character child = new Character(Husband.Race, theNameGen.GenerateCharacterName())
            {
                Wealth = wealth,
                Attractiveness = attractiveness,
                Bravery = bravery,
                Intelligence = intelligence,
                Healthiness = healthiness
            };

            return child;
        }

        private bool ShouldMutate()
        {
            int mutateChance = theRandom.Next(0, 100);
            bool mutate = false;
            if (mutateChance < Configuration.CHANCE_OF_TRAIT_MUTATION)
            {
                mutate = true;
            }
            return mutate;
        }

        #endregion
    }
}
