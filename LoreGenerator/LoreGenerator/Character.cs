using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoreGenerator
{
    public class Character
    {
        #region Properties

        public bool IsAlive { get; set; }

        public string Nationality { get; set; }

        public string Name { get; set; }

        public bool Male { get; set; }

        public int Age { get; set; }

        public int Healthiness { get; set; }

        public int Attractiveness { get; set; }

        public int Bravery { get; set; }

        public int Wealth { get; set; }

        public int Intelligence { get; set; }

        public Job Job { get; set; }

        public Character Spouse {get; set;}

        public Character Father { get; set; }

        public Character Mother { get; set; }

        public List<Character> Children { get; set; }

        public bool IsMarried = false;

        #endregion

        #region Members

        private static Random theRandom = new Random(DateTime.Now.ToString().GetHashCode());

        #endregion

        #region Construction

        public Character(string nationality, string name, int age = 0)
        {
            Nationality = nationality;
            Name = name;
            Age = age;
            Male = DetermineIfMale();
            Attractiveness = AssignRandomTrait();
            Wealth = AssignRandomTrait();
            Healthiness = AssignRandomTrait();
            Bravery = AssignRandomTrait();
            Intelligence = AssignRandomTrait();
            Children = new List<Character>();
            IsAlive = true;
        }

        #endregion

        #region Public Methods

        public void MarryTo(Character spouse)
        {
            IsMarried = true;
            Spouse = spouse;
        }

        public void Kill()
        {
            IsAlive = false;
        }

        #endregion

        #region Private Methods

        private bool DetermineIfMale()
        {
            int chance = theRandom.Next(0, 100);

            if(chance < 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int AssignRandomTrait()
        {
            return theRandom.Next(1, 11);
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            string result = "IsAlive: " + IsAlive + ", " +
                "Nationality: " + Nationality + ", " +
                "Name: " + Name + ", " +
                "Male: " + Male + ", " +
                "Age: " + Age + ", " +
                "IsMarried: " + IsMarried + ", " +
                "Attractiveness: " + Attractiveness + ", " +
                "Wealth: " + Wealth + ", " +
                "Bravery: " + Bravery + ", " +
                "Healthiness: " + Healthiness + ", " +
                "Intelligence: " + Intelligence + ", " +
                "Job: " + Job;

            return result;
        }

        #endregion
    }
}
