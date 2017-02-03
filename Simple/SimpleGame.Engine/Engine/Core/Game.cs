using System;
using SDL2;
using SimpleGame.Engine.Engine.Core.Domain;
using SimpleGame.Engine.Engine.EntitieSystem;
using SimpleGame.Engine.Engine.SDLRenderer;

namespace SimpleGame.Engine.Engine.Core
{
    public static class Game
    {
        public static int ScreenWidth;
        public static int ScreenHeight;
        public static string WindowTitle;
        public static SDL.SDL_Color Color;

        public static bool QuitFlag;

        private static IntPtr _window;
        
        public static bool Init()
        {
            if (!InitSDL())
            {
                Debug.LogSDLError("Can't init SDL");
                return false;
            }
            Debug.Log("SDL initialized");
            _window = CreateWindow();
            if (_window == default(IntPtr))
            {
                Debug.LogSDLError("Can't init SDL");
                return false;
            }
            Debug.Log("Window initialized");
            Renderer.InitRenderer(_window, Color);
            Debug.Log("Renderer initialized");
            Resources.Init();
            Debug.Log("Resource initialized");
            return true;
        }

        private static Texture _helloTexture;
        
        public static void LoadMedia()
        {

            GC.Collect();
            Debug.Log("hello image loaded");
        }

        public static void Start()
        {
            GameEntityContainer.Start();
        }

        public static void Update()
        {
            GameEntityContainer.Update();
        }

        public static void Render()
        {
            Renderer.BeginRender();
            Renderer.RenderSprites(GameEntityContainer.GetRenderableEntities());
            Renderer.EndRender();
        }

        public static void Close()
        {
            Resources.FreeResources();
            Renderer.DestroyRenderer();

            SDL.SDL_DestroyWindow(_window);
            _window = default(IntPtr);
            
            SDL.SDL_Quit();
            SDL_image.IMG_Quit();
        }

        private static bool InitSDL()
        {
            return SDL.SDL_Init(SDL.SDL_INIT_VIDEO) == 0;
        }

        private static IntPtr CreateWindow()
        {
            return SDL.SDL_CreateWindow(WindowTitle, SDL.SDL_WINDOWPOS_UNDEFINED, SDL.SDL_WINDOWPOS_UNDEFINED, ScreenWidth, ScreenHeight, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
        }

        private static IntPtr GetScreenSurface()
        {
            return SDL.SDL_GetWindowSurface(_window);
        }
    }
}
