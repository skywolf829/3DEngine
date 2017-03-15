using System;

namespace _3DEngine
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        public static Scene Game { get; private set; }
        
        [STAThread]
        static void Main()
        {
            using (Game = new Scene())
                Game.Run();
        }
    }
#endif
}
