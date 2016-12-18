using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoreGenerator
{
    public class LoreGenerator
    {
        public static void Main(string[] args)
        {
            // Print welcome message.
            PrintWelcomeMessage();

            // Generate the world.
            var worldGen = new WorldGenerator();
            worldGen.GenerateWorld();

            // Wait for user to exit.
            Console.Out.WriteLine();
            Console.Out.WriteLine("Press ENTER to continue...");
            Console.In.ReadLine();
        }

        public static void PrintWelcomeMessage()
        {
            Console.Out.WriteLine();
            Console.Out.WriteLine("//////////////////////////////////////");
            Console.Out.WriteLine("// Generating lore for game");
            Console.Out.WriteLine("//////////////////////////////////////");
            Console.Out.WriteLine();
        }
    }
}
