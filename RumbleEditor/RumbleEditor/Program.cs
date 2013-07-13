using System;

namespace RumbleEditor
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            using (RumbleEditor game = new RumbleEditor())
            {
                game.Run();
            }
        }
    }
#endif
}

