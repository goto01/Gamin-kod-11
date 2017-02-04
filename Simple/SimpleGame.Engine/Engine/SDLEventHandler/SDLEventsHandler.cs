using SDL2;
using SimpleGame.Engine.Engine.Core;

namespace SimpleGame.Engine.Engine.SDLEventHandler
{
    public static class SDLEventsHandler
    {
        public static void HandleEventsPool()
        {
            Input.Clear();
            Time.UpdateTime();
            SDL.SDL_Event e;
            while (SDL.SDL_PollEvent(out e) != 0)
            {
                switch (e.type)
                {
                    case SDL.SDL_EventType.SDL_QUIT:
                        Game.QuitFlag = true;
                        break;
                    case SDL.SDL_EventType.SDL_KEYUP:
                    case SDL.SDL_EventType.SDL_KEYDOWN:
                        Input.HandleSDLEvent(e);
                        break;
                }
            }
        }
    }
}
