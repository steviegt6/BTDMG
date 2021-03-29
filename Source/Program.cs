using System;

namespace BTDMG.Source
{
    /// <summary>
    /// Entry-point class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Entry-point method that runs our game.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            using BTDGame game = new BTDGame();
            game.Run();
        }
    }
}