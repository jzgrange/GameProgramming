using System;

namespace CityWars
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Game1 runGame = new Game1())
            {
                runGame.Run();
            }
        }
    }
#endif
}

