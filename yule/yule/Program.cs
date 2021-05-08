using System;

namespace yule
{
    /// <summary>
    /// Main method to run our game.
    /// </summary>
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
}
