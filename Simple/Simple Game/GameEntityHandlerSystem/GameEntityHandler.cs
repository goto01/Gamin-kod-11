using System.Security.Cryptography.X509Certificates;
using SDL2;
using SimpleGame.Engine.Engine.AnimationSystem;
using SimpleGame.Engine.Engine.Core;
using SimpleGame.Engine.Engine.Core.Domain;
using SimpleGame.Engine.Engine.EntitieSystem.Entities;
using Simple_Game.GameEntities;
using Simple_Game.GameEntities.SceneSystem;
using Simple_Game.GameEntities.Staff;
using Simple_Game.GameEntities.Text;

namespace Simple_Game.GameEntityHandlerSystem
{
    class GameEntityHandler
    {
        public static InputTextEntity GetInptut()
        {
            var font = Resources.LoadFont("Pecita.ttf");
            return new InputTextEntity(font, new SDL.SDL_Color() { r = 255, g = 255, b = 255, a = 255 }, "") { Pivot = new Vector2(.5f, .5f), Position = new Vector2(400, 550) };
        }

        public static Eye GetEye()
        {
            var eyeTexture = Resources.LoadTexture("eye.png");
            var eyeSprite0 = eyeTexture.GetSprite(new SDL.SDL_Rect() {x = 0, y = 0, w = 800, h = 600});
            var eyeSprite1 = eyeTexture.GetSprite(new SDL.SDL_Rect() {x = 800, y = 0, w = 800, h = 600});
            var eyeSprite2 = eyeTexture.GetSprite(new SDL.SDL_Rect() {x = 1600, y = 0, w = 800, h = 600});
            var eyeSprite3 = eyeTexture.GetSprite(new SDL.SDL_Rect() {x = 2400, y = 0, w = 800, h = 600});
            var eyeSprite4 = eyeTexture.GetSprite(new SDL.SDL_Rect() {x = 3200, y = 0, w = 800, h = 600});
            var eyeSprite5 = eyeTexture.GetSprite(new SDL.SDL_Rect() {x = 4000, y = 0, w = 800, h = 600});
            var eyeSprite6 = eyeTexture.GetSprite(new SDL.SDL_Rect() {x = 4800, y = 0, w = 800, h = 600});
            var closed = new Animation("closed",
                new Sprite[]
                {
                    eyeSprite0,
                }, .1f, true);
            var open = new Animation("open",
                new []
                {
                    eyeSprite0,
                    eyeSprite1,
                    eyeSprite2,
                    eyeSprite3,
                    eyeSprite4,
                }, .1f, true);
            var opened = new Animation("opened",
                new []
                {
                    eyeSprite5,
                    eyeSprite6,
                }, .5f, false);
            var close = new Animation("close",
                new []
                {
                    eyeSprite4,
                    eyeSprite3,
                    eyeSprite2,
                    eyeSprite1,
                    eyeSprite0,
                }, .1f, true);

            var transitions = new Transition[]
            {
                new Transition(close, closed), 
                new Transition(closed, open), 
                new Transition(open, opened),
            };
            return new Eye(null, 
                new Animator(new [] { closed, open, opened , close}, transitions));
        }

        private static Texture _situation0;

        public static SceneGameEntity GetCloud()
        {
            var sprite = _situation0.GetSprite(new SDL.SDL_Rect() {x = 0, y = 0, w = 434, h = 192});
            return new SceneGameEntity(sprite) {Position = new Vector2(0, 170), FlyDistance = 15, Speed = 2};
        }

        public static SceneGameEntity GetCloud1()
        {
            var sprite = _situation0.GetSprite(new SDL.SDL_Rect() {x = 430, y = 0, w = 250, h = 90});
            return new SceneGameEntity(sprite) {Position = new Vector2(500, 200), FlyDistance = 10, Speed = 5};
        }

        public static SceneGameEntity GetCloud2()
        {
            var sprite = _situation0.GetSprite(new SDL.SDL_Rect() { x = 460, y = 100, w = 210, h = 75 });
            return new SceneGameEntity(sprite) { Position = new Vector2(200, 0), FlyDistance = 20, Speed = 7};
        }

