using SDL2;

namespace SimpleGame.Engine.Engine.SDLEventHandler
{
    public static class Time
    {
        private static ulong _now;
        private static ulong _last;

        public static float DeltaTime { get; private set; }
        public static float MilliSeconds { get; private set; }

        public static void UpdateTime()
        {
            _now = SDL.SDL_GetTicks();
            MilliSeconds = (float)_now/1000;
            DeltaTime = (float) ((_now - _last))/1000;
            _last = _now;
        }
    }
}
