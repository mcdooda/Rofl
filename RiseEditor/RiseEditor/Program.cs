using System;

namespace RiseEditor
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
            using (RiseEditor game = new RiseEditor())
            {
                game.Run();
            }
        }
    }
#endif
}