        public static SceneGameEntity GetCloud3()
        {
            var sprite = _situation0.GetSprite(new SDL.SDL_Rect() { x = 700, y = 0, w = 290, h = 160 });
            return new SceneGameEntity(sprite) { Position = new Vector2(350, 20) ,FlyDistance = 20, Speed = 2};
        }

        public static SceneMainGameEntity GetMainSceneGameEntity()
        {
            _situation0 = Resources.LoadTexture("Situation 0.png");
            var sprite0 = _situation0.GetSprite(new SDL.SDL_Rect() {x = 0, y = 190, w = 220, h = 280});
            var sprite1 = _situation0.GetSprite(new SDL.SDL_Rect() {x = 220, y = 190, w = 220, h = 280});
            var sprite2 = _situation0.GetSprite(new SDL.SDL_Rect() {x = 440, y = 190, w = 220, h = 280});
            var sprite3 = _situation0.GetSprite(new SDL.SDL_Rect() {x = 660, y = 190, w = 220, h = 280});
            var sprite4 = _situation0.GetSprite(new SDL.SDL_Rect() {x = 880, y = 190, w = 220, h = 280});
            var sprite5 = _situation0.GetSprite(new SDL.SDL_Rect() {x = 1100, y = 190, w = 220, h = 280});
            var idle = new Animation("idle",
                new []
                {
                    sprite0,
                    sprite1
                }, .1f, false);
            var activate = new Animation("activate",
                new []
                {
                    sprite2,
                    sprite3,
                    sprite4,
                    sprite5,
                }, .1f, true);
            return new SceneMainGameEntity(null, new Animator(new Animation[] {idle, activate}, new Transition[] {})) {Position = new Vector2(400, 150), Pivot = new Vector2(.5f, .5f)};
        }

        public static Scene GetScene0()
        {
            var main = GetMainSceneGameEntity();
            return new Scene("раскрыть парашют", new SpriteGameEntity[] {GetCloud(), GetCloud1(), GetCloud2(), GetCloud3(), main}, main);
        }

        public static Scene GetSceneStart()
        {
            return new Scene("заснуть", new SpriteGameEntity[] {}, null);
        }

        //private static GameEntity GetCharacter()
        //{
        //    var birdTexture = Resources.LoadTexture("bird.png");
        //    var birdSprite0 = birdTexture.GetSprite(new SDL.SDL_Rect() { x = 0, y = 0, w = 64, h = 96 });
        //    var birdSprite1 = birdTexture.GetSprite(new SDL.SDL_Rect() { x = 64, y = 0, w = 64, h = 96 });
        //    var birdSprite2 = birdTexture.GetSprite(new SDL.SDL_Rect() { x = 128, y = 0, w = 64, h = 96 });
        //    var birdSprite3 = birdTexture.GetSprite(new SDL.SDL_Rect() { x = 192, y = 0, w = 64, h = 96 });
        //    var birdSprite4 = birdTexture.GetSprite(new SDL.SDL_Rect() { x = 256, y = 0, w = 64, h = 96 });
        //    var birdSprite5 = birdTexture.GetSprite(new SDL.SDL_Rect() { x = 320, y = 0, w = 64, h = 96 });
        //    var birdSprite6 = birdTexture.GetSprite(new SDL.SDL_Rect() { x = 384, y = 0, w = 64, h = 96 });
        //    var animation = new Animation("idle",
        //        new Sprite[]
        //        {
        //            birdSprite0,
        //            birdSprite1,
        //            birdSprite2,
        //            birdSprite3,
        //            birdSprite4,
        //            birdSprite5,
        //            birdSprite6,
        //        }, .1f, true, false);
        //    var animationRun = new Animation("run",
        //        new Sprite[]
        //        {
        //            birdSprite2,
        //            birdSprite3,
        //            birdSprite4,
        //            birdSprite5,
        //            birdSprite6,
        //        }, .05f, true, false);
        //    return new Character(birdSprite0, new Animator(new Animation[] { animation, animationRun }));
        //}
    }
}
