using System;

namespace EndlessRunner
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new EndlessRunnerGame())
                game.Run();
        }
    }
}
