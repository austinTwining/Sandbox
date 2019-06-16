using System;

namespace Sandbox
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new GameCore())
                game.Run();
        }
    }
}
