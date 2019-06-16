using System;
using Foundation;
using UIKit;

namespace Sandbox
{
    [Register("AppDelegate")]
    class Program : UIApplicationDelegate
    {
        private static GameCore game;

        internal static void RunGame()
        {
            game = new GameCore();
            game.Run();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            UIApplication.Main(args, null, "AppDelegate");
        }

        public override void FinishedLaunching(UIApplication app)
        {
            RunGame();
        }
    }
}
