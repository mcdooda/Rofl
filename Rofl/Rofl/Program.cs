using System;

namespace Rofl
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (RoflGame game = new RoflGame())
            {
                game.Run();
            }
        }
    }
#endif
}

