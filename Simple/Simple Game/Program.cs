using SDL2;
using SimpleGame.Engine.Engine.AnimationSystem;
using SimpleGame.Engine.Engine.Core;
using SimpleGame.Engine.Engine.Core.Domain;
using SimpleGame.Engine.Engine.EntitieSystem;
using SimpleGame.Engine.Engine.EntitieSystem.Entities;
using SimpleGame.Engine.Engine.SDLEventHandler;
using Simple_Game.Controllers.InputController;
using Simple_Game.GameEntities;

namespace Simple_Game
{
    class Program
    {
        public const string WindowTitle = "Simple";
        public const int ScreenWidth = 800;
        public const int ScreenHeight = 600;
        public static readonly SDL.SDL_Color Color = new SDL.SDL_Color()
        {
            r = 120,
            g = 120,
            b = 120,
            a = 255,
        };

        private static void InitGame()
        {
            Game.WindowTitle = WindowTitle;
            Game.ScreenWidth = ScreenWidth;
            Game.ScreenHeight = ScreenHeight;
            Game.Color = Color;

            Game.Init();
        }

        private static void InitGameEntities()
        {
            var helloTexture = Resources.LoadTexture("bird.png");
            var heloSPrite1 = helloTexture.GetSprite(new SDL.SDL_Rect() { x = 0, y = 0, w = 64, h = 96 });

            GameEntityContainer.RegisterEntity(InputController.Instance);
            GameEntityContainer.RegisterEntity(GetCharacter());
        }

        private static GameEntity GetCharacter()
        {
            var birdTexture = Resources.LoadTexture("bird.png");
            var birdSprite0 = birdTexture.GetSprite(new SDL.SDL_Rect() { x = 0, y = 0, w = 64, h = 96 });
            var birdSprite1 = birdTexture.GetSprite(new SDL.SDL_Rect() { x = 64, y = 0, w = 64, h = 96 });
            var birdSprite2 = birdTexture.GetSprite(new SDL.SDL_Rect() { x = 128, y = 0, w = 64, h = 96 });
            var birdSprite3 = birdTexture.GetSprite(new SDL.SDL_Rect() { x = 192, y = 0, w = 64, h = 96 });
            var birdSprite4 = birdTexture.GetSprite(new SDL.SDL_Rect() { x = 256, y = 0, w = 64, h = 96 });
            var birdSprite5 = birdTexture.GetSprite(new SDL.SDL_Rect() { x = 320, y = 0, w = 64, h = 96 });
            var birdSprite6 = birdTexture.GetSprite(new SDL.SDL_Rect() { x = 384, y = 0, w = 64, h = 96 });
            var animation = new Animation("idle", 
                new Sprite[]
                {
                    birdSprite0, 
                    birdSprite1,
                    birdSprite2,
                    birdSprite3,
                    birdSprite4,
                    birdSprite5,
                    birdSprite6,
                }, .1f, false);
            var animationRun = new Animation("run",
                new Sprite[]
                {
                    birdSprite2,
                    birdSprite3,
                    birdSprite4,
                    birdSprite5,
                    birdSprite6,
                }, .05f, false);
            return new Character(birdSprite0, new Animator(new Animation[] {animation, animationRun}));
        }

        static void Main(string[] args)
        {
            InitGame();
            InitGameEntities();
            Game.LoadMedia();

            Game.Start();
            while (!Game.QuitFlag)
            {
                SDLEventsHandler.HandleEventsPool();
                Game.Update();
                Game.Render();
            }

            Game.Close();
        }
    }
}
