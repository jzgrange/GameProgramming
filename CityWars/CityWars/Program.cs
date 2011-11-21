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
            using (DrawGame game = new DrawGame())
            {
                game.Run();
            }
        }
    }
#endif
}

