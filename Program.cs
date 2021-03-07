using System;

namespace BTDMG
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            using BTDGame game = new BTDGame();
            game.Run();
        }
    }
}