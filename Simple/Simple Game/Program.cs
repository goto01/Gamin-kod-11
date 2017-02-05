using System;
using System.Runtime.ConstrainedExecution;
using SDL2;
using SimpleGame.Engine.Engine.AnimationSystem;
using SimpleGame.Engine.Engine.Core;
using SimpleGame.Engine.Engine.Core.Domain;
using SimpleGame.Engine.Engine.EntitieSystem;
using SimpleGame.Engine.Engine.EntitieSystem.CoreEntities;
using SimpleGame.Engine.Engine.EntitieSystem.Entities;
using SimpleGame.Engine.Engine.SDLEventHandler;
using Simple_Game.Controllers.InputController;
using Simple_Game.GameEntities;
using Simple_Game.GameEntities.SceneSystem;
using Simple_Game.GameEntities.Staff;
using Simple_Game.GameEntities.Text;
using Simple_Game.GameEntityHandlerSystem;

namespace Simple_Game
{
    class Program
    {
        public const string WindowTitle = "Simple";
        public const int ScreenWidth = 800;
        public const int ScreenHeight = 600;
        public static readonly SDL.SDL_Color Color = new SDL.SDL_Color()
        {
            r = 255,
            g = 255,
            b = 255,
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
            //Controllers
            GameEntityContainer.RegisterEntity(InputController.Instance);
            GameEntityContainer.RegisterEntity(SceneController.Instance);

            //Scenes
            RegisterScene(GameEntityHandler.GetSceneIntro());
            RegisterScene(GameEntityHandler.GetSceneStart());
            RegisterScene(GameEntityHandler.GetScene0());
            RegisterScene(GameEntityHandler.GetScene1());
            RegisterScene(GameEntityHandler.GetScene2());
            RegisterScene(GameEntityHandler.GetScene3());
            RegisterScene(GameEntityHandler.GetFinishScene());

            //Front
            GameEntityContainer.RegisterEntity(GameEntityHandler.GetEye());
            GameEntityContainer.RegisterEntity(GameEntityHandler.GetInptut());

        }

        private static void RegisterScene(Scene scene)
        {
            GameEntityContainer.RegisterEntity(scene);
            foreach (var child in scene.Children) GameEntityContainer.RegisterEntity(child);
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
            //Console.ReadKey();
        }
    }
}
