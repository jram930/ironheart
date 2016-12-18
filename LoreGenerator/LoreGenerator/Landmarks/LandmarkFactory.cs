using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoreGenerator
{
    public static class LandmarkFactory
    {
        #region Constants

        private const int LANDMARK_TYPES = 3;

        #endregion

        #region Members

        private static Random theRandom = new Random(DateTime.Now.ToString().GetHashCode());

        #endregion

        #region Public Methods

        public static Landmark CreateLandmark(string name, int size)
        {
            int type = theRandom.Next(1, LANDMARK_TYPES+1);

            switch(type)
            {
                case 1:
                    Console.Out.WriteLine("Generated city " + name + " of size " + size);
                    return new City(name, size);
                case 2:
                    Console.Out.WriteLine("Generated forest " + name + " of size " + size);
                    return new Forest(name, size);
                case 3:
                    Console.Out.WriteLine("Generated mountain " + name + " of size " + size);
                    return new Mountain(name, size);
                default:
                    // This shouldn't be hit, but just in case...
                    Console.Out.WriteLine("ERROR Generated forest " + name + " of size " + size);
                    return new Forest(name, size);
            }
        }

        public static City CreateCity(string name, int size)
        {
            Console.Out.WriteLine("Generated city " + name + " of size " + size);
            return new City(name, size);
        }

        #endregion
    }
}
