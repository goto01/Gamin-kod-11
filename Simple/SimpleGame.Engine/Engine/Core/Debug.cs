using System;
using SDL2;

namespace SimpleGame.Engine.Engine.Core
{
    public static class Debug 
    {
        public static void Log(string message)
        {
            Console.WriteLine(message);
        }

        public static void Log<T>(T o)
        {
            Log(o.ToString());
        }

        public static void LogSDLError(string message)
        {
            Log(message + " - " + SDL.SDL_GetError());
        }
    }
}
