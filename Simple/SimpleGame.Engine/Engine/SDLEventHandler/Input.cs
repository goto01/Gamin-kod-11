using System.Collections.Generic;
using SDL2;

namespace SimpleGame.Engine.Engine.SDLEventHandler
{
    public static class Input
    {
        private static IList<SDL.SDL_Keycode> _downKeys;
        private static IList<SDL.SDL_Keycode> _pressedKeys;

        static Input()
        {
            _downKeys = new List<SDL.SDL_Keycode>();
            _pressedKeys = new List<SDL.SDL_Keycode>();
        }

        public static void Clear()
        {
            _downKeys.Clear();
        }

        public static void HandleSDLEvent(SDL.SDL_Event @event)
        {
            if (@event.key.repeat != 0) return;
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

        public static IList<SDL.SDL_Keycode> GetDownKeys()
        {
            return _downKeys;
        }

        public static bool GetKeyDown(SDL.SDL_Keycode keycode)
        {
            return _downKeys.Contains(keycode);
        }

        public static bool GetKey(SDL.SDL_Keycode keycode)
        {
            return _pressedKeys.Contains(keycode);
        }
        
        private static void AddKey(SDL.SDL_Keycode keycode)
        {
            _downKeys.Add(keycode);
            if (GetKey(keycode)) return;
            _pressedKeys.Add(keycode);
        }
    }
}
