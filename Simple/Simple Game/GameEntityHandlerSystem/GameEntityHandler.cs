using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using SDL2;
using SimpleGame.Engine.Engine.AnimationSystem;
using SimpleGame.Engine.Engine.Core;
using SimpleGame.Engine.Engine.Core.Domain;
using SimpleGame.Engine.Engine.EntitieSystem.CoreEntities;
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

        public static SimpleTextGameEntity GetDebugTitle()
        {
            var font = Resources.LoadFont("Pecita.ttf");
            return new SimpleTextGameEntity(font, new SDL.SDL_Color() {r = 0, g = 0, b = 0, a = 255}, string.Empty);
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
            var closedLong = new Animation("closedLong",
                new[]
                {
                    eyeSprite0,
                }, .1f, false);

            var transitions = new Transition[]
            {
                new Transition(close, closed), 
                new Transition(closed, open), 
                new Transition(open, opened),
            };
            return new Eye(null, 
                new Animator(new [] { closed, open, opened , close, closedLong }, transitions));
        }

        #region Scene 0

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
                }, .5f, true);
            return new SceneMainGameEntity(null, new Animator(new Animation[] {idle, activate}, new Transition[] {})) {Position = new Vector2(400, 150), Pivot = new Vector2(.5f, .5f)};
        }

        public static Scene GetScene0()
        {
            var main = GetMainSceneGameEntity();
            return new Scene(new []
            {
                "раскрыть парашют",
                "использовать парашют",
                "вытянуть кольцо",
                "дёрнуть кольцо",
                "парашют"
            }, new SpriteGameEntity[] {GetCloud(), GetCloud1(), GetCloud2(), GetCloud3(), main}, main);
        }

        #endregion

        #region Scene start

        private static Texture _situationStart;

        public static SceneMainGameEntity GetBed()
        {
            _situationStart = Resources.LoadTexture("SituationStart.png");
            var sprite0 = _situationStart.GetSprite(new SDL.SDL_Rect() {x = 0, y = 60, w = 377, h = 311});
            var sprite1 = _situationStart.GetSprite(new SDL.SDL_Rect() {x = 385, y = 0, w = 700, h = 450});
            var idle = new Animation("idle",
                new []{sprite0}, .1f, false);
            var activate = new Animation("activate",
                new Sprite[] {sprite1}, .1f, false);
            return new SceneMainGameEntity(null, new Animator(new []{idle, activate}, new Transition[] {})) {Position = new Vector2(400, 200), Pivot = new Vector2(.5f, .5f), FlyDistance = 5, Speed = 1};
        }

        public static SceneGameEntity GetStar0()
        {
            var sprite0 = _situationStart.GetSprite(new SDL.SDL_Rect() {x = 0, y = 0, w = 60, h = 50});
            var sprite1 = _situationStart.GetSprite(new SDL.SDL_Rect() {x = 60, y = 0, w = 60, h = 50});
            var sprite2 = _situationStart.GetSprite(new SDL.SDL_Rect() {x = 120, y = 0, w = 60, h = 50});
            var sprite3 = _situationStart.GetSprite(new SDL.SDL_Rect() {x = 180, y = 0, w = 60, h = 50});
            var idle = new Animation("idle", new Sprite[]
            {
                sprite0,
                sprite1,
                sprite2,
                sprite3
            }, .1f, false);
            return new SceneGameEntity(sprite0, new Animator(new Animation[] {idle}, new Transition[] {}));
        }

        public static SceneGameEntity GetMoon()
        {
            var sprite0 = _situationStart.GetSprite(new SDL.SDL_Rect() {x = 0, y = 370, w = 100, h = 113});
            var sprite1 = _situationStart.GetSprite(new SDL.SDL_Rect() {x = 100, y = 370, w = 100, h = 113});
            var sprite2 = _situationStart.GetSprite(new SDL.SDL_Rect() {x = 200, y = 370, w = 100, h = 113});
            var sprite3 = _situationStart.GetSprite(new SDL.SDL_Rect() {x = 300, y = 370, w = 100, h = 113});
            var idle = new Animation("idle", new Sprite[] {sprite0, sprite1,sprite2, sprite3}, .1f, false);
            return new SceneGameEntity(sprite0, new Animator(new Animation[] {idle}, new Transition[] {})) {Position = new Vector2(400, 50)};
        }

        public static Scene GetSceneStart()
        {
            var bed = GetBed();
            var star0 = GetStar0();
            star0.Position = new Vector2(200, 50);
            star0.FlyDistance = 10;
            star0.Animator.PlayAnimation("idle");

            var star1 = GetStar0();
            star1.Position = new Vector2(300, 200);
            star1.FlyDistance = 5;
            star1.Animator.PlayAnimation("idle");

            var star2 = GetStar0();
            star2.Position = new Vector2(550, 150);
            star2.FlyDistance = 3;
            star2.Animator.PlayAnimation("idle");

            var star3 = GetStar0();
            star3.Position = new Vector2(480, 180);
            star3.FlyDistance = 15;
            star3.Animator.PlayAnimation("idle");

            var star4 = GetStar0();
            star4.Position = new Vector2(150, 280);
            star4.FlyDistance = 15;
            star4.Animator.PlayAnimation("idle");

            var star5 = GetStar0();
            star5.Position = new Vector2(390, 2400);
            star5.FlyDistance = 15;
            star5.Animator.PlayAnimation("idle");
            return new Scene(new string[]
            {
                "заснуть",
                "спать",
                "лечь",
                "лечь спать",
                "поспать",
                "отдохнуть",
                "прилечь",
            }, new SpriteGameEntity[] {bed, star0, star1, star2, star3, star4, star5, GetMoon()}, bed);
        }

        #endregion

        #region Intro region

        private static Texture _introTexture;

        public static SceneMainGameEntity GetSwitcher()
        {
            _introTexture = Resources.LoadTexture("Situation intro.png");
            var sprite0 = _introTexture.GetSprite(new SDL.SDL_Rect() {x = 275, y = 0, w = 158, h = 290});
            var sprite1 = _introTexture.GetSprite(new SDL.SDL_Rect() {x = 450, y = 0, w = 158, h = 290});
            var sprite2 = _introTexture.GetSprite(new SDL.SDL_Rect() { x = 275, y = 270, w = 158, h = 290 });
            var sprite3 = _introTexture.GetSprite(new SDL.SDL_Rect() { x = 450, y = 270, w = 158, h = 290 });
            var idle = new Animation("idle", new Sprite[] {sprite0, sprite1}, .1f, false);
            var activate = new Animation("activate", new Sprite[] {sprite2, sprite3}, .1f, false);
            return new SceneMainGameEntity(sprite0, new Animator(new Animation[] {idle, activate }, new Transition[] {})) {Position = new Vector2(400, 270), Pivot = new Vector2(.5f, .5f)};
        }

        public static SceneGameEntity GetDot0()
        {
            var sprite0 = _introTexture.GetSprite(new SDL.SDL_Rect() {x = 0, y = 0, w = 125, h = 120});
            var sprite1 = _introTexture.GetSprite(new SDL.SDL_Rect() {x = 125, y = 0, w = 125, h = 120});
            var idle = new Animation("idle", new Sprite[] {sprite0, sprite1}, .23f, false);
            return new SceneGameEntity(null, new Animator(new Animation[] {idle}, new Transition[] {})) {Position = new Vector2(180, 230), FlyDistance = 5};
        }

        public static SceneGameEntity GetDot1()
        {
            var sprite0 = _introTexture.GetSprite(new SDL.SDL_Rect() { x = 0, y = 120, w = 125, h = 140 });
            var sprite1 = _introTexture.GetSprite(new SDL.SDL_Rect() { x = 125, y = 120, w = 125, h = 140 });
            var idle = new Animation("idle", new Sprite[] { sprite0, sprite1 }, .23f, false);
            return new SceneGameEntity(null, new Animator(new Animation[] { idle }, new Transition[] { })) { Position = new Vector2(500, 230), FlyDistance = 5 };
        }

        public static SceneGameEntity GetTitle()
        {
            var texture = Resources.LoadTexture("titleword 280x100.png");
            var sprite0 = texture.GetSprite(new SDL.SDL_Rect() {x = 0, y = 0, w = 280, h = 100});
            var sprite1 = texture.GetSprite(new SDL.SDL_Rect() {x = 280, y = 0, w = 280, h = 100});
            var sprite2 = texture.GetSprite(new SDL.SDL_Rect() {x = 560, y = 0, w = 280, h = 100});
            var sprite3 = texture.GetSprite(new SDL.SDL_Rect() {x = 840, y = 0, w = 280, h = 100});
            var sprite4 = texture.GetSprite(new SDL.SDL_Rect() {x = 1120, y = 0, w = 280, h = 100});
            var idle = new Animation("idle", new Sprite[]
            {
                sprite0,
                sprite1,
                sprite2,
                sprite3,
                sprite4
            }, .1f, false);
            return new SceneGameEntity(null, new Animator(new Animation[] {idle}, new Transition[] {})) {Position = new Vector2(400, 100), Pivot = new Vector2(.5f, .5f), FlyDistance = 15, Speed = 3};
        }

        public static Scene GetSceneIntro()
        {
            var switcher = GetSwitcher();
            return new Scene(new []
            {
                "выключить",
                "выключить свет",
                "переключить",
                "отключить",
                "отключить свет",
                "нажать",
            }, new []{switcher, GetDot0(), GetDot1(), GetTitle() }, switcher);
        }

        #endregion

        #region Scene 1

        private static Texture _cowboyTexture;

        public static SceneMainGameEntity GetCowboy()
        {
            _cowboyTexture = Resources.LoadTexture("Situation 1.png");
            var sprite0 = _cowboyTexture.GetSprite(new SDL.SDL_Rect() {x = 0, y = 0, w = 600, h = 420});
            var sprite1 = _cowboyTexture.GetSprite(new SDL.SDL_Rect() {x = 600, y = 0, w = 600, h = 420});
            var sprite2 = _cowboyTexture.GetSprite(new SDL.SDL_Rect() {x = 1200, y = 0, w = 600, h = 420});
            var sprite3 = _cowboyTexture.GetSprite(new SDL.SDL_Rect() {x = 1800, y = 0, w = 600, h = 420});
            var sprite4 = _cowboyTexture.GetSprite(new SDL.SDL_Rect() {x = 2400, y = 0, w = 600, h = 420});
            var idle = new Animation("idle", new Sprite[]
            {
                sprite0,
                sprite1
            }, 1f, false);
            var activate = new Animation("activate", new Sprite[]
            {
                sprite2,
                sprite3,
                sprite4
            }, 1f, true);
            return new SceneMainGameEntity(null, new Animator(new Animation[] {idle, activate}, new Transition[] {})) {Position = new Vector2(400, 210), Pivot = new Vector2(.5f, .5f), Speed = 0};
        }

        public static SceneGameEntity GetCircle()
        {
            var sprite0 = _cowboyTexture.GetSprite(new SDL.SDL_Rect() {x = 0, y = 460, w = 100, h = 130});
            var sprite1 = _cowboyTexture.GetSprite(new SDL.SDL_Rect() {x = 100, y = 460, w = 100, h = 130});
            var sprite2 = _cowboyTexture.GetSprite(new SDL.SDL_Rect() {x = 200, y = 460, w = 100, h = 130});
            var sprite3 = _cowboyTexture.GetSprite(new SDL.SDL_Rect() {x = 300, y = 460, w = 100, h = 130});
            var idle = new Animation("idle", new Sprite[]
            {
                sprite0,
                sprite1,
                sprite2,
                sprite3
            }, .1f, false);
            return new SceneGameEntity(null, new Animator(new Animation[] {idle}, new Transition[] {}));
        }

        public static Scene GetScene1()
        {
            var cowboy = GetCowboy();
            var circle0 = GetCircle();
            circle0.Position = new Vector2(200, 300);
            circle0.Pivot = new Vector2(.5f, .5f);
            circle0.Animator.PlayAnimation("idle");
            circle0.FlyDistance = 10;

            var circle1 = GetCircle();
            circle1.Position = new Vector2(400, 400);
            circle1.Pivot = new Vector2(.5f, .5f);
            circle1.Animator.PlayAnimation("idle");
            circle1.FlyDistance = 5;

            var circle2 = GetCircle();
            circle2.Position = new Vector2(600, 310);
            circle2.Pivot = new Vector2(.5f, .5f);
            circle2.Animator.PlayAnimation("idle");
            circle2.FlyDistance = 15;

            return new Scene(new []
            {
                "выстрелить",
                "достать пистолет",
                "использовать пистолет",
                "нанести выстрел",
                "убить",
                "пистолет",
                "достать"
            }, new SpriteGameEntity[] {cowboy, circle0, circle1, circle2}, cowboy);
        }

        #endregion

        #region Scene 2

        private static Texture _prisonTexture;

        public static SceneMainGameEntity GetPrisonLocation()
        {
            _prisonTexture = Resources.LoadTexture("Situation 2.png");
            var sprite0 = _prisonTexture.GetSprite(new SDL.SDL_Rect() {x = 0, y = 0, w = 800, h = 400});
            var sprite1 = _prisonTexture.GetSprite(new SDL.SDL_Rect() {x = 800, y = 0, w = 800, h = 400});
            var sprite2 = _prisonTexture.GetSprite(new SDL.SDL_Rect() {x = 1600, y = 0, w = 800, h = 400});
            var sprite3 = _prisonTexture.GetSprite(new SDL.SDL_Rect() {x = 2400, y = 0, w = 800, h = 400});
            var idle = new Animation("idle", new Sprite[]
            {
                sprite0,
                sprite1,
                sprite2,
            }, 1f, false, false);
            var activate = new Animation("activate", new Sprite[]
            {
                sprite3
            }, 1f, true);
            return new SceneMainGameEntity(null, new Animator(new Animation[] {idle, activate}, new Transition[] {})) {Position = new Vector2(400, 200), Pivot = new Vector2(.5f, .5f), FlyDistance = 10, Speed = 3};
        }

        public static SceneGameEntity GetKnife()
        {
            var sprite0 = _prisonTexture.GetSprite(new SDL.SDL_Rect() {x = 0, y = 400, w = 75, h = 70});
            var sprite1 = _prisonTexture.GetSprite(new SDL.SDL_Rect() {x = 80, y = 400, w = 80, h = 70});
            var idle = new Animation("idle", new Sprite[]
            {
                sprite0,
                sprite1
            }, .5f, false);
            return new SceneGameEntity(null, new Animator(new Animation[] {idle}, new Transition[] {})) {Pivot = new Vector2(.5f, .5f)};
        }

        public static Scene GetScene2()
        {
            var location = GetPrisonLocation();
            var knife0 = GetKnife();
            knife0.Animator.PlayAnimation("idle");
            knife0.Position = new Vector2(200, 300);
            knife0.FlyDistance = 10;
            knife0.Speed = 10;

            var knife1 = GetKnife();
            knife1.Animator.PlayAnimation("idle");
            knife1.Position = new Vector2(500, 100);
            knife1.FlyDistance = 8;
            knife1.Speed = 7;

            var knife2 = GetKnife();
            knife2.Animator.PlayAnimation("idle");
            knife2.Position = new Vector2(400, 350);
            knife2.FlyDistance = 15;
            knife2.Speed = 13;

            return new Scene(new []
            {
                "копать",
                "копать лопатой",
                "копать подкоп",
                "сделать подкоп",
                "подкоп",
                "взять лопату",
                "использовать лопату",
            }, new SpriteGameEntity[] {location, knife0, knife1, knife2}, location);
        }

        #endregion

        #region Scene 3

        private static Texture _holaTexture;

        public static SceneMainGameEntity GetGirl()
        {
            _holaTexture = Resources.LoadTexture("Situation 3.png");
            var sprite0 = _holaTexture.GetSprite(new SDL.SDL_Rect() {x = 0, y = 0, w = 800, h = 350});
            var sprite1 = _holaTexture.GetSprite(new SDL.SDL_Rect() {x = 800, y = 0, w = 800, h = 350});
            var sprite2 = _holaTexture.GetSprite(new SDL.SDL_Rect() {x = 1600, y = 0, w = 800, h = 350});
            var sprite3 = _holaTexture.GetSprite(new SDL.SDL_Rect() {x = 2400, y = 0, w = 800, h = 350});
            var sprite4 = _holaTexture.GetSprite(new SDL.SDL_Rect() {x = 3200, y = 0, w = 800, h = 350});
            var idle = new Animation("idle", new []
            {
                sprite0, 
                sprite1,
                sprite2
            }, .3f, false, false);
            var activate = new Animation("activate", new []
            {
                sprite3,
                sprite4,
            }, 1f, true);
            return new SceneMainGameEntity(null, new Animator(new Animation[] {idle, activate}, new Transition[] {}))
            {
                Position = new Vector2(400, 200),
                Pivot = new Vector2(.5f, .5f),
                FlyDistance = 2,
            };
        }

        public static SceneGameEntity GetHola()
        {
            var sprite0 = _holaTexture.GetSprite(new SDL.SDL_Rect() {x = 0, y = 350, w = 200, h = 200});
            var sprite1 = _holaTexture.GetSprite(new SDL.SDL_Rect() {x = 200, y = 350, w = 200, h = 200});
            var sprite2 = _holaTexture.GetSprite(new SDL.SDL_Rect() {x = 400, y = 350, w = 200, h = 200});
            var idle = new Animation("idle", new []
            {
                sprite0,
                sprite1,
                sprite2
            }, .1f, false, false);
            var entity = new SceneGameEntity(null, new Animator(new []{idle}, new Transition[] {}));
            entity.Animator.PlayAnimation("idle");
            return entity;
        }

        public static Scene GetScene3()
        {
            var girl = GetGirl();
            var hola = GetHola();
            hola.Position = new Vector2(150, 200);
            hola.Pivot = new Vector2(.5f, .5f);
            hola.FlyDistance = 30;
            hola.Speed = 20;

            var hola1 = GetHola();
            hola1.Position = new Vector2(510, 110);
            hola1.Pivot = new Vector2(.5f, .5f);
            hola1.FlyDistance = 50;
            hola1.Speed = 25;

            var hola2 = GetHola();
            hola2.Position = new Vector2(180, 350);
            hola2.Pivot = new Vector2(.5f, .5f);
            hola2.FlyDistance = 10;
            hola2.Speed = 6;
            return new Scene(new []{"хола"}, new []{girl, hola, hola1, hola2}, girl);
        }

        #endregion

        #region Scene 4

        private static Texture _kissTexture;

        public static SceneMainGameEntity GetKiss()
        {
            _kissTexture = Resources.LoadTexture("Situation 4.png");
            var sprite0 = _kissTexture.GetSprite(new SDL.SDL_Rect() {x = 0, y = 0, w = 800, h = 600});
            var sprite1 = _kissTexture.GetSprite(new SDL.SDL_Rect() {x = 800, y = 0, w = 800, h = 600});
            var sprite2 = _kissTexture.GetSprite(new SDL.SDL_Rect() {x = 1600, y = 0, w = 800, h = 600});
            var idle = new Animation("idle",
                new []
                {
                    sprite0,
                    sprite1,
                }, .1f, false);
            var activate = new Animation("activate",
                new []
                {
                    sprite2
                }, 1, true);
            return new SceneMainGameEntity(null, new Animator(new []{idle, activate}, new Transition[] {})) {Position = new Vector2(400, 300), Pivot = new Vector2(.5f, .5f)};
        }

        public static Scene GetScene4()
        {
            var kiss = GetKiss();
            return new Scene(new []
            {
                "поцеловать",
                "поцелуй",
                "поцеловать в щеку"
            }, 
            new []{kiss}, kiss);
        }

        #endregion

        #region Scene 5

        private static Texture _hammerTexture;

        public static SceneMainGameEntity GetHammer()
        {
            _hammerTexture = Resources.LoadTexture("Situation 5.png");
            var sprite0 = _hammerTexture.GetSprite(new SDL.SDL_Rect() {x = 0, y = 0, w = 250, h = 300});
            var sprite1 = _hammerTexture.GetSprite(new SDL.SDL_Rect() {x = 250, y = 0, w = 250, h = 300});
            var sprite2 = _hammerTexture.GetSprite(new SDL.SDL_Rect() {x = 500, y = 0, w = 250, h = 300});
            var sprite3 = _hammerTexture.GetSprite(new SDL.SDL_Rect() {x = 750, y = 0, w = 250, h = 300});
            var idle = new Animation("idle", new []
            {
                sprite0,
                sprite1,
                sprite2
            }, .1f, false);
            var activate = new Animation("activate", new []
            {
                sprite3
            }, 1, true);
            return new SceneMainGameEntity(null, new Animator(new []{idle, activate}, new Transition[] {})) {Position = new Vector2(400, 250), Pivot = new Vector2(.5f, .5f)};
        }

        public static Scene GetScene5()
        {
            var main = GetHammer();
            return new Scene(new string[]
            {
                "забить",
                "забить гвоздь",
                "молоток",
                "ударить",
                "ударить молотком",
            }, new []{main}, main);
        }

        #endregion

        #region Scene 6

        private static SceneMainGameEntity GetMeal()
        {
            var texture = Resources.LoadTexture("Situation 6.png");
            var sprite0 = texture.GetSprite(new SDL.SDL_Rect() {x = 0, y = 0, w = 800, h = 600});
            var sprite1 = texture.GetSprite(new SDL.SDL_Rect() {x = 800, y = 0, w = 800, h = 600});
            var idle = new Animation("idle",
                new []{sprite1}, 1, true);
            var activate = new Animation("activate", 
                new []{ sprite0}, 1, true);
            return new SceneMainGameEntity(null, new Animator(new []{idle, activate}, new Transition[] {}))
            {
                Position = new Vector2(400, 300),
                Pivot = new Vector2(.5f, .5f),
                Speed = 10,
            };
        }

        public static Scene GetScene6()
        {
            var main = GetMeal();
            return new Scene(new []
            {
                "поесть",
                "покушать",
                "перекусить",
                "пообедать",
                "еда",
            }, new []{main}, main);
        }

        #endregion

        #region Scene 7

        public static SceneMainGameEntity GetYoda()
        {
            var texture = Resources.LoadTexture("Situation 7.png");
            var sprite0 = texture.GetSprite(new SDL.SDL_Rect() {x = 0, y = 0, w = 800, h = 600});
            var sprite1 = texture.GetSprite(new SDL.SDL_Rect() {x = 800, y = 0, w = 800, h = 600});
            var sprite2 = texture.GetSprite(new SDL.SDL_Rect() {x = 1600, y = 0, w = 800, h = 600});
            var idle = new Animation("idle",
                new []
                {
                    sprite1,
                    sprite2
                }, .1f, false);
            var activate = new Animation("activate",
                new []
                {
                    sprite0
                }, 1, true);
            return new SceneMainGameEntity(null, new Animator(new[] {idle, activate}, new Transition[] {}))
            {
                Position = new Vector2(400, 250),
                Pivot = new Vector2(.5f, .5f),
            };
        }

        public static Scene GetScene7()
        {
            var main = GetYoda();
            return new Scene(new []
            {
                "сила",
                "использовать силу",
            }, new []{main}, main);
        }

        #endregion

        #region Scene 8
        
        public static SceneMainGameEntity GetSwitcherNew()
        {
            _introTexture = Resources.LoadTexture("Situation intro.png");
            var sprite0 = _introTexture.GetSprite(new SDL.SDL_Rect() { x = 275, y = 0, w = 158, h = 290 });
            var sprite1 = _introTexture.GetSprite(new SDL.SDL_Rect() { x = 450, y = 0, w = 158, h = 290 });
            var sprite2 = _introTexture.GetSprite(new SDL.SDL_Rect() { x = 275, y = 270, w = 158, h = 290 });
            var sprite3 = _introTexture.GetSprite(new SDL.SDL_Rect() { x = 450, y = 270, w = 158, h = 290 });
            var idle = new Animation("activate", new Sprite[] { sprite0, sprite1 }, .1f, false);
            var activate = new Animation("idle", new Sprite[] { sprite2, sprite3 }, .1f, false);
            return new SceneMainGameEntity(sprite0, new Animator(new Animation[] { idle, activate }, new Transition[] { })) { Position = new Vector2(400, 270), Pivot = new Vector2(.5f, .5f) };
        }
        
        public static Scene GetScene8()
        {
            var switcher = GetSwitcherNew();
            return new Scene(new[]
            {
                "включить",
                "включить свет",
                "переключить",
                "нажать",
            }, new[] { switcher, GetDot0(), GetDot1(), GetTitle() }, switcher);
        }

        #endregion

        #region Finish scene

        public static Scene GetFinishScene()
        {
            var main = default(SceneMainGameEntity);
            return new Scene(new []{"конец"}, new SpriteGameEntity[] {}, main);
        }

        #endregion

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
