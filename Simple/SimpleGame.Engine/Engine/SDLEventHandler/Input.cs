using System.Collections.Generic;
using SDL2;

namespace SimpleGame.Engine.Engine.SDLEventHandler
{
    public static class Input
    {
        private static IList<SDL.SDL_Keycode> _pressedKeys;

        static Input()
        {
            _pressedKeys = new List<SDL.SDL_Keycode>();
        }

        public static void HandleSDLEvent(SDL.SDL_Event @event)
        {
            switch (@event.type)
            {
                case SDL.SDL_EventType.SDL_KEYDOWN:
                    AddKey(@event.key.keysym.sym);
                    break;
                case SDL.SDL_EventType.SDL_KEYUP:
                    _pressedKeys.Remove(@event.key.keysym.sym);
                    break;
            }
        }
        
        public static bool GetKey(SDL.SDL_Keycode keycode)
        {
            return _pressedKeys.Contains(keycode);
        }

        private static void AddKey(SDL.SDL_Keycode keycode)
        {
            if (GetKey(keycode)) return;
            _pressedKeys.Add(keycode);
        }
    }
}
